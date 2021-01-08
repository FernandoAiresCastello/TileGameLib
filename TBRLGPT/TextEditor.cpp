/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "TextEditor.h"
#include "Window.h"
#include "UIContext.h"
#include "Graphics.h"
#include "Keyboard.h"
#include "StringUtils.h"
#include "Util.h"
#include "Sound.h"
#include "FileSelector.h"
#include "File.h"

namespace TBRLGPT
{
	TextEditor::TextEditor(UIContext* ctx, bool border) :
		TextEditor(ctx, 0, 0, ctx->Gr->Cols, ctx->Gr->Rows, border)
	{
	}

	TextEditor::TextEditor(UIContext* ctx, int x, int y, int w, int h, bool border)
	{
		if (border) {
			w -= 2;
			h -= 2;
		}

		Ctx = ctx;
		Win = new Window(Ctx, x, y, w, h, border);
		Running = false;
		Overwrite = false;
		Col = 0;
		Row = 0;
		Scroll = 0;
		LastKeyPressed = 0;
		Readonly = false;
		EscEnabled = true;
		TabWidth = 3;

		AddBlankLine();
	}

	TextEditor::~TextEditor()
	{
		delete Win;
	}

	void TextEditor::Run()
	{
		Running = true;
		while (Running) {
			Draw();
			LastKeyPressed = Key::WaitAny();
			bool interrupt = CheckInterrupt();
			if (interrupt)
				Running = false;
			if (!interrupt || (interrupt && !PreventDefault()))
				ProcessKeyInput();
		}
	}

	void TextEditor::SetReadonly(bool readonly)
	{
		Readonly = readonly;
	}

	void TextEditor::AddInterruptKey(int key, bool preventDefault)
	{
		InterruptKeys[key] = preventDefault;
	}

	void TextEditor::EnableEscape(bool enable)
	{
		EscEnabled = enable;
	}

	void TextEditor::SetTabWidth(int width)
	{
		TabWidth = width >= 0 ? width : 0;
	}

	void TextEditor::SetText(std::string text)
	{
		Lines.clear();
		text = String::RemoveAll(text, "\r");
		std::vector<std::string> textLines = String::Split(text, '\n');
		for (unsigned i = 0; i < textLines.size(); i++) {
			Lines.push_back(textLines[i]);
		}
		if (Lines.empty())
			AddBlankLine();
	}

	std::string TextEditor::GetText()
	{
		return GetText("\n");
	}

	std::string TextEditor::GetText(std::string newline)
	{
		std::string text = "";
		for (unsigned i = 0; i < Lines.size(); i++) {
			if (i < Lines.size() - 1)
				text += Lines[i] + newline;
			else
				text += Lines[i];
		}
		return text;
	}

	int TextEditor::GetKeyPressed()
	{
		return LastKeyPressed;
	}

	bool TextEditor::KeyPressed(int key)
	{
		return LastKeyPressed == key;
	}

	void TextEditor::Draw()
	{
		Win->Draw();
		
		for (unsigned i = 0; i < Lines.size(); i++) {
			if (i >= Win->Height)
				break;

			if (Scroll + i < Lines.size()) {
				std::string& line = Lines[Scroll + i];
				Win->Print(0, i, line.substr(0, Win->Width));
			}
		}

		if (Col >= 0 && Col < Win->Width) {
			int charAtCursor = Col < Lines[Row].length() ? Lines[Row].at(Col) : 0;
			Win->PutChar(charAtCursor, Col, Row - Scroll, Ctx->BackColor, Ctx->ForeColor);
		}

		Ctx->Update();
	}

	void TextEditor::ProcessKeyInput()
	{
		bool ctrl = Key::Ctrl();
		switch (LastKeyPressed) {
		case SDLK_ESCAPE:
			if (EscEnabled)
				Running = false;
			break;
		case SDLK_RETURN:
			if (ctrl)
				Ctx->Gr->ToggleFullscreen();
			else if (!Readonly) 
				NewLine();
			break;
		case SDLK_BACKSPACE:
			if (!Readonly) BackSpace();
			break;
		case SDLK_DELETE:
			if (!Readonly) Delete();
			break;
		case SDLK_INSERT:
			if (!Readonly) ToggleOverwrite();
			break;
		case SDLK_RIGHT:
			CursorRight();
			break;
		case SDLK_LEFT:
			CursorLeft();
			break;
		case SDLK_DOWN:
			CursorDown();
			break;
		case SDLK_UP:
			CursorUp();
			break;
		case SDLK_HOME:
			Home();
			break;
		case SDLK_END:
			End();
			break;
		case SDLK_TAB:
			if (!Readonly) AddTab();
			break;
		case SDLK_l:
			if (ctrl)
				SelectLoadFromFile();
			break;
		default:
			if (!Readonly) AddChar(LastKeyPressed);
			break;
		}
	}

	bool TextEditor::CheckInterrupt()
	{
		return InterruptKeys.find(LastKeyPressed) != InterruptKeys.end();
	}

	bool TextEditor::PreventDefault()
	{
		return InterruptKeys[LastKeyPressed];
	}

	void TextEditor::AddChar(int ch)
	{
		if (Key::CapsLock() || Key::Shift()) {
			if (ch >= SDLK_a && ch <= SDLK_z)
				ch = toupper(ch);
			else if (Key::Shift())
				ch = String::ShiftChar(ch);
		}

		if (ch >= 0 && ch <= 255) {
			std::string& line = Lines[Row];
			if (Col >= line.length())
				line += ch;
			else {
				if (Overwrite)
					line.at(Col) = ch;
				else
					line.insert(Col, 1, ch);
			}
			Col++;
		}
	}

	void TextEditor::AddTab()
	{
		for (int i = 0; i < TabWidth; i++)
			AddChar(' ');
	}

	void TextEditor::AddBlankLine()
	{
		Lines.push_back("");
	}

	void TextEditor::NewLine()
	{
		std::string before = Lines[Row].substr(0, Col);
		std::string after = Lines[Row].substr(Col);

		Lines[Row] = before;
		Col = 0;
		Row++;
		Lines.insert(Lines.begin() + Row, after);
		
		if (Row - Scroll >= Win->Height)
			ScrollDown();
	}

	std::string TextEditor::GetCurrentLine()
	{
		return Lines[Row];
	}

	void TextEditor::LoadFromFile(std::string path)
	{
		Clear();
		std::string text = File::ReadText(path);
		Lines = String::Split(text, '\n');
	}

	void TextEditor::Clear()
	{
		Lines.clear();
		Col = 0;
		Row = 0;
		Scroll = 0;
	}

	void TextEditor::BackSpace()
	{
		if (Col > 0) {
			Col--;
			Lines[Row].erase(Col, 1);
		}
		else if (Row > 0) {
			std::string line = Lines[Row];
			Lines.erase(Lines.begin() + Row);
			Row--;
			Col = Lines[Row].length();
			Lines[Row] += line;
		}
	}

	void TextEditor::Delete()
	{
		if (Col >= Lines[Row].length() && Row < Lines.size() - 1) {
			std::string line = Lines[Row];
			Lines.erase(Lines.begin() + Row);
			if (!Lines.empty()) {
				Lines[Row] = line + Lines[Row];
			}
		}
		else if (Lines[Row].length() > 0) {
			Lines[Row].erase(Col, 1);
		}
	}

	void TextEditor::ToggleOverwrite()
	{
		Overwrite = !Overwrite;
	}

	void TextEditor::CursorRight()
	{
		if (Col < Lines[Row].length())
			Col++;
	}

	void TextEditor::CursorLeft()
	{
		if (Col > 0)
			Col--;
	}

	void TextEditor::CursorDown()
	{
		if (Row < Lines.size() - 1) {
			Row++;
			if (Col > Lines[Row].length())
				Col = Lines[Row].length();
			if (Row - Scroll >= Win->Height)
				ScrollDown();
		}
	}

	void TextEditor::CursorUp()
	{
		if (Row > 0) {
			Row--;
			if (Col > Lines[Row].length())
				Col = Lines[Row].length();
			if (Row - Scroll < 0)
				ScrollUp();
		}
	}

	void TextEditor::Home()
	{
		Col = 0;
		if (Key::Ctrl())
			Row = 0;
	}

	void TextEditor::End()
	{
		if (Key::Ctrl())
			Row = Lines.size() - 1;

		Col = Lines[Row].length();
	}

	void TextEditor::ScrollDown()
	{
		if (Scroll < Lines.size())
			Scroll++;
	}

	void TextEditor::ScrollUp()
	{
		if (Scroll > 0)
			Scroll--;
	}

	void TextEditor::SelectLoadFromFile()
	{
		FileSelector fs(Ctx);
		std::string file = fs.Select("Select text file to import");
		if (!file.empty())
			LoadFromFile(file);
	}
}
