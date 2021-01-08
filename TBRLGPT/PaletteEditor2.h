/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Color.h"

namespace TBRLGPT
{
	class UIContext;
	class Palette;
	class Window;

	class TBRLGPT_API PaletteEditor2
	{
	public:
		PaletteEditor2(UIContext* ctx, Palette* paletteToEdit);
		PaletteEditor2(UIContext* ctx, Palette* paletteToEdit, int x, int y, int w, int h);
		~PaletteEditor2();

		int Edit(int initialColorIx);

	private:
		UIContext* Ctx;
		Palette* PaletteToEdit;
		Window* Win;
		Window* WinInd;
		Color ClipboardColor;
		bool Running;
		int Index;

		void Clear();
		void DrawPalette();
		void SetColorHex();
		void EditColor();
		void CopyColor();
		void PasteColor();
		void ClearAllColors();
		void SavePalette();
		void LoadPalette();
	};
}
