/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "CharSelector.h"
#include "Graphics.h"
#include "UIContext.h"
#include "Charset.h"
#include "CharEditor.h"
#include "Util.h"
#include "StringUtils.h"
#include "TextInput.h"
#include "Keyboard.h"
#include "File.h"
#include "FileSelector.h"
#include "SimpleDialog.h"

#define WIN_W 16
#define WIN_H 16
#define PAGE_SIZE 256

namespace TBRLGPT
{
	CharSelector::CharSelector(UIContext* ctx, Charset* chars, int x, int y) :
		Ctx(ctx), CharsToSelect(chars), CharIndex(0), Running(false), X(x), Y(y)
	{
		Win = Window(Ctx, x, y, WIN_W, WIN_H);
		WinInd = Window(Ctx, x + WIN_W + 2, y, 8, 1);
		WinClipbd = Window(Ctx, x + WIN_W + 2, y + 3, 8, 1);
		ClipbdCharIndex = 0;
	}

	CharSelector::~CharSelector()
	{
	}

	int CharSelector::Select(int initialChar, bool allowEditing)
	{
		CharIndex = initialChar;
		Running = true;
		Clear();

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

				switch (e.key.keysym.sym)
				{
					case SDLK_ESCAPE:
					{
						CharIndex = -1;
						Running = false;
						break;
					}
					case SDLK_RETURN:
					case SDLK_c:
					{
						if (ctrl)
							CopyChar();
						else
							Running = false;
						break;
					}
					case SDLK_v:
					{
						if (ctrl)
							PasteChar();
						break;
					}
					case SDLK_RIGHT:
					{
						if (CharIndex < Charset::Size - 1)
							CharIndex++;
						break;
					}
					case SDLK_LEFT:
					{
						if (CharIndex > 0)
							CharIndex--;
						break;
					}
					case SDLK_UP:
					{
						if (CharIndex >= WIN_W)
							CharIndex -= WIN_W;
						break;
					}
					case SDLK_DOWN:
					{
						if (CharIndex < Charset::Size - WIN_W)
							CharIndex += WIN_W;
						break;
					}
					case SDLK_PAGEUP:
					{
						if (CharIndex >= PAGE_SIZE)
						{
							CharIndex -= PAGE_SIZE;
							CharIndex = GetFirstCharIndexInPage();
						}
						break;
					}
					case SDLK_PAGEDOWN:
					{
						if (CharIndex < Charset::Size - PAGE_SIZE)
						{
							CharIndex += PAGE_SIZE;
							CharIndex = GetFirstCharIndexInPage();
						}
						break;
					}
					case SDLK_HOME:
					{
						CharIndex = GetFirstCharIndexInPage();
						break;
					}
					case SDLK_END:
					{
						CharIndex = GetFirstCharIndexInPage() + PAGE_SIZE - 1;
						break;
					}
					case SDLK_e:
					{
						if (allowEditing)
						{
							CharEditor editor(Ctx, CharsToSelect, Win.X + Win.Width + 2, Win.Y);
							editor.Edit(CharIndex);
							Clear();
						}
						break;
					}
					case SDLK_s:
					{
						if (ctrl)
							SaveCharset();
						break;
					}
					case SDLK_l:
					{
						if (ctrl)
							LoadCharset();
						break;
					}
				}
			}
		}

		return CharIndex;
	}

	void CharSelector::Clear()
	{
		Ctx->ClearRect(0, 0, 32, Ctx->Gr->Rows);
	}

	void CharSelector::Draw()
	{
		Win.Draw();
		WinInd.Draw();
		WinClipbd.Draw();

		int chr = (CharIndex / PAGE_SIZE) * PAGE_SIZE;

		for (int row = 0; row < WIN_H; row++) {
			for (int col = 0; col < WIN_W; col++, chr++) {
				bool atCursor = (CharIndex % PAGE_SIZE) == col + row * WIN_W;
				int fgc = atCursor ? Ctx->BackColor : Ctx->ForeColor;
				int bgc = atCursor ? Ctx->ForeColor : Ctx->BackColor;
				Ctx->Gr->PutChar(CharsToSelect, chr, col + X + 1, row + Y + 1, fgc, bgc);
			}
		}

		WinInd.Print(1, 0, String::Format("%02X", CharIndex));
		Ctx->Gr->PutChar(CharsToSelect, CharIndex, WinInd.X + 7, WinInd.Y + 1, Ctx->ForeColor, Ctx->BackColor);
		WinClipbd.Print(1, 0, "CLIP ");
		Ctx->Gr->PutChar(CharsToSelect, ClipbdCharIndex, WinClipbd.X + 7, WinClipbd.Y + 1, Ctx->ForeColor, Ctx->BackColor);
	}

	int CharSelector::GetFirstCharIndexInPage()
	{
		return (CharIndex / PAGE_SIZE) * PAGE_SIZE;
	}

	void CharSelector::CopyChar()
	{
		ClipbdCharIndex = CharIndex;
	}

	void CharSelector::PasteChar()
	{
		CharsToSelect->CopyChar(CharIndex, ClipbdCharIndex);
	}

	void CharSelector::SaveCharset()
	{
		SimpleDialog dlg(Ctx);
		std::string option = dlg.ReadString("Save as binary or hex (B/H)?", 1);
		option = String::ToUpper(option);
		if (option == "B" || option == "H") {
			FileSelector fs(Ctx);
			std::string file = fs.Select("SAVE CHARSET");
			if (!file.empty()) {
				if (option == "B")
					CharsToSelect->Save(file);
				else if (option == "H")
					CharsToSelect->SaveHex(file);
			}
		}

		Clear();
	}

	void CharSelector::LoadCharset()
	{
		FileSelector fs(Ctx);
		std::string file = fs.Select("LOAD CHARSET");
		if (!file.empty())
			CharsToSelect->Load(file);
		
		Clear();
	}
}
