/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include "TPanel.h"
#include "TWindow.h"
#include "TChar.h"
#include "TPixelBlock.h"

namespace TileGameLib
{
	class TPanel::TRenderedTile
	{
	public:
		TTile Tile;
		bool Transparent;
		bool AlignedToGrid;
		int PixelWidth;
		int PixelHeight;
		int X;
		int Y;
	};

	class TPanel::TRenderedPixelBlock
	{
	public:
		TPixelBlock* Block;
		int PixelWidth;
		int PixelHeight;
		int X;
		int Y;
	};

	TPanel::TPanel(TWindow* wnd) : 
		Wnd(wnd), Visible(false), Grid(false), Transparency(false)
	{
		Maximize();
		SetPixelSize(1, 1);
		SetScroll(0, 0);
		SetBackColor(0);
	}

	TPanel::~TPanel()
	{
	}

	void TPanel::Maximize()
	{
		Bounds.X1 = 0;
		Bounds.Y1 = 0;
		Bounds.X2 = Wnd->Width;
		Bounds.Y2 = Wnd->Height;
	}

	void TPanel::SetBounds(int x1, int y1, int x2, int y2)
	{
		Bounds.X1 = x1;
		Bounds.Y1 = y1;
		Bounds.X2 = x2;
		Bounds.Y2 = y2;
	}

	TRegion TPanel::GetBounds()
	{
		return Bounds;
	}

	bool TPanel::IsWithinBounds(int x, int y)
	{
		return
			x + ScrollX >= -TChar::Width &&
			x + ScrollX < GetWidth() &&
			y + ScrollY >= -TChar::Height &&
			y + ScrollY < GetHeight();
	}

	void TPanel::Move(int dx, int dy)
	{
		TRegion prevBounds = Bounds;

		Bounds.X1 += dx;
		Bounds.Y1 += dy;
		Bounds.X2 += dx;
		Bounds.Y2 += dy;

		if (Bounds.X1 < 0)
			Bounds = prevBounds;
		if (Bounds.Y1 < 0)
			Bounds = prevBounds;
	}

	void TPanel::Resize(int dx, int dy)
	{
		TRegion prevBounds = Bounds;

		Bounds.X2 += dx;
		Bounds.Y2 += dy;

		if (Bounds.X2 < Bounds.X1)
			Bounds = prevBounds;
		if (Bounds.Y2 < Bounds.Y1)
			Bounds = prevBounds;
	}

	void TPanel::SetLocation(int x, int y)
	{
		int w = GetWidth();
		int h = GetHeight();

		Bounds.X1 = x;
		Bounds.Y1 = y;
		Bounds.X2 = w + x;
		Bounds.Y2 = h + y;
	}

	void TPanel::SetSize(int w, int h)
	{
		Bounds.X2 = Bounds.X1 + w;
		Bounds.Y2 = Bounds.Y1 + h;
	}

	int TPanel::GetWidth()
	{
		return Bounds.X2 - Bounds.X1;
	}

	int TPanel::GetHeight()
	{
		return Bounds.Y2 - Bounds.Y1;
	}

	int TPanel::GetX()
	{
		return Bounds.X1;
	}

	int TPanel::GetY()
	{
		return Bounds.Y1;
	}

	void TPanel::SetPixelSize(int w, int h)
	{
		PixelWidth = w;
		PixelHeight = h;
	}

	int TPanel::GetPixelWidth()
	{
		return PixelWidth;
	}

	int TPanel::GetPixelHeight()
	{
		return PixelHeight;
	}
	
	void TPanel::SetScroll(int x, int y)
	{
		ScrollX = x;
		ScrollY = y;
	}

	void TPanel::ScrollContents(int dx, int dy)
	{
		ScrollX += dx;
		ScrollY += dy;
	}

	void TPanel::ScrollView(int dx, int dy)
	{
		ScrollX -= dx;
		ScrollY -= dy;
	}

	int TPanel::GetScrollX()
	{
		return ScrollX;
	}

	int TPanel::GetScrollY()
	{
		return ScrollY;
	}

	void TPanel::SetBackColor(PaletteIndex bgcix)
	{
		BackColor = bgcix;
	}

	int TPanel::GetBackColor()
	{
		return BackColor;
	}

	void TPanel::Clear()
	{
		Tiles.clear();
		PixelBlocks.clear();
	}

	void TPanel::EraseTile(int x, int y)
	{
		Tiles.push_back({ { 0, BackColor, BackColor }, false, Grid, PixelWidth, PixelHeight, x, y });
	}

	void TPanel::AddTile(TTile tile, int x, int y)
	{
		AddTile(tile.Char, tile.ForeColor, tile.BackColor, x, y);
	}
	
	void TPanel::AddTile(CharsetIndex chix, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y)
	{
		if (Grid) {
			x *= TChar::Width;
			y *= TChar::Height;
		}

		if (IsWithinBounds(x, y))
			Tiles.push_back({ { chix, fgcix, bgcix }, Transparency, false, PixelWidth, PixelHeight, x, y });
	}

	void TPanel::AddTileString(std::string str, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y)
	{
		if (Grid) {
			x *= TChar::Width;
			y *= TChar::Height;
		}

		for (auto& ch : str) {
			if (IsWithinBounds(x, y)) {
				Tiles.push_back({ { ch, fgcix, bgcix }, Transparency, false, PixelWidth, PixelHeight, x, y });
			}
			x += TChar::Width;
		}
	}

	void TPanel::AddPixelBlock(TPixelBlock* block, int x, int y)
	{
		const int ax = x + ScrollX + block->Width;
		const int ay = y + ScrollY + block->Height;

		PixelBlocks.push_back({block, PixelWidth, PixelHeight, x, y});
	}

	void TPanel::Draw()
	{
		if (!Visible) {
			Clear();
			return;
		}

		Wnd->SetClip(Bounds.X1, Bounds.Y1, Bounds.X2, Bounds.Y2);
		Wnd->FillClip(BackColor);

		for (auto& rtile : Tiles) {
			Wnd->Grid = rtile.AlignedToGrid;
			Wnd->TransparentTiles = rtile.Transparent;
			Wnd->SetPixelSize(rtile.PixelWidth, rtile.PixelHeight);
			Wnd->DrawTile(rtile.Tile.Char, rtile.Tile.ForeColor, rtile.Tile.BackColor, rtile.X + ScrollX, rtile.Y + ScrollY);
		}

		for (auto& rblock : PixelBlocks) {
			Wnd->SetPixelSize(rblock.PixelWidth, rblock.PixelHeight);
			Wnd->DrawPixelBlock(rblock.Block, rblock.X + ScrollX, rblock.Y + ScrollY);
		}

		Wnd->RemoveClip();
		Clear();
	}

	int TPanel::GetTileCount()
	{
		return Tiles.size();
	}
	
	int TPanel::GetPixelBlockCount()
	{
		return PixelBlocks.size();
	}
}
