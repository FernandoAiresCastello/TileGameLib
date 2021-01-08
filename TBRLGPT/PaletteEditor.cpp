/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "PaletteEditor.h"
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

namespace TBRLGPT
{
	PaletteEditor::PaletteEditor(UIContext* ctx, Palette* paletteToEdit)
	{
		Ctx = ctx;
		PaletteToEdit = paletteToEdit;
		Running = false;
		Index = 0;
	}

	PaletteEditor::~PaletteEditor()
	{
	}

	int PaletteEditor::Edit(int initialColorIx)
	{
		Index = initialColorIx;
		Running = true;
		Clear();

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
					if (Index < (Palette::Size - 1) - 15)
						Index += 16;
					break;
				case SDLK_UP:
					if (Index > 15)
						Index -= 16;
					break;
				case SDLK_e:
					if (ctrl)
						EditColor();
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

	void PaletteEditor::Clear()
	{
		Ctx->ClearRect(0, 0, 32, Ctx->Gr->Rows);
	}

	void PaletteEditor::DrawPalette()
	{
		int x = 1;
		int y = 1;
		int prevx = x;
		int indx = x + 17;
		int indy = y - 1;

		Window win(Ctx, x - 1, y - 1, 16, 16);
		Window ind(Ctx, indx, indy, 8, 2);
		win.Draw();
		ind.Draw();

		Color* color = PaletteToEdit->Get(Index);

		Ctx->Print(indx + 1, indy + 1, String::Format("%02X", Index));
		Ctx->Print(indx + 1, indy + 2, String::Format("0x%06X", color->ToInteger()));
		for (int i = 0; i < 5; i++)
			Ctx->Gr->PutChar(Ctx->Chars, 0xdb, indx + 4 + i, indy + 1, color->ToInteger(), 0x000000);

		for (int i = 0; i < Palette::Size; i++) {
			int c = PaletteToEdit->Get(i)->ToInteger();
			Ctx->Gr->PutChar(Ctx->Chars, i == Index ? 0xfe : 0x00, x + 0, y, 0xffffff, c);
			x += 1;
			if ((i + 1) % 16 == 0) {
				x = prevx;
				y++;
			}
		}

		Ctx->Update();
	}

	void PaletteEditor::SetColorHex()
	{
		SimpleDialog dlg(Ctx);
		std::string hex = dlg.ReadString("RGB:", 6);
		if (!dlg.HasEscaped() && hex.length() == 6) {
			int color = String::HexToInt(hex);
			PaletteToEdit->Get(Index)->SetRGB(color);
		}
	}

	void PaletteEditor::EditColor()
	{
		bool running = true;
		int ix = 0;
		int initialColor = PaletteToEdit->Get(Index)->ToInteger();
		int step = 0x10;

		while (running)
		{
			Color* color = PaletteToEdit->Get(Index);

			for (int i = 0; i < 5; i++)
				Ctx->Gr->PutChar(Ctx->Chars, 0xdb, 22 + i, 1, color->ToInteger(), Ctx->BackColor);

			Ctx->Print(19, 2, "0x");

			if (ix == 0) Ctx->PrintInvertColors(21, 2, String::Format("%02X", color->R));
				else Ctx->Print(21, 2, String::Format("%02X", color->R));
			if (ix == 1) Ctx->PrintInvertColors(23, 2, String::Format("%02X", color->G));
				else Ctx->Print(23, 2, String::Format("%02X", color->G));
			if (ix == 2) Ctx->PrintInvertColors(25, 2, String::Format("%02X", color->B));
				else Ctx->Print(25, 2, String::Format("%02X", color->B));

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

	void PaletteEditor::CopyColor()
	{
		ClipboardColor = *PaletteToEdit->Get(Index);
	}

	void PaletteEditor::PasteColor()
	{
		*PaletteToEdit->Get(Index) = ClipboardColor;
	}

	void PaletteEditor::ClearAllColors()
	{
		ConfirmDialog dialog(Ctx);
		if (dialog.Confirm("Clear all colors")) {
			PaletteToEdit->Clear();
		}
	}

	void PaletteEditor::SavePalette()
	{
		FileSelector fs(Ctx);
		std::string file = fs.Select("SAVE PALETTE");
		if (!file.empty())
			PaletteToEdit->Save(file);
		
		Clear();
	}

	void PaletteEditor::LoadPalette()
	{
		FileSelector fs(Ctx);
		std::string file = fs.Select("LOAD PALETTE");
		if (!file.empty())
			PaletteToEdit->Load(file);

		Clear();
	}
}
