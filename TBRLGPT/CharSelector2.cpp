/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "CharSelector2.h"
#include "Graphics.h"
#include "UIContext.h"
#include "Charset.h"
#include "Window.h"
#include "CharEditor.h"
#include "Util.h"
#include "StringUtils.h"
#include "TextInput.h"
#include "Keyboard.h"
#include "File.h"
#include "FileSelector.h"

#define PAGE_SIZE 256

namespace TBRLGPT
{
	CharSelector2::CharSelector2(UIContext* ctx, Charset* chars, int x, int y, int w, int h) :
		Ctx(ctx), CharsToSelect(chars), CharIndex(0), Running(false)
	{
		Win = new Window(Ctx, x, y, w, h);
		WinInd = new Window(Ctx, x, y + Win->Height + 1, w, 1);
		ClipbdCharIndex = 0;
		FirstViewCharIndex = 0;
	}

	CharSelector2::~CharSelector2()
	{
		delete Win;
		delete WinInd;
	}

	void CharSelector2::SetDrawingArea(Rect area)
	{
		DrawingArea = area;
	}

	int CharSelector2::Select(int initialChar, bool allowEditing)
	{
		CharIndex = 0;
		Running = true;
		int winSize = Win->Width * Win->Height;

		while (Running)
		{
			Draw();
			Ctx->Update();

			SDL_Event e = { 0 };
			SDL_PollEvent(&e);

			if (e.type == SDL_KEYDOWN)
			{
				bool ctrl = SDL_GetModState() & KMOD_CTRL;
				bool shift = SDL_GetModState() & KMOD_SHIFT;

				switch (e.key.keysym.sym) {
					case SDLK_ESCAPE: {
						CharIndex = -1;
						Running = false;
						break;
					}
					case SDLK_RETURN:
					case SDLK_c: {
						if (ctrl)
							CopyChar();
						else
							Running = false;
						break;
					}
					case SDLK_v: {
						if (ctrl)
							PasteChar();
						break;
					}
					case SDLK_RIGHT: {
						if (CharIndex < Charset::Size - 1) {
							CharIndex++;
							if (CharIndex % Win->Width == 0) {
								FirstViewCharIndex += Win->Width;
							}
						}
						break;
					}
					case SDLK_LEFT: {
						if (CharIndex > 0) {
							CharIndex--;
							if ((CharIndex + 1) % Win->Width == 0) {
								if (FirstViewCharIndex >= Win->Width)
									FirstViewCharIndex -= Win->Width;
							}
						}
						break;
					}
					case SDLK_UP: {
						if (CharIndex >= Win->Width) {
							CharIndex -= Win->Width;
							if (FirstViewCharIndex >= Win->Width)
								FirstViewCharIndex -= Win->Width;
						}
						break;
					}
					case SDLK_DOWN: {
						if (CharIndex < Charset::Size - Win->Width) {
							CharIndex += Win->Width;
							if (CharIndex >= winSize) {
								if (FirstViewCharIndex < Charset::Size - Win->Width)
									FirstViewCharIndex += Win->Width;
							}
						}
						break;
					}
					case SDLK_PAGEUP: {
						if (CharIndex >= winSize) {
							CharIndex -= winSize;
							FirstViewCharIndex -= winSize;
						}
						break;
					}
					case SDLK_PAGEDOWN: {
						if (CharIndex < Charset::Size - winSize) {
							CharIndex += winSize;
							FirstViewCharIndex += winSize;
						}
						break;
					}
					case SDLK_HOME: {
						CharIndex = 0;
						FirstViewCharIndex = 0;
						break;
					}
					case SDLK_END: {
						break;
					}
					case SDLK_e: {
						if (allowEditing) {
							if (DrawingArea.IsValid()) {
								Ctx->ClearRect(DrawingArea);
							}
							CharEditor editor(Ctx, CharsToSelect, Win->X, Win->Y);
							editor.Edit(CharIndex);
						}
						break;
					}
					case SDLK_s: {
						if (ctrl)
							SaveCharset();
						break;
					}
					case SDLK_l: {
						if (ctrl)
							LoadCharset();
						break;
					}
				}
			}
		}

		return CharIndex;
	}

	void CharSelector2::Draw()
	{
		Win->Draw();
		WinInd->Draw();
		WinInd->Print(1, 0, String::Format("%03Xh", CharIndex));
		WinInd->PutChar(CharIndex, 7, 0);

		int x = 0;
		int y = 0;

		for (int i = FirstViewCharIndex; i < FirstViewCharIndex + CharsToSelect->Size; i++) {
			if (i >= CharsToSelect->Size)
				break;

			bool atCursor = i == CharIndex;
			int fgc = atCursor ? Ctx->BackColor : Ctx->ForeColor;
			int bgc = atCursor ? Ctx->ForeColor : Ctx->BackColor;
			Win->PutChar(i, x, y, fgc, bgc, CharsToSelect);
			x++;
			if (x >= Win->Width) {
				x = 0;
				y++;
				if (y >= Win->Height)
					break;
			}
		}
	}

	int CharSelector2::GetFirstCharIndexInPage()
	{
		return (CharIndex / PAGE_SIZE) * PAGE_SIZE;
	}

	void CharSelector2::CopyChar()
	{
		ClipbdCharIndex = CharIndex;
	}

	void CharSelector2::PasteChar()
	{
		CharsToSelect->CopyChar(CharIndex, ClipbdCharIndex);
	}

	void CharSelector2::SaveCharset()
	{
		FileSelector fs(Ctx);
		std::string file = fs.Select("SAVE CHARSET");
		if (!file.empty())
			CharsToSelect->Save(file);
	}

	void CharSelector2::LoadCharset()
	{
		FileSelector fs(Ctx);
		std::string file = fs.Select("LOAD CHARSET");
		if (!file.empty())
			CharsToSelect->Load(file);
	}
}
