/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "PaletteEditor2.h"
#include "Graphics.h"
#include "Palette.h"
#include "UIContext.h"
#include "Window.h"
#include "Util.h"
#include "StringUtils.h"
#include "TextInput.h"
#include "Keyboard.h"
#include "ConfirmDialog.h"
#include "SimpleDialog.h"
#include "StringUtils.h"
#include "File.h"
#include "FileSelector.h"
#include "Window.h"

namespace TBRLGPT
{
	PaletteEditor2::PaletteEditor2(UIContext* ctx, Palette* paletteToEdit) :
		PaletteEditor2(ctx, paletteToEdit, 0, 0, 16, 16)
	{
	}

	PaletteEditor2::PaletteEditor2(UIContext * ctx, Palette * paletteToEdit, int x, int y, int w, int h)
	{
		Ctx = ctx;
		PaletteToEdit = paletteToEdit;
		Running = false;
		Index = 0;
		Win = new Window(ctx, x, y, w, h);
		WinInd = new Window(ctx, x, Win->Height - 2, w, 2);
	}

	PaletteEditor2::~PaletteEditor2()
	{
		delete Win;
		delete WinInd;
	}

	int PaletteEditor2::Edit(int initialColorIx)
	{
		Index = initialColorIx;
		Running = true;

		while (Running)
		{
			DrawPalette();

			SDL_Event e = { 0 };
			SDL_PollEvent(&e);

			if (e.type == SDL_KEYDOWN)
			{
				bool ctrl = SDL_GetModState() & KMOD_CTRL;
				bool shift = SDL_GetModState() & KMOD_SHIFT;

				switch (e.key.keysym.sym)
				{
				case SDLK_RETURN:
				case SDLK_f:
				case SDLK_b:
					Running = false;
					break;
				case SDLK_ESCAPE:
					Running = false;
					Index = -1;
					break;
				case SDLK_RIGHT:
					if (Index < Palette::Size - 1)
						Index++;
					break;
				case SDLK_LEFT:
					if (Index > 0)
						Index--;
					break;
				case SDLK_DOWN:
					if (Index < (Palette::Size - 1) - Win->Width)
						Index += Win->Width;
					break;
				case SDLK_UP:
					if (Index > Win->Width)
						Index -= Win->Width;
					break;
				case SDLK_e:
					if (ctrl)
						;//EditColor();
					else
						SetColorHex();
					break;
				case SDLK_c:
					if (ctrl)
						CopyColor();
					break;
				case SDLK_v:
					if (ctrl)
						PasteColor();
					break;
				case SDLK_s:
					if (ctrl) {
						SavePalette();
						Clear();
					}
					break;
				case SDLK_l:
					if (ctrl) {
						LoadPalette();
						Clear();
					}
					break;
				case SDLK_DELETE:
					if (shift) {
						ClearAllColors();
						Clear();
					}
					else {
						PaletteToEdit->Get(Index)->SetRGB(0, 0, 0);
					}
				}
			}
		}

		return Index;
	}

	void PaletteEditor2::Clear()
	{
		Ctx->ClearRect(0, 0, 32, Ctx->Gr->Rows);
	}

	void PaletteEditor2::DrawPalette()
	{
		// Main window
		int x = 0;
		int y = 0;
		Win->Draw();
		for (int i = 0; i < Palette::Size; i++) {
			int c = PaletteToEdit->Get(i)->ToInteger();
			Win->PutChar(i == Index ? 0xfe : 0x00, x, y, 0xffffff, c, Ctx->Chars);
			x++;
			if (x >= Win->Width) {
				x = 0;
				y++;
				if (y >= Win->Height)
					break;
			}
		}

		// Indicator window
		WinInd->Draw();
		Color* color = PaletteToEdit->Get(Index);
		WinInd->Print(1, 0, String::Format("%02Xh", Index));
		WinInd->Print(1, 1, String::Format("%06Xh", color->ToInteger()));
		for (int i = 4; i < Win->Width - 1; i++)
			WinInd->PutChar(0xdb, i, 0, color->ToInteger(), 0x000000, Ctx->Chars);

		Ctx->Update();
	}

	void PaletteEditor2::SetColorHex()
	{
		TextInput dlg(Ctx);
		std::string hex = dlg.ReadString(WinInd->X + 2, WinInd->Y + 2, 6, true);
		if (!dlg.HasEscaped() && hex.length() == 6) {
			int color = String::HexToInt(hex);
			PaletteToEdit->Get(Index)->SetRGB(color);
		}
	}

	void PaletteEditor2::EditColor()
	{
		bool running = true;
		int ix = 0;
		int initialColor = PaletteToEdit->Get(Index)->ToInteger();
		int step = 0x10;

		while (running)
		{
			Color* color = PaletteToEdit->Get(Index);

			if (ix == 0) Ctx->PrintInvertColors(WinInd->X + 2, WinInd->Y + 2, String::Format("%02X", color->R));
			else Ctx->Print(WinInd->X + 2, WinInd->Y + 2, String::Format("%02X", color->R));
			if (ix == 1) Ctx->PrintInvertColors(Win->X + WinInd->X + 4, WinInd->Y + 2, String::Format("%02X", color->G));
			else Ctx->Print(WinInd->X + 4, WinInd->Y + 2, String::Format("%02X", color->G));
			if (ix == 2) Ctx->PrintInvertColors(Win->X + WinInd->X + 6, WinInd->Y + 2, String::Format("%02X", color->B));
			else Ctx->Print(WinInd->X + 6, WinInd->Y + 2, String::Format("%02X", color->B));

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
					running = false;
					color->SetRGB(initialColor);
					break;
				case SDLK_RETURN:
					running = false;
					break;
				case SDLK_UP:
					if (ix == 0) ctrl ? color->R += step : color->R++;
					if (ix == 1) ctrl ? color->G += step : color->G++;
					if (ix == 2) ctrl ? color->B += step : color->B++;
					break;
				case SDLK_DOWN:
					if (ix == 0) ctrl ? color->R -= step : color->R--;
					if (ix == 1) ctrl ? color->G -= step : color->G--;
					if (ix == 2) ctrl ? color->B -= step : color->B--;
					break;
				case SDLK_RIGHT:
					ix++;
					if (ix > 2) ix = 0;
					break;
				case SDLK_LEFT:
					ix--;
					if (ix < 0) ix = 2;
					break;
				}
			}
		}
	}

	void PaletteEditor2::CopyColor()
	{
		ClipboardColor = *PaletteToEdit->Get(Index);
	}

	void PaletteEditor2::PasteColor()
	{
		*PaletteToEdit->Get(Index) = ClipboardColor;
	}

	void PaletteEditor2::ClearAllColors()
	{
		ConfirmDialog dialog(Ctx);
		if (dialog.Confirm("Clear all colors")) {
			PaletteToEdit->Clear();
		}
	}

	void PaletteEditor2::SavePalette()
	{
		FileSelector fs(Ctx);
		std::string file = fs.Select("SAVE PALETTE");
		if (!file.empty())
			PaletteToEdit->Save(file);

		Clear();
	}

	void PaletteEditor2::LoadPalette()
	{
		FileSelector fs(Ctx);
		std::string file = fs.Select("LOAD PALETTE");
		if (!file.empty())
			PaletteToEdit->Load(file);

		Clear();
	}
}
