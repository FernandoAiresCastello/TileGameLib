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
	TWindow::TWindow(int wScr, int hScr, int wWnd, int hWnd) :
		ScreenWidth(wScr), ScreenHeight(hScr), 
		WindowWidth(wWnd), WindowHeight(hWnd),
		Cols(0), Rows(0),
		PixelFormat(SDL_PIXELFORMAT_ARGB8888),
		BufferLength(sizeof(int) * wScr * hScr),
		Chr(TCharset::Default), Pal(TPalette::Default),
		BackColor(0), PixelWidth(1), PixelHeight(1),
		ClipX1(0), ClipY1(0), ClipX2(wScr), ClipY2(hScr)
	{
		Buffer = new int[BufferLength];
		Clear();
		CalculateColsRows();

		SDL_Init(SDL_INIT_VIDEO);
		SDL_SetHint(SDL_HINT_RENDER_DRIVER, "direct3d");
		SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "nearest");

		Window = SDL_CreateWindow("",
			SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED,
			WindowWidth, WindowHeight, SDL_WINDOW_HIDDEN);

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
	}


	TWindow::~TWindow()
	{
		SDL_DestroyTexture(Scrtx);
		SDL_DestroyRenderer(Renderer);
		SDL_DestroyWindow(Window);
		SDL_Quit();

		delete[] Buffer;
	}

	TWindow* TWindow::CreateWithAbsoluteSize(int wScr, int hScr)
	{
		return new TWindow(wScr, hScr, wScr, hScr);
	}

	TWindow* TWindow::CreateWithAbsoluteSizeStretched(int wScr, int hScr, int wWnd, int hWnd)
	{
		return new TWindow(wScr, hScr, wWnd, hWnd);
	}

	TWindow* TWindow::CreateWithAbsoluteSizeZoomed(int wScr, int hScr, int sizeMultiplier)
	{
		return new TWindow(wScr, hScr, wScr * sizeMultiplier, hScr * sizeMultiplier);
	}

	TWindow* TWindow::CreateWithPixelSizeAndTileGrid(int wPix, int hPix, int cols, int rows)
	{
		const int wScr = cols * TChar::Width * wPix;
		const int hScr = rows * TChar::Height * hPix;

		auto wnd = new TWindow(wScr, hScr, wScr, hScr);
		
		wnd->SetPixelSize(wPix, hPix);

		return wnd;
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

	int TWindow::GetCols()
	{
		return Cols;
	}

	int TWindow::GetRows()
	{
		return Rows;
	}

	int TWindow::GetLastCol()
	{
		return GetCols() - 1;
	}

	int TWindow::GetLastRow()
	{
		return GetRows() - 1;
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
		CalculateColsRows();
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

	int TWindow::GetBackColor()
	{
		return BackColor;
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
			x += ClipX1;
			y += ClipY1;
			if (x - ClipX1 >= 0 && y - ClipY1 >= 0 && x < ClipX2 && y < ClipY2) {
				Buffer[y * ScreenWidth + x] = rgb;
			}
		}
		else {
			int px = x * PixelWidth + ClipX1;
			int py = y * PixelHeight + ClipY1;
			const int prevX = px;
			for (int iy = 0; iy < PixelHeight; iy++) {
				for (int ix = 0; ix < PixelWidth; ix++) {
					if (px - ClipX1 >= 0 && py - ClipY1 >= 0 && px < ClipX2 && py < ClipY2) {
						Buffer[py * ScreenWidth + px] = rgb;
					}
					px++;
				}
				px = prevX;
				py++;
			}
		}
	}

	void TWindow::CalculateColsRows()
	{
		Cols = ScreenWidth / (TChar::Width * PixelWidth);
		Rows = ScreenHeight / (TChar::Height * PixelHeight);
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

	void TWindow::SetClip(int x1, int y1, int x2, int y2)
	{
		if (x1 < 0) x1 = 0;
		if (y1 < 0) y1 = 0;
		if (x2 > ScreenWidth) x2 = ScreenWidth;
		if (y2 > ScreenHeight) y2 = ScreenHeight;

		ClipX1 = x1;
		ClipY1 = y1;
		ClipX2 = x2;
		ClipY2 = y2;
	}

	void TWindow::FillClip(int rgb)
	{
		for (int y = ClipY1; y < ClipY2; y++)
			for (int x = ClipX1; x < ClipX2; x++)
				Buffer[y * ScreenWidth + x] = rgb;
	}

	void TWindow::RemoveClip()
	{
		SetClip(0, 0, ScreenWidth, ScreenHeight);
	}
}
