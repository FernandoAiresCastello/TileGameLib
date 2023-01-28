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

namespace TGL_Internal
{
	TRGBWindow::TRGBWindow(int cols, int rows, int pixelWidth, int pixelHeight, RGB backColor) :
		TWindowBase(cols * (TChar::Width * pixelWidth), rows * (TChar::Height * pixelHeight), backColor),
		Cols(cols), Rows(rows), PixelWidth(pixelWidth), PixelHeight(pixelHeight),
		HorizontalResolution(cols* TChar::Width), VerticalResolution(rows* TChar::Height)
	{
		RemoveClip();

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

	void TRGBWindow::ClearBackground()
	{
		if (HasClip())
		{
			for (int y = Clip.Y1; y <= Clip.Y2; y++)
				for (int x = Clip.X1; x <= Clip.X2; x++)
					SetPixel(x, y, BackColor);
		}
		else
		{
			TWindowBase::ClearBackground();
		}
	}

	int TRGBWindow::GetFrame()
	{
		return RgbWndTileAnimation.CachedFrame;
	}

	void TRGBWindow::DrawPixelBlock8x8(std::string& pixels, RGB c0, RGB c1, RGB c2, RGB c3, bool ignoreC0, int x, int y)
	{
		RGB color;
		int px = x;
		int py = y;
		bool hidePixel = false;

		for (auto& pixel : pixels)
		{
			if (HasClip())
				hidePixel = IsOutsideClip(px, py);

			if (!hidePixel)
			{
				if (pixel == '1') color = c1;
				else if (pixel == '2') color = c2;
				else if (pixel == '3') color = c3;
				else color = c0;

				if (!ignoreC0 || (ignoreC0 && color != c0))
					SetPixel(px, py, color);
			}

			px++;
			if (px >= x + TChar::Width)
			{
				py++;
				px = x;
			}
		}
	}

	void TRGBWindow::SetClip(int x1, int y1, int x2, int y2)
	{
		Clip.Set(x1, y1, x2, y2);
	}

	void TRGBWindow::RemoveClip()
	{
		SetClip(0, 0, 0, 0);
	}

	bool TRGBWindow::HasClip()
	{
		return !(Clip.X1 == 0 && Clip.Y1 == 0 && Clip.X2 == 0 && Clip.Y2 == 0);
	}

	bool TRGBWindow::IsInsideClip(int x, int y)
	{
		return x >= Clip.X1 && x <= Clip.X2 && y >= Clip.Y1 && y <= Clip.Y2;
	}

	bool TRGBWindow::IsOutsideClip(int x, int y)
	{
		return !IsInsideClip(x, y);
	}

	TRegion& TRGBWindow::GetClip()
	{
		return Clip;
	}

	void TRGBWindow::SetPixel(int x, int y, RGB rgb)
	{
		FillRect(x, y, PixelWidth, PixelHeight, rgb);
	}
}
