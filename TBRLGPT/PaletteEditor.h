/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Color.h"

namespace TBRLGPT
{
	class UIContext;
	class Palette;

	class TBRLGPT_API PaletteEditor
	{
	public:
		PaletteEditor(UIContext* ctx, Palette* paletteToEdit);
		~PaletteEditor();

		int Edit(int initialColorIx);

	private:
		UIContext* Ctx;
		Palette* PaletteToEdit;
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
