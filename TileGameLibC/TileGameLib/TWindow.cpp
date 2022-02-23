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
#include "TImage.h"
#include "TPanel.h"

struct {
	const int MaxSpeed = 1000;
	int Speed = 700;
	bool Running = false;
	bool Enabled = true;
	unsigned long long Frame = 0;
	unsigned long long CachedFrame = 0;
}
TileAnimation;

int AnimateTiles(void* dummy)
{
	TileAnimation.Running = true;

	while (TileAnimation.Running) {
		if (TileAnimation.Enabled)
			TileAnimation.Frame++;
		
		const int delay = abs(TileAnimation.Speed - TileAnimation.MaxSpeed);
		if (delay)
			SDL_Delay(delay);
	}

	return 0;
}

namespace TileGameLib
{
	TWindow::TWindow() : TWindow(DefaultWidth, DefaultHeight)
	{
	}

	TWindow::TWindow(int width, int height) :
		Width(width), Height(height),
		PixelFormat(SDL_PIXELFORMAT_ARGB8888),
		BufferLength(sizeof(int) * width * height),
		Chr(TCharset::Default), Pal(TPalette::Default),
		BackColor(0), PixelWidth(1), PixelHeight(1),
		Clip({ 0, 0, width, height }), Grid(false), TransparentTiles(false)
	{
		Buffer = new RGB[BufferLength];
		Clear();

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
		
		SDL_CreateThread(AnimateTiles, "TileAnimation", nullptr);
	}

	TWindow::~TWindow()
	{
		TileAnimation.Running = false;

		DestroyAllPanels();

		SDL_DestroyTexture(Scrtx);
		SDL_DestroyRenderer(Renderer);
		SDL_DestroyWindow(Window);
		SDL_VideoQuit();

		delete[] Buffer;
	}

	void* TWindow::GetHandle()
	{
		SDL_SysWMinfo wmInfo;
		SDL_VERSION(&wmInfo.version);
		SDL_GetWindowWMInfo(Window, &wmInfo);
		return wmInfo.info.win.window;
	}

	TCharset* TWindow::GetCharset()
	{
		return Chr;
	}

	TPalette* TWindow::GetPalette()
	{
		return Pal;
	}

	int TWindow::GetWidth()
	{
		return Width;
	}

	int TWindow::GetHeight()
	{
		return Height;
	}

	void TWindow::Hide()
	{
		SDL_HideWindow(Window);
	}

	void TWindow::Show()
	{
		SDL_ShowWindow(Window);
		Update();
		SDL_RaiseWindow(Window);
	}

	void TWindow::SetFullscreen(bool full)
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;

		if ((full && isFullscreen) || (!full && !isFullscreen))
			return;

		SDL_SetWindowFullscreen(Window, full ? fullscreenFlag : 0);
		SDL_ShowCursor(isFullscreen);
		Update();
	}

	void TWindow::ToggleFullscreen()
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;
		SDL_SetWindowFullscreen(Window, isFullscreen ? 0 : fullscreenFlag);
		SDL_ShowCursor(isFullscreen);
		Update();
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

	void TWindow::SaveScreenshot(std::string file)
	{
		SDL_Surface* surface = SDL_CreateRGBSurfaceWithFormat(0, Width, Height, 32, PixelFormat);
		SDL_memcpy(surface->pixels, Buffer, BufferLength);
		SDL_SaveBMP(surface, file.c_str());
		SDL_FreeSurface(surface);
	}

	void TWindow::SetBackColor(PaletteIndex bgcix)
	{
		BackColor = bgcix;
	}

	int TWindow::GetBackColor()
	{
		return BackColor;
	}

	TPanel* TWindow::AddPanel()
	{
		TPanel* panel = new TPanel(TRegion(0, 0, Width, Height));
		Panels.push_back(panel);
		return panel;
	}

	void TWindow::RemovePanel(TPanel* panel)
	{
		int ixRemove = -1;

		for (auto& ownedPanel : Panels) {
			ixRemove++;
			if (panel == ownedPanel) {
				delete panel;
				panel = nullptr;
				break;
			}
		}

		if (ixRemove >= 0)
			Panels.erase(Panels.begin() + ixRemove);
	}

	void TWindow::MaximizePanel(TPanel* panel)
	{
		panel->SetBounds(0, 0, Width, Height);
	}

	void TWindow::ClearAllPanels()
	{
		for (auto& panel : Panels)
			panel->Clear();
	}

	void TWindow::DestroyAllPanels()
	{
		for (auto& panel : Panels) {
			delete panel;
			panel = nullptr;
		}
		Panels.clear();
	}

	int TWindow::GetPanelCount()
	{
		return Panels.size();
	}

	void TWindow::SetAnimationSpeed(int speed)
	{
		if (speed < 0)
			speed = 0;
		else if (speed > TileAnimation.MaxSpeed)
			speed = TileAnimation.MaxSpeed;

		TileAnimation.Speed = speed;
	}

	void TWindow::EnableAnimation(bool enable)
	{
		TileAnimation.Enabled = enable;
		TileAnimation.Frame = 0;
	}

	bool TWindow::IsAnimationEnabled()
	{
		return TileAnimation.Enabled;
	}

	void TWindow::Update()
	{
		if (!Panels.empty())
			DrawVisiblePanels();

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
		ClearAllPanels();
		ClearToRGB(Pal->GetColorRGB(BackColor));
	}

	void TWindow::ClearToRGB(RGB rgb)
	{
		for (int y = 0; y < Height; y++)
			for (int x = 0; x < Width; x++)
				Buffer[y * Width + x] = rgb;
	}

	void TWindow::SetPixel(int x, int y, RGB rgb)
	{
		if (PixelWidth == 1 && PixelHeight == 1) {
			x += Clip.X1;
			y += Clip.Y1;
			if (x - Clip.X1 >= 0 && y - Clip.Y1 >= 0 && x < Clip.X2 && y < Clip.Y2) {
				Buffer[y * Width + x] = rgb;
			}
		}
		else {
			int px = x * PixelWidth + Clip.X1;
			int py = y * PixelHeight + Clip.Y1;
			const int prevX = px;
			for (int iy = 0; iy < PixelHeight; iy++) {
				for (int ix = 0; ix < PixelWidth; ix++) {
					if (px - Clip.X1 >= 0 && py - Clip.Y1 >= 0 && px < Clip.X2 && py < Clip.Y2) {
						Buffer[py * Width + px] = rgb;
					}
					px++;
				}
				px = prevX;
				py++;
			}
		}
	}

	void TWindow::SetPixelSize(int w, int h)
	{
		PixelWidth = w;
		PixelHeight = h;
	}

	void TWindow::EraseTile(int x, int y)
	{
		if (Grid) {
			x *= TChar::Width;
			y *= TChar::Height;
		}

		for (int py = y; py < y + TChar::Height; py++)
			for (int px = x; px < x + TChar::Width; px++)
				SetPixel(px, py, Pal->GetColorRGB(BackColor));
	}

	void TWindow::DrawTile(TTile& tile, int x, int y)
	{
		DrawTile(tile.Char, tile.ForeColor, tile.BackColor, x, y);
	}

	void TWindow::DrawTile(CharsetIndex chix, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y)
	{
		if (Grid) {
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
			if (pixel || !pixel && !TransparentTiles)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow1 & (1 << pos);
			if (pixel || !pixel && !TransparentTiles)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow2 & (1 << pos);
			if (pixel || !pixel && !TransparentTiles)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow3 & (1 << pos);
			if (pixel || !pixel && !TransparentTiles)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow4 & (1 << pos);
			if (pixel || !pixel && !TransparentTiles)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow5 & (1 << pos);
			if (pixel || !pixel && !TransparentTiles)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow6 & (1 << pos);
			if (pixel || !pixel && !TransparentTiles)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
		x = initialX; y++;
		for (pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			int pixel = ch.PixelRow7 & (1 << pos);
			if (pixel || !pixel && !TransparentTiles)
				SetPixel(x, y, pixel ? fgc : bgc);
		}
	}

	void TWindow::DrawTileString(std::string str, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y)
	{
		for (int i = 0; i < str.length(); i++) {
			DrawTile(str[i], fgcix, bgcix, x, y);
			if (Grid)
				x++;
			else
				x += TChar::Width;
		}
	}

	void TWindow::DrawPanel(TPanel* panel)
	{
		if (!panel->Visible)
			return;

		TileAnimation.CachedFrame = TileAnimation.Frame;

		TRegion bounds = panel->GetBounds();

		SetClip(bounds.X1, bounds.Y1, bounds.X2, bounds.Y2);
		FillClip(panel->GetBackColor());

		for (auto& rtile : panel->GetTiles()) {
			Grid = rtile.AlignedToGrid;
			TransparentTiles = rtile.Transparent;
			SetPixelSize(rtile.PixelWidth, rtile.PixelHeight);

			TTile* tile = nullptr;
			if (rtile.TileSeq.IsEmpty())
				continue;
			if (rtile.TileSeq.GetSize() == 1)
				tile = &rtile.TileSeq.First();
			else
				tile = &rtile.TileSeq.Get(TileAnimation.CachedFrame % rtile.TileSeq.GetSize());
			
			DrawTile(*tile, rtile.X + panel->GetScrollX(), rtile.Y + panel->GetScrollY());
		}

		RemoveClip();
	}

	void TWindow::DrawVisiblePanels()
	{
		for (auto& panel : Panels) {
			if (panel->Visible)
				DrawPanel(panel);
		}
	}

	void TWindow::SetClip(int x1, int y1, int x2, int y2)
	{
		if (x1 < 0) x1 = 0;
		if (y1 < 0) y1 = 0;
		if (x2 > Width) x2 = Width;
		if (y2 > Height) y2 = Height;

		Clip.X1 = x1;
		Clip.Y1 = y1;
		Clip.X2 = x2;
		Clip.Y2 = y2;
	}

	void TWindow::FillClip(PaletteIndex ix)
	{
		for (int y = Clip.Y1; y < Clip.Y2; y++)
			for (int x = Clip.X1; x < Clip.X2; x++)
				Buffer[y * Width + x] = Pal->GetColorRGB(ix);
	}

	void TWindow::RemoveClip()
	{
		SetClip(0, 0, Width, Height);
	}

	void TWindow::DrawImage(TImage* img, int x, int y, int pw, int ph)
	{
		PixelWidth = pw;
		PixelHeight = ph;

		const int prevX = x;

		for (int iy = 0; iy < img->GetHeight(); iy++) {
			for (int ix = 0; ix < img->GetWidth(); ix++) {
				TColor& color = img->GetPixel(ix, iy);
				if (img->IsTransparent() && color.Equals(img->GetTransparency()))
					x++;
				else
					SetPixel(x++, y, color.ToColorRGB());
			}
			y++;
			x = prevX;
		}
	}

	void TWindow::EraseImage(TImage* img, int x, int y, int pw, int ph)
	{
		PixelWidth = pw;
		PixelHeight = ph;

		const int prevX = x;

		for (int iy = 0; iy < img->GetHeight(); iy++) {
			for (int ix = 0; ix < img->GetWidth(); ix++) {
				SetPixel(x++, y, Pal->GetColorRGB(BackColor));
			}
			y++;
			x = prevX;
		}
	}
}
