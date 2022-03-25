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
		PixelFormat(SDL_PIXELFORMAT_ARGB8888),
		LayerCount(layerCount), Cols(cols), Rows(rows), LastCol(cols - 1), LastRow(rows - 1),
		PixelWidth(pixelWidth), PixelHeight(pixelHeight),
		Width(cols * (TChar::Width * pixelWidth)), Height(rows * (TChar::Height * pixelHeight)),
		BufferLength(sizeof(int) * Width * Height)
	{
		TileBuf = new TTileBuffer(layerCount, cols, rows);
		Buffer = new RGB[BufferLength];
		Chr = TCharset::Default;
		Pal = TPalette::Default;
		BackColor = 0;

		ClearBackground();

		SDL_Init(SDL_INIT_VIDEO);
		SDL_SetHint(SDL_HINT_RENDER_DRIVER, "direct3d");
		SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "nearest");

		Window = SDL_CreateWindow("",
			SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED,
			Width, Height, SDL_WINDOW_HIDDEN);

		Renderer = SDL_CreateRenderer(Window, -1,
			SDL_RENDERER_PRESENTVSYNC | SDL_RENDERER_ACCELERATED | SDL_RENDERER_TARGETTEXTURE);

		SDL_SetRenderDrawBlendMode(Renderer, SDL_BLENDMODE_NONE);
		SDL_RenderSetLogicalSize(Renderer, Width, Height);

		Scrtx = SDL_CreateTexture(Renderer,
			PixelFormat, SDL_TEXTUREACCESS_STREAMING, Width, Height);

		SDL_SetTextureBlendMode(Scrtx, SDL_BLENDMODE_NONE);
		SDL_SetWindowPosition(Window, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED);

		SDL_CreateThread(BufWndAnimateTiles, "BufWndTileAnimation", nullptr);
	}

	TBufferedWindow::~TBufferedWindow()
	{
		BufWndTileAnimation.Running = false;

		SDL_DestroyTexture(Scrtx);
		SDL_DestroyRenderer(Renderer);
		SDL_DestroyWindow(Window);
		SDL_VideoQuit();

		delete[] Buffer;
		delete TileBuf;
	}

	void* TBufferedWindow::GetHandle()
	{
		SDL_SysWMinfo wmInfo;
		SDL_VERSION(&wmInfo.version);
		SDL_GetWindowWMInfo(Window, &wmInfo);
		return wmInfo.info.win.window;
	}

	TCharset* TBufferedWindow::GetCharset()
	{
		return Chr;
	}

	TPalette* TBufferedWindow::GetPalette()
	{
		return Pal;
	}

	TTileBuffer* TBufferedWindow::GetBuffer()
	{
		return TileBuf;
	}

	int TBufferedWindow::GetCols()
	{
		return Cols;
	}

	int TBufferedWindow::GetRows()
	{
		return Rows;
	}

	void TBufferedWindow::Hide()
	{
		SDL_HideWindow(Window);
	}

	void TBufferedWindow::Show()
	{
		SDL_ShowWindow(Window);
		Update();
		SDL_RaiseWindow(Window);
	}

	void TBufferedWindow::SetFullscreen(bool full)
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;

		if ((full && isFullscreen) || (!full && !isFullscreen))
			return;

		SDL_SetWindowFullscreen(Window, full ? fullscreenFlag : 0);
		SDL_ShowCursor(isFullscreen);
		Update();
	}

	void TBufferedWindow::ToggleFullscreen()
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;
		SDL_SetWindowFullscreen(Window, isFullscreen ? 0 : fullscreenFlag);
		SDL_ShowCursor(isFullscreen);
		Update();
	}

	void TBufferedWindow::SetTitle(std::string title)
	{
		SDL_SetWindowTitle(Window, title.c_str());
	}

	void TBufferedWindow::SetBordered(bool bordered)
	{
		SDL_SetWindowBordered(Window, bordered ? SDL_TRUE : SDL_FALSE);
	}

	void TBufferedWindow::SetIcon(std::string iconfile)
	{
		SDL_Surface icon;
		SDL_LoadBMP(iconfile.c_str());
		SDL_SetWindowIcon(Window, &icon);
		SDL_FreeSurface(&icon);
	}

	void TBufferedWindow::SaveScreenshot(std::string file)
	{
		SDL_Surface* surface = SDL_CreateRGBSurfaceWithFormat(0, Width, Height, 32, PixelFormat);
		SDL_memcpy(surface->pixels, Buffer, BufferLength);
		SDL_SaveBMP(surface, file.c_str());
		SDL_FreeSurface(surface);
	}

	void TBufferedWindow::SetBackColor(PaletteIndex bg)
	{
		BackColor = bg;
	}

	int TBufferedWindow::GetBackColor()
	{
		return BackColor;
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
		DrawTileBuffer();

		static int pitch;
		static void* pixels;

		SDL_LockTexture(Scrtx, nullptr, &pixels, &pitch);
		SDL_memcpy(pixels, Buffer, BufferLength);
		SDL_UnlockTexture(Scrtx);
		SDL_RenderCopy(Renderer, Scrtx, nullptr, nullptr);
		SDL_RenderPresent(Renderer);
	}

	void TBufferedWindow::ClearBackground()
	{
		ClearToRGB(Pal->GetColorRGB(BackColor));
	}

	void TBufferedWindow::ClearToRGB(RGB rgb)
	{
		for (int y = 0; y < Height; y++)
			for (int x = 0; x < Width; x++)
				Buffer[y * Width + x] = rgb;
	}

	void TBufferedWindow::SetPixel(int x, int y, RGB rgb)
	{
		int px = x * PixelWidth;
		int py = y * PixelHeight;
		const int prevX = px;
		for (int iy = 0; iy < PixelHeight; iy++) {
			for (int ix = 0; ix < PixelWidth; ix++) {
				if (px >= 0 && py >= 0 && px < Width && py < Height) {
					Buffer[py * Width + px] = rgb;
				}
				px++;
			}
			px = prevX;
			py++;
		}
	}

	RGB TBufferedWindow::GetPixel(int x, int y)
	{
		return Buffer[y * Width + x];
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

	void TBufferedWindow::DrawTileBuffer()
	{
		BufWndTileAnimation.CachedFrame = BufWndTileAnimation.Frame;

		for (int layer = 0; layer < LayerCount; layer++) {
			if (!TileBuf->IsLayerVisible(layer))
				continue;

			for (int y = 0; y < Rows; y++) {
				for (int x = 0; x < Cols; x++) {
					TTileSeq& tileSeq = TileBuf->GetTile(layer, x, y);
					TTile* tile = nullptr;
					if (tileSeq.IsEmpty())
						continue;
					if (tileSeq.GetSize() == 1)
						tile = &tileSeq.First();
					else
						tile = &tileSeq.Get(BufWndTileAnimation.CachedFrame % tileSeq.GetSize());

					DrawTile(*tile, x, y, TileBuf->IsTileTransparent(layer, x, y));
				}
			}
		}
	}
}
