/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include <Windows.h>
#include <SDL_syswm.h>
#include "TWindow.h"
#include "TChar.h"
#include "TCharset.h"
#include "TPalette.h"
#include "TPixelBlock.h"

namespace TileGameLib
{
	TWindow::TWindow(int wScr, int hScr, int wWnd, int hWnd, bool fullscreen, bool hidden) :
		ScreenWidth(wScr), ScreenHeight(hScr), 
		WindowWidth(wWnd), WindowHeight(hWnd),
		Cols(wScr / TChar::Width), Rows(hScr / TChar::Height),
		PixelFormat(SDL_PIXELFORMAT_ARGB8888),
		BufferLength(sizeof(int) * wScr * hScr),
		Chr(TCharset::Default), Pal(TPalette::Default),
		BackColor(0), PixelWidth(1), PixelHeight(1)
	{
		Buffer = new int[BufferLength];
		Clear();

		SDL_Init(SDL_INIT_VIDEO);
		SDL_SetHint(SDL_HINT_RENDER_DRIVER, "direct3d");
		SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "nearest");

		Window = SDL_CreateWindow("",
			SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED,
			WindowWidth, WindowHeight, fullscreen ? SDL_WINDOW_FULLSCREEN_DESKTOP : SDL_WINDOW_HIDDEN);

		Renderer = SDL_CreateRenderer(Window, -1,
			SDL_RENDERER_PRESENTVSYNC | SDL_RENDERER_ACCELERATED | SDL_RENDERER_TARGETTEXTURE);

		SDL_SetRenderDrawBlendMode(Renderer, SDL_BLENDMODE_NONE);
		SDL_RenderSetLogicalSize(Renderer, WindowWidth, WindowHeight);

		Scrtx = SDL_CreateTexture(Renderer,
			PixelFormat, SDL_TEXTUREACCESS_STREAMING, ScreenWidth, ScreenHeight);

		SDL_SetTextureBlendMode(Scrtx, SDL_BLENDMODE_NONE);

		SDL_SetWindowPosition(Window, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED);
		SDL_RaiseWindow(Window);
		Update();

		if (!hidden)
			Show();
	}

	TWindow::TWindow(int wScr, int hScr, int zoom, bool fullscreen, bool hidden) :
		TWindow(wScr, hScr, zoom * wScr, zoom * hScr, fullscreen, hidden)
	{
	}

	TWindow::~TWindow()
	{
		SDL_DestroyTexture(Scrtx);
		SDL_DestroyRenderer(Renderer);
		SDL_DestroyWindow(Window);
		SDL_Quit();

		delete[] Buffer;
	}

	void* TWindow::GetHandle()
	{
		SDL_SysWMinfo wmInfo;
		SDL_VERSION(&wmInfo.version);
		SDL_GetWindowWMInfo(Window, &wmInfo);
		return wmInfo.info.win.window;
	}

	void TWindow::Hide()
	{
		SDL_HideWindow(Window);
	}

	void TWindow::Show()
	{
		SDL_ShowWindow(Window);
	}

	void TWindow::SetFullscreen(bool full)
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;

		if ((full && isFullscreen) || (!full && !isFullscreen))
			return;

		SDL_SetWindowFullscreen(Window, full ? fullscreenFlag : 0);
		SDL_ShowCursor(isFullscreen);
	}

	void TWindow::ToggleFullscreen()
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;
		SDL_SetWindowFullscreen(Window, isFullscreen ? 0 : fullscreenFlag);
		SDL_ShowCursor(isFullscreen);
	}

	void TWindow::SetTitle(std::string title)
	{
		SDL_SetWindowTitle(Window, title.c_str());
	}

	void TWindow::SetBordered(bool bordered)
	{
		SDL_SetWindowBordered(Window, bordered ? SDL_TRUE : SDL_FALSE);
	}

	void TWindow::SetIcon(std::string iconfile)
	{
		SDL_Surface icon;
		SDL_LoadBMP(iconfile.c_str());
		SDL_SetWindowIcon(Window, &icon);
		SDL_FreeSurface(&icon);
	}

	void TWindow::SetPixelSize(int wPix, int hPix)
	{
		PixelWidth = wPix;
		PixelHeight = hPix;
	}

	void TWindow::SaveScreenshot(std::string file)
	{
		SDL_Surface* surface = SDL_CreateRGBSurfaceWithFormat(0, ScreenWidth, ScreenHeight, 32, PixelFormat);
		SDL_memcpy(surface->pixels, Buffer, BufferLength);
		SDL_SaveBMP(surface, file.c_str());
		SDL_FreeSurface(surface);
	}

	int TWindow::GetPixelWidth()
	{
		return PixelWidth;
	}

	int TWindow::GetPixelHeight()
	{
		return PixelHeight;
	}

	TCharset* TWindow::GetCharset()
	{
		return Chr;
	}

	TPalette* TWindow::GetPalette()
	{
		return Pal;
	}

	void TWindow::SetBackColor(int bgcix)
	{
		BackColor = bgcix;
	}

	void TWindow::Update()
	{
		static int pitch;
		static void* pixels;

		SDL_LockTexture(Scrtx, nullptr, &pixels, &pitch);
		SDL_memcpy(pixels, Buffer, BufferLength);
		SDL_UnlockTexture(Scrtx);
		SDL_RenderCopy(Renderer, Scrtx, nullptr, nullptr);
		SDL_RenderPresent(Renderer);
	}

	void TWindow::Clear()
	{
		ClearToRGB(Pal->GetColorRGB(BackColor));
	}

	void TWindow::ClearToRGB(int rgb)
	{
		for (int y = 0; y < ScreenHeight; y++)
			for (int x = 0; x < ScreenWidth; x++)
				Buffer[y * ScreenWidth + x] = rgb;
	}

	void TWindow::SetPixel(int x, int y, int rgb)
	{
		if (PixelWidth == 1 && PixelHeight == 1) {
			if (x >= 0 && y >= 0 && x < ScreenWidth && y < ScreenHeight)
				Buffer[y * ScreenWidth + x] = rgb;
		}
		else {
			int px = x * PixelWidth;
			int py = y * PixelHeight;
			const int prevX = px;
			for (int iy = 0; iy < PixelHeight; iy++) {
				for (int ix = 0; ix < PixelWidth; ix++) {
					if (px >= 0 && py >= 0 && px < ScreenWidth && py < ScreenHeight) {
						Buffer[py * ScreenWidth + px] = rgb;
					}
					px++;
				}
				px = prevX;
				py++;
			}
		}
	}

	void TWindow::EraseTile(int x, int y, bool snap)
	{
		if (snap) {
			x *= TChar::Width;
			y *= TChar::Height;
		}

		for (int py = y; py < y + TChar::Height; py++) {
			for (int px = x; px < x + TChar::Width; px++) {
				SetPixel(px, py, Pal->GetColorRGB(BackColor));
			}
		}
	}

	void TWindow::DrawTile(int chix, int fgcix, int bgcix, int x, int y, bool transparent, bool snap)
	{
		if (snap) {
			x *= TChar::Width;
			y *= TChar::Height;
		}

		const int initialX = x;
		TChar& ch = Chr->Get(chix);
		int fgc = Pal->GetColorRGB(fgcix);
		int bgc = Pal->GetColorRGB(bgcix);
		int pos;

		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow0 & (1 << pos);
			if (pixel || !pixel && !transparent)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow1 & (1 << pos);
			if (pixel || !pixel && !transparent)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow2 & (1 << pos);
			if (pixel || !pixel && !transparent)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow3 & (1 << pos);
			if (pixel || !pixel && !transparent)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow4 & (1 << pos);
			if (pixel || !pixel && !transparent)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow5 & (1 << pos);
			if (pixel || !pixel && !transparent)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow6 & (1 << pos);
			if (pixel || !pixel && !transparent)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow7 & (1 << pos);
			if (pixel || !pixel && !transparent)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
	}

	void TWindow::DrawTileString(std::string str, int fgcix, int bgcix, int x, int y, bool transparent, bool snap)
	{
		for (int i = 0; i < str.length(); i++) {
			DrawTile(str[i], fgcix, bgcix, x, y, transparent, snap);
			if (snap)
				x++;
			else
				x += TChar::Width;
		}
	}

	void TWindow::DrawPixelBlock(TPixelBlock* pixels, int x, int y)
	{
		int ix = 0;
		for (int py = y; py < y + pixels->Height; py++) {
			for (int px = x; px < x + pixels->Width; px++) {
				int& color = pixels->Colors[ix++];
				if (color >= 0)
					SetPixel(px, py, Pal->GetColorRGB(color));
			}
		}
	}
}
