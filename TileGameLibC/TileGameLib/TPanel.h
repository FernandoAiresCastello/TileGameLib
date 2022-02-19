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
		TRegion GetBounds();
		void Move(int dx, int dy);
		void Resize(int dx, int dy);
		void SetLocation(int x, int y);
		void SetSize(int w, int h);
		int GetWidth();
		int GetHeight();
		int GetX();
		int GetY();
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
		void AddTile(CharsetIndex chix, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y);
		void AddTileString(std::string str, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y);
		void AddPixelBlock(TPixelBlock* block, int x, int y);
		void Draw();

	private:
		class TRenderedTile;
		class TRenderedPixelBlock;

		TWindow* Wnd;
		TRegion Bounds;
		PaletteIndex BackColor;
		int PixelWidth;
		int PixelHeight;
		int ScrollX;
		int ScrollY;
		std::vector<TRenderedTile> Tiles;
		std::vector<TRenderedPixelBlock> PixelBlocks;

		TPanel(const TPanel& other) = delete;

		bool IsWithinBounds(int x, int y);
	};
}
