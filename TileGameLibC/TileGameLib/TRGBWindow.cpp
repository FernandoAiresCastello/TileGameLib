/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#include "TRGBWindow.h"
#include "TChar.h"

struct {
	const int MaxSpeed = 1000;
	int Speed = 700;
	bool Running = false;
	bool Enabled = true;
	unsigned long long Frame = 0;
	unsigned long long CachedFrame = 0;
}
RgbWndTileAnimation;

int RgbWndAnimateTiles(void* dummy)
{
	RgbWndTileAnimation.Running = true;

	while (RgbWndTileAnimation.Running) {
		if (RgbWndTileAnimation.Enabled)
			RgbWndTileAnimation.Frame++;

		const int delay = abs(RgbWndTileAnimation.Speed - RgbWndTileAnimation.MaxSpeed);
		if (delay)
			SDL_Delay(delay);
	}

	return 0;
}

namespace TileGameLib
{
	TRGBWindow::TRGBWindow(int cols, int rows, int layerCount, int pixelWidth, int pixelHeight) :
		TWindowBase(cols * (TChar::Width * pixelWidth), rows * (TChar::Height * pixelHeight)),
		Cols(cols), Rows(rows), PixelWidth(pixelWidth), PixelHeight(pixelHeight),
		HorizontalResolution(cols* TChar::Width), VerticalResolution(rows* TChar::Height)
	{
		SDL_CreateThread(RgbWndAnimateTiles, "RgbWndAnimateTiles", nullptr);
	}

	TRGBWindow::~TRGBWindow()
	{
		RgbWndTileAnimation.Running = false;
	}

	void TRGBWindow::Update()
	{
		RgbWndTileAnimation.CachedFrame = RgbWndTileAnimation.Frame;
		TWindowBase::Update();
	}

	int TRGBWindow::GetAnimationFrameIndex()
	{
		return RgbWndTileAnimation.CachedFrame;
	}

	void TRGBWindow::DrawPixels(std::string& pixels, RGB c0, RGB c1, RGB c2, RGB c3, bool ignoreC0, bool alignToGrid, int x, int y)
	{
		if (alignToGrid)
		{
			x *= TChar::Width;
			y *= TChar::Height;
		}

		RGB color;
		int px = x;
		int py = y;

		for (auto& pixel : pixels)
		{
			if (pixel == '1') color = c1;
			else if (pixel == '2') color = c2;
			else if (pixel == '3') color = c3;
			else color = c0;

			if (!ignoreC0 || (ignoreC0 && color != c0))
				SetPixel(px, py, color);

			px++;
			if (px >= x + TChar::Width)
			{
				py++;
				px = x;
			}
		}
	}

	void TRGBWindow::SetPixel(int x, int y, RGB rgb)
	{
		FillRect(x, y, PixelWidth, PixelHeight, rgb);
	}
}
