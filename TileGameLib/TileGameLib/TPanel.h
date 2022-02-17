/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include <vector>
#include "TGlobal.h"
#include "TRegion.h"

namespace TileGameLib
{
	class TWindow;
	class TPixelBlock;

	class TPanel
	{
	public:
		TPanel(TWindow* wnd);
		~TPanel();

		bool Grid;
		bool TransparentTiles;

		void Maximize();
		void SetBounds(int x1, int y1, int x2, int y2);
		void Move(int dx, int dy);
		void Resize(int dx, int dy);
		void SetPixelSize(int w, int h);
		int GetPixelWidth();
		int GetPixelHeight();
		void SetScroll(int x, int y);
		void Scroll(int dx, int dy);
		void Pan(int dx, int dy);
		int GetScrollX();
		int GetScrollY();
		void SetBackColor(PaletteIndex bgcix);
		int GetBackColor();
		void Clear();
		void EraseTile(int x, int y);
		void DrawTile(CharsetIndex chix, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y);
		void DrawTileString(std::string str, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y);
		void DrawPixelBlock(TPixelBlock* pixels, int x, int y);

	private:
		TWindow* Wnd;
		TRegion Bounds;
		PaletteIndex BackColor;
		int PixelWidth;
		int PixelHeight;
		int ScrollX;
		int ScrollY;

		TPanel(const TPanel& other) = delete;
	};
}
