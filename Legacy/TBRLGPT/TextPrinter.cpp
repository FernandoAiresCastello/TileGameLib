/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "TextPrinter.h"
#include "Graphics.h"
#include "Util.h"
#include "StringUtils.h"
#include "UIContext.h"
#include "Keyboard.h"

namespace TBRLGPT
{
	TextPrinter::TextPrinter(UIContext* ctx) : 
		TextPrinter(ctx, ctx->ForeColor, ctx->BackColor)
	{
	}

	TextPrinter::TextPrinter(UIContext* ctx, int fgcolor, int bgcolor)
	{
		Ctx = ctx;
		ForeColor = fgcolor;
		BackColor = bgcolor;
		CursorX = 0;
		CursorY = 0;
		TempCursorX = CursorX;
		TempCursorY = CursorY;
		Arrow = 0x1f;
	}

	TextPrinter::~TextPrinter()
	{
	}

	int TextPrinter::GetForeColor()
	{
		return ForeColor;
	}

	int TextPrinter::GetBackColor()
	{
		return BackColor;
	}

	int TextPrinter::GetCursorX()
	{
		return CursorX;
	}

	int TextPrinter::GetCursorY()
	{
		return CursorY;
	}

	void TextPrinter::Clear()
	{
		Ctx->Gr->Clear(BackColor);
	}

	void TextPrinter::SetColor(int fgc, int bgc)
	{
		SetForeColor(fgc);
		SetBackColor(bgc);
	}

	void TextPrinter::SetForeColor(int fgc)
	{
		ForeColor = fgc;
	}

	void TextPrinter::SetBackColor(int bgc)
	{
		BackColor = bgc;
	}

	void TextPrinter::SetArrow(int arrow)
	{
		Arrow = arrow;
	}

	void TextPrinter::Locate(int x, int y)
	{
		CursorX = x;
		CursorY = y;
	}

	void TextPrinter::PushCursor()
	{
		TempCursorX = CursorX;
		TempCursorY = CursorY;
	}

	void TextPrinter::PopCursor()
	{
		CursorX = TempCursorX;
		CursorY = TempCursorY;
	}

	void TextPrinter::InvertColors()
	{
		int temp = ForeColor;
		ForeColor = BackColor;
		BackColor = temp;
	}

	void TextPrinter::PutChar(int ch)
	{
		Ctx->Gr->PutChar(Ctx->Chars, ch, CursorX++, CursorY, ForeColor, BackColor);
	}

	void TextPrinter::Print(std::string str)
	{
		Print(false, str);
	}

	void TextPrinter::Print(bool invertColors, std::string str)
	{
		int prevX = CursorX;
		unsigned i = 0;
		while (true) {
			if (i >= str.size())
				break;
			int chr = str[i++];
			if (chr == '\n') {
				CursorY++;
				CursorX = prevX;
			}
			else {
				Ctx->Gr->PutChar(Ctx->Chars, chr, CursorX++, CursorY,
					invertColors ? BackColor : ForeColor,
					invertColors ? ForeColor : BackColor);
			}
		}
	}

	void TextPrinter::Blink(int times, int delay, bool foregroundOnly, std::string str)
	{
		int x = CursorX;
		int y = CursorY;
		int prevForeColor = ForeColor;

		for (int i = 0; i < times; i++) {
			Locate(x, y);
			Print(str);
			Ctx->Update();
			Util::Pause(delay);
			if (foregroundOnly)
				ForeColor = BackColor;
			else
				InvertColors();
			Locate(x, y);
			Print(str);
			Ctx->Update();
			Util::Pause(delay);
			if (foregroundOnly)
				ForeColor = prevForeColor;
			else
				InvertColors();
			Locate(x, y);
			Print(str);
			Ctx->Update();
			Util::Pause(delay);
		}
	}

	void TextPrinter::Colorize(std::string foreColors, int times, int delay, std::string str)
	{
		std::vector<std::string> colorString = String::Split(foreColors, ',');
		std::vector<int> colors;
		for (unsigned i = 0; i < colorString.size(); i++) {
			colors.push_back(String::ToInt(colorString[i]));
		}

		int x = CursorX;
		int y = CursorY;
		int prevForeColor = ForeColor;

		for (int i = 0; i < times; i++) {
			for (unsigned c = 0; c < colors.size(); c++) {
				Locate(x, y);
				SetForeColor(colors[c]);
				Print(str);
				Ctx->Update();
				Util::Pause(delay);
			}
		}

		ForeColor = prevForeColor;
	}

	void TextPrinter::Type(int delay, std::string str)
	{
		int prevX = CursorX;
		unsigned i = 0;
		while (true) {
			if (i >= str.size())
				break;
			int chr = str[i++];
			if (chr == '\n') {
				CursorY++;
				CursorX = prevX;
			}
			else {
				Ctx->Gr->PutChar(Ctx->Chars, chr, CursorX++, CursorY, ForeColor, BackColor);
				Ctx->Update();
				Util::Pause(delay);
			}
		}
	}

	void TextPrinter::Repeat(std::string str, int times)
	{
		for (int i = 0; i < times; i++)
			Print(str);
	}

	void TextPrinter::Repeat(char ch, int times)
	{
		for (int i = 0; i < times; i++)
			Ctx->Gr->PutChar(Ctx->Chars, ch, CursorX++, CursorY, ForeColor, BackColor);
	}

	void TextPrinter::Printw(std::string text, int lineWidth, bool typewrite, int typewriteDelay)
	{
		std::vector<std::string> words = String::Split(text, ' ', false);
		int spaceLeft = lineWidth;
		int prevCursorX = CursorX;

		for (unsigned i = 0; i < words.size(); i++) {
			std::string word = words[i] + ' ';
			int wordLength = word.length();
			if (wordLength > spaceLeft) {
				CursorY++;
				CursorX = prevCursorX;
				spaceLeft = lineWidth - wordLength;
			}
			else
				spaceLeft -= wordLength;

			if (typewrite)
				Type(typewriteDelay, word);
			else
				Print(word);
		}
	}

	void TextPrinter::PrintPaged(std::string text, int lineWidth, int rows, bool showArrow, bool typewrite, int typewriteDelay)
	{
		std::vector<std::string> words = String::Split(text, ' ', false);
		int spaceLeft = lineWidth;
		int prevX = CursorX;
		int prevY = CursorY;

		for (unsigned i = 0; i < words.size(); i++) {
			std::string word = words[i] + ' ';
			int wordLength = word.length();
			if (wordLength > spaceLeft) {
				CursorY++;
				if (CursorY >= prevY + rows) {
					if (showArrow) {
						Ctx->PutChar(Arrow, prevX + lineWidth, CursorY - 1);
						Ctx->Update();
					}
					Ctx->ClearRect(prevX, prevY, lineWidth, rows);
					Key::WaitAny();
					CursorY = prevY;
				}
				CursorX = prevX;
				spaceLeft = lineWidth - wordLength;
			}
			else
				spaceLeft -= wordLength;

			if (typewrite)
				Type(typewriteDelay, word);
			else
				Print(word);
		}
	}
}
