/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include <Windows.h>
#include <SDL_syswm.h>
#include "TBufferedWindow.h"
#include "TChar.h"
#include "TCharset.h"
#include "TPalette.h"

struct {
	const int MaxSpeed = 1000;
	int Speed = 700;
	bool Running = false;
	bool Enabled = true;
	unsigned long long Frame = 0;
	unsigned long long CachedFrame = 0;
}
BufWndTileAnimation;

int BufWndAnimateTiles(void* dummy)
{
	BufWndTileAnimation.Running = true;

	while (BufWndTileAnimation.Running) {
		if (BufWndTileAnimation.Enabled)
			BufWndTileAnimation.Frame++;

		const int delay = abs(BufWndTileAnimation.Speed - BufWndTileAnimation.MaxSpeed);
		if (delay)
			SDL_Delay(delay);
	}

	return 0;
}

namespace TileGameLib
{
	TBufferedWindow::TBufferedWindow(int layerCount, int cols, int rows, int pixelWidth, int pixelHeight) :
		TWindowBase(cols * (TChar::Width * pixelWidth), rows * (TChar::Height * pixelHeight)),
		Cols(cols), Rows(rows), LastCol(cols - 1), LastRow(rows - 1),
		PixelWidth(pixelWidth), PixelHeight(pixelHeight),
		HorizontalResolution(cols * TChar::Width), VerticalResolution(rows * TChar::Height)
	{
		TileBuffers.push_back(new TTileBuffer(layerCount, cols, rows));
		Buffer = new RGB[BufferLength];
		Chr = TCharset::Default;
		Pal = TPalette::Default;
		SDL_CreateThread(BufWndAnimateTiles, "BufWndTileAnimation", nullptr);
	}

	TBufferedWindow::~TBufferedWindow()
	{
		BufWndTileAnimation.Running = false;

		for (auto& buf : TileBuffers)
		{
			delete buf;
			buf = nullptr;
		}

		TileBuffers.clear();
	}

	TTileBuffer* TBufferedWindow::AddBuffer(int layerCount, int cols, int rows)
	{
		TTileBuffer* buf = new TTileBuffer(layerCount, cols, rows);
		TileBuffers.push_back(buf);
		return buf;
	}

	void TBufferedWindow::RemoveBuffer(int index)
	{
		if (index >= 0 && index < TileBuffers.size())
		{
			delete TileBuffers[index];
			TileBuffers[index] = nullptr;
			TileBuffers.erase(TileBuffers.begin() + index);
		}
	}

	TTileBuffer* TBufferedWindow::GetBuffer(int index)
	{
		return index >= 0 && index < TileBuffers.size() ? TileBuffers[index] : nullptr;
	}

	TCharset* TBufferedWindow::GetCharset()
	{
		return Chr;
	}

	TPalette* TBufferedWindow::GetPalette()
	{
		return Pal;
	}

	void TBufferedWindow::SetCharset(TCharset* chr)
	{
		Chr = chr;
	}

	void TBufferedWindow::SetPalette(TPalette* pal)
	{
		Pal = pal;
	}

	int TBufferedWindow::GetCols()
	{
		return Cols;
	}

	int TBufferedWindow::GetRows()
	{
		return Rows;
	}

	void TBufferedWindow::SetAnimationSpeed(int speed)
	{
		if (speed < 0)
			speed = 0;
		else if (speed > BufWndTileAnimation.MaxSpeed)
			speed = BufWndTileAnimation.MaxSpeed;

		BufWndTileAnimation.Speed = speed;
	}

	void TBufferedWindow::EnableAnimation(bool enable)
	{
		BufWndTileAnimation.Enabled = enable;
		BufWndTileAnimation.Frame = 0;
	}

	bool TBufferedWindow::IsAnimationEnabled()
	{
		return BufWndTileAnimation.Enabled;
	}

	void TBufferedWindow::Update()
	{
		ClearBackground();
		
		for (auto& buf : TileBuffers)
		{
			if (buf->View.Visible)
				DrawTileBuffer(buf);
		}

		TWindowBase::Update();
	}

	void TBufferedWindow::SetPixel(int x, int y, RGB rgb)
	{
		FillRect(x, y, PixelWidth, PixelHeight, rgb);
	}

	void TBufferedWindow::DrawTile(TTile& tile, int x, int y, bool transparent)
	{
		DrawTile(tile.Char, tile.ForeColor, tile.BackColor, x, y, transparent);
	}

	void TBufferedWindow::DrawTile(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg, int x, int y, bool transparent)
	{
		x *= TChar::Width;
		y *= TChar::Height;

		const TChar& charPixels = Chr->Get(ch);
		const RGB fgRGB = Pal->GetColorRGB(fg);
		const RGB bgRGB = Pal->GetColorRGB(bg);

		DrawByteAsPixels(charPixels.PixelRow0, x, y++, fgRGB, bgRGB, transparent);
		DrawByteAsPixels(charPixels.PixelRow1, x, y++, fgRGB, bgRGB, transparent);
		DrawByteAsPixels(charPixels.PixelRow2, x, y++, fgRGB, bgRGB, transparent);
		DrawByteAsPixels(charPixels.PixelRow3, x, y++, fgRGB, bgRGB, transparent);
		DrawByteAsPixels(charPixels.PixelRow4, x, y++, fgRGB, bgRGB, transparent);
		DrawByteAsPixels(charPixels.PixelRow5, x, y++, fgRGB, bgRGB, transparent);
		DrawByteAsPixels(charPixels.PixelRow6, x, y++, fgRGB, bgRGB, transparent);
		DrawByteAsPixels(charPixels.PixelRow7, x, y++, fgRGB, bgRGB, transparent);
	}

	void TBufferedWindow::DrawByteAsPixels(byte value, int x, int y, PaletteIndex fg, PaletteIndex bg, bool transparent)
	{
		for (int pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			const int pixel = value & (1 << pos);
			if (pixel || !pixel && !transparent)
				SetPixel(x, y, pixel ? fg : bg);
		}
	}

	void TBufferedWindow::DrawTileBuffer(TTileBuffer* buf)
	{
		BufWndTileAnimation.CachedFrame = BufWndTileAnimation.Frame;

		for (int layer = 0; layer < buf->LayerCount; layer++) {
			if (!buf->IsLayerVisible(layer))
				continue;

			for (int y = 0; y < buf->View.Rows; y++) {
				for (int x = 0; x < buf->View.Cols; x++) {
					TTileSeq& tileSeq = buf->GetTile(layer, buf->View.ScrollX + x, buf->View.ScrollY + y);

					TTile* tile = nullptr;
					if (tileSeq.IsEmpty())
						continue;
					if (tileSeq.GetSize() == 1)
						tile = &tileSeq.First();
					else
						tile = &tileSeq.Get(BufWndTileAnimation.CachedFrame % tileSeq.GetSize());

					DrawTile(*tile, buf->View.X + x, buf->View.Y + y, buf->IsTileTransparent(layer, x, y));
				}
			}
		}
	}
}
