/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include "TPanel.h"
#include "TPanelWindow.h"
#include "TChar.h"
#include "TTile.h"

namespace TileGameLib
{
	TPanel::TPanel(TPanelWindow* wnd, TRegion bounds) :
		Wnd(wnd), Visible(false), Grid(false), Maximized(false), PrevBounds(bounds)
	{
		SetBounds(bounds);
		SetPixelSize(1, 1);
		SetScroll(0, 0);
		SetBackColor(0);
	}

	TPanel::~TPanel()
	{
		Tiles.clear();
	}

	void TPanel::SetBounds(TRegion bounds)
	{
		Bounds = bounds;
	}

	void TPanel::SetBounds(int x1, int y1, int x2, int y2)
	{
		Bounds = TRegion(x1, y1, x2, y2);
	}

	void TPanel::Maximize()
	{
		if (!Wnd)
			return;

		if (Maximized) {
			Maximized = false;
			Bounds = PrevBounds;
		}
		else {
			Maximized = true;
			PrevBounds = Bounds;
			Bounds = Wnd->GetBounds();
		}
	}

	bool TPanel::IsMaximized()
	{
		return Maximized;
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
	}

	void TPanel::AddTile(TTile tile, int x, int y, bool transparent)
	{
		AddTile(tile.Char, tile.ForeColor, tile.BackColor, x, y, transparent);
	}
	
	void TPanel::AddTile(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg, int x, int y, bool transparent)
	{
		TTileSeq seq = { ch, fg, bg };
		AddAnimatedTile(seq, x, y, transparent);
	}

	void TPanel::AddTileString(std::string str, PaletteIndex fg, PaletteIndex bg, int x, int y, bool transparent)
	{
		if (Grid) {
			x *= TChar::Width;
			y *= TChar::Height;
		}

		for (auto& ch : str) {
			if (IsWithinBounds(x, y)) {
				Tiles.push_back({ { ch, fg, bg }, transparent, false, PixelWidth, PixelHeight, x, y });
			}
			x += TChar::Width;
		}
	}

	void TPanel::AddAnimatedTile(TTileSeq seq, int x, int y, bool transparent)
	{
		if (Grid) {
			x *= TChar::Width;
			y *= TChar::Height;
		}

		if (IsWithinBounds(x, y))
			Tiles.push_back({ seq, transparent, false, PixelWidth, PixelHeight, x, y });
	}

	std::vector<TPanel::TRenderedTileSeq>& TPanel::GetTiles()
	{
		return Tiles;
	}

	int TPanel::GetTileCount()
	{
		return Tiles.size();
	}
}
