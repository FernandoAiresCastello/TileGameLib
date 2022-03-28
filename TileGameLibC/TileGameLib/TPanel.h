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
#include "TTile.h"
#include "TTileSeq.h"

namespace TileGameLib
{
	class TPanelWindow;

	class TPanel
	{
	public:
		class TRenderedTileSeq
		{
		public:
			TTileSeq TileSeq;
			bool Transparent;
			bool AlignedToGrid;
			int PixelWidth;
			int PixelHeight;
			int X;
			int Y;
		};

		TPanel(TPanelWindow* wnd, TRegion bounds);
		~TPanel();

		bool Visible;
		bool Grid;

		void SetBounds(TRegion bounds);
		void SetBounds(int x1, int y1, int x2, int y2);
		void Maximize();
		bool IsMaximized();
		TRegion GetBounds();
		bool IsWithinBounds(int x, int y);
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
		void ScrollContents(int dx, int dy);
		void ScrollView(int dx, int dy);
		int GetScrollX();
		int GetScrollY();
		void SetBackColor(PaletteIndex bg);
		int GetBackColor();
		void Clear();
		void AddTile(TTile tile, int x, int y, bool transparent);
		void AddTile(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg, int x, int y, bool transparent);
		void AddTileString(std::string str, PaletteIndex fg, PaletteIndex bg, int x, int y, bool transparent);
		void AddAnimatedTile(TTileSeq seq, int x, int y, bool transparent);
		std::vector<TRenderedTileSeq>& GetTiles();
		int GetTileCount();

	private:
		TPanelWindow* Wnd;
		TRegion Bounds;
		TRegion PrevBounds;
		bool Maximized;
		PaletteIndex BackColor;
		int PixelWidth;
		int PixelHeight;
		int ScrollX;
		int ScrollY;
		std::vector<TRenderedTileSeq> Tiles;

		TPanel(const TPanel& other) = delete;
	};
}
