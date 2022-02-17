/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include "TPanel.h"
#include "TWindow.h"
#include "TChar.h"

namespace TileGameLib
{
	TPanel::TPanel(TWindow* wnd) : 
		Wnd(wnd), Grid(false), TransparentTiles(false)
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
		Bounds.X2 = Wnd->ScreenWidth;
		Bounds.Y2 = Wnd->ScreenHeight;
	}

	void TPanel::SetBounds(int x1, int y1, int x2, int y2)
	{
		Bounds.X1 = x1;
		Bounds.Y1 = y1;
		Bounds.X2 = x2;
		Bounds.Y2 = y2;
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

	void TPanel::Scroll(int dx, int dy)
	{
		ScrollX += dx;
		ScrollY += dy;
	}

	void TPanel::Pan(int dx, int dy)
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
		Wnd->SetPixelSize(PixelWidth, PixelHeight);
		Wnd->SetClip(Bounds.X1, Bounds.Y1, Bounds.X2, Bounds.Y2);
		Wnd->FillClip(BackColor);
		Wnd->RemoveClip();
	}

	void TPanel::EraseTile(int x, int y)
	{
		Wnd->Grid = Grid;
		Wnd->SetPixelSize(PixelWidth, PixelHeight);
		Wnd->SetClip(Bounds.X1, Bounds.Y1, Bounds.X2, Bounds.Y2);
		Wnd->EraseTile(x + ScrollX, y + ScrollY);
		Wnd->RemoveClip();
	}
	
	void TPanel::DrawTile(CharsetIndex chix, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y)
	{
		Wnd->Grid = Grid;
		Wnd->TransparentTiles = TransparentTiles;
		Wnd->SetPixelSize(PixelWidth, PixelHeight);
		Wnd->SetClip(Bounds.X1, Bounds.Y1, Bounds.X2, Bounds.Y2);
		Wnd->DrawTile(chix, fgcix, bgcix, x + ScrollX, y + ScrollY);
		Wnd->RemoveClip();
	}

	void TPanel::DrawTileString(std::string str, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y)
	{
		Wnd->Grid = Grid;
		Wnd->TransparentTiles = TransparentTiles;
		Wnd->SetPixelSize(PixelWidth, PixelHeight);
		Wnd->SetClip(Bounds.X1, Bounds.Y1, Bounds.X2, Bounds.Y2);
		Wnd->DrawTileString(str, fgcix, bgcix, x + ScrollX, y + ScrollY);
		Wnd->RemoveClip();
	}

	void TPanel::DrawPixelBlock(TPixelBlock* pixels, int x, int y)
	{
		Wnd->SetPixelSize(PixelWidth, PixelHeight);
		Wnd->SetClip(Bounds.X1, Bounds.Y1, Bounds.X2, Bounds.Y2);
		Wnd->DrawPixelBlock(pixels, x + ScrollX, y + ScrollY);
		Wnd->RemoveClip();
	}
}
