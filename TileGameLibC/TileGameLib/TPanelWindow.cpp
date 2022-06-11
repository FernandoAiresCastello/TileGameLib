/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include <Windows.h>
#include <SDL_syswm.h>
#include "TPanelWindow.h"
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
	TPanelWindow::TPanelWindow() : TPanelWindow(DefaultWidth, DefaultHeight)
	{
	}

	TPanelWindow::TPanelWindow(int width, int height) :
		Width(width), Height(height),
		PixelFormat(SDL_PIXELFORMAT_ARGB8888),
		BufferLength(sizeof(int) * width * height),
		Chr(TCharset::Default), Pal(TPalette::Default),
		BackColor(0), PixelWidth(1), PixelHeight(1),
		Clip({ 0, 0, width, height }), Grid(false), TransparentTiles(false)
	{
		Buffer = new RGB[BufferLength];
		
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
		
		SDL_CreateThread(AnimateTiles, "TileAnimation", nullptr);
	}

	TPanelWindow::~TPanelWindow()
	{
		TileAnimation.Running = false;

		DestroyAllPanels();

		SDL_DestroyTexture(Scrtx);
		SDL_DestroyRenderer(Renderer);
		SDL_DestroyWindow(Window);
		SDL_VideoQuit();

		delete[] Buffer;
	}

	void* TPanelWindow::GetHandle()
	{
		SDL_SysWMinfo wmInfo;
		SDL_VERSION(&wmInfo.version);
		SDL_GetWindowWMInfo(Window, &wmInfo);
		return wmInfo.info.win.window;
	}

	TCharset* TPanelWindow::GetCharset()
	{
		return Chr;
	}

	TPalette* TPanelWindow::GetPalette()
	{
		return Pal;
	}

	int TPanelWindow::GetWidth()
	{
		return Width;
	}

	int TPanelWindow::GetHeight()
	{
		return Height;
	}

	void TPanelWindow::Hide()
	{
		SDL_HideWindow(Window);
	}

	void TPanelWindow::Show()
	{
		SDL_ShowWindow(Window);
		Update();
		SDL_RaiseWindow(Window);
	}

	void TPanelWindow::SetFullscreen(bool full)
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;

		if ((full && isFullscreen) || (!full && !isFullscreen))
			return;

		SDL_SetWindowFullscreen(Window, full ? fullscreenFlag : 0);
		SDL_ShowCursor(isFullscreen);
		Update();
	}

	void TPanelWindow::ToggleFullscreen()
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;
		SDL_SetWindowFullscreen(Window, isFullscreen ? 0 : fullscreenFlag);
		SDL_ShowCursor(isFullscreen);
		Update();
	}

	void TPanelWindow::SetTitle(std::string title)
	{
		SDL_SetWindowTitle(Window, title.c_str());
	}

	void TPanelWindow::SetBordered(bool bordered)
	{
		SDL_SetWindowBordered(Window, bordered ? SDL_TRUE : SDL_FALSE);
	}

	void TPanelWindow::SetIcon(std::string iconfile)
	{
		SDL_Surface icon;
		SDL_LoadBMP(iconfile.c_str());
		SDL_SetWindowIcon(Window, &icon);
		SDL_FreeSurface(&icon);
	}

	void TPanelWindow::SaveScreenshot(std::string file)
	{
		SDL_Surface* surface = SDL_CreateRGBSurfaceWithFormat(0, Width, Height, 32, PixelFormat);
		SDL_memcpy(surface->pixels, Buffer, BufferLength);
		SDL_SaveBMP(surface, file.c_str());
		SDL_FreeSurface(surface);
	}

	void TPanelWindow::SetBackColor(PaletteIndex bg)
	{
		BackColor = bg;
	}

	int TPanelWindow::GetBackColor()
	{
		return BackColor;
	}

	TRegion TPanelWindow::GetBounds()
	{
		return TRegion(0, 0, Width, Height);
	}

	TPanel* TPanelWindow::AddPanel()
	{
		TPanel* panel = new TPanel(this, TRegion(0, 0, Width, Height));
		Panels.push_back(panel);
		return panel;
	}

	void TPanelWindow::RemovePanel(TPanel* panel)
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

	void TPanelWindow::DestroyAllPanels()
	{
		for (auto& panel : Panels) {
			delete panel;
			panel = nullptr;
		}
		Panels.clear();
	}

	int TPanelWindow::GetPanelCount()
	{
		return Panels.size();
	}

	void TPanelWindow::SetAnimationSpeed(int speed)
	{
		if (speed < 0)
			speed = 0;
		else if (speed > TileAnimation.MaxSpeed)
			speed = TileAnimation.MaxSpeed;

		TileAnimation.Speed = speed;
	}

	void TPanelWindow::EnableAnimation(bool enable)
	{
		TileAnimation.Enabled = enable;
		TileAnimation.Frame = 0;
	}

	bool TPanelWindow::IsAnimationEnabled()
	{
		return TileAnimation.Enabled;
	}

	void TPanelWindow::Update()
	{
		ClearBackground();

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

	void TPanelWindow::ClearBackground()
	{
		ClearToRGB(Pal->GetColorRGB(BackColor));
	}

	void TPanelWindow::ClearToRGB(RGB rgb)
	{
		for (int y = 0; y < Height; y++)
			for (int x = 0; x < Width; x++)
				Buffer[y * Width + x] = rgb;
	}

	void TPanelWindow::ClearAllPanels()
	{
		for (auto& panel : Panels)
			panel->Clear();
	}

	void TPanelWindow::SetPixel(int x, int y, RGB rgb)
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

	RGB TPanelWindow::GetPixel(int x, int y)
	{
		return Buffer[y * Width + x];
	}

	void TPanelWindow::SetPixelSize(int w, int h)
	{
		PixelWidth = w;
		PixelHeight = h;
	}

	void TPanelWindow::DrawTile(TTile& tile, int x, int y)
	{
		DrawTile(tile.Char, tile.ForeColor, tile.BackColor, x, y);
	}

	void TPanelWindow::DrawTile(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg, int x, int y)
	{
		if (Grid) {
			x *= TChar::Width;
			y *= TChar::Height;
		}

		const TChar& charPixels = Chr->Get(ch);
		const RGB fgRGB = Pal->GetColorRGB(fg);
		const RGB bgRGB = Pal->GetColorRGB(bg);

		DrawByteAsPixels(charPixels.PixelRow0, x, y++, fgRGB, bgRGB);
		DrawByteAsPixels(charPixels.PixelRow1, x, y++, fgRGB, bgRGB);
		DrawByteAsPixels(charPixels.PixelRow2, x, y++, fgRGB, bgRGB);
		DrawByteAsPixels(charPixels.PixelRow3, x, y++, fgRGB, bgRGB);
		DrawByteAsPixels(charPixels.PixelRow4, x, y++, fgRGB, bgRGB);
		DrawByteAsPixels(charPixels.PixelRow5, x, y++, fgRGB, bgRGB);
		DrawByteAsPixels(charPixels.PixelRow6, x, y++, fgRGB, bgRGB);
		DrawByteAsPixels(charPixels.PixelRow7, x, y++, fgRGB, bgRGB);
	}

	void TPanelWindow::DrawTileString(std::string str, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y)
	{
		for (int i = 0; i < str.length(); i++) {
			DrawTile(str[i], fgcix, bgcix, x, y);
			if (Grid)
				x++;
			else
				x += TChar::Width;
		}
	}

	void TPanelWindow::DrawByteAsPixels(byte value, int x, int y, PaletteIndex fg, PaletteIndex bg)
	{
		for (int pos = TChar::Width - 1; pos >= 0; pos--, x++) {
			const int pixel = value & (1 << pos);
			if (pixel || !pixel && !TransparentTiles)
				SetPixel(x, y, pixel ? fg : bg);
		}
	}

	void TPanelWindow::DrawVisiblePanels()
	{
		for (auto& panel : Panels) {
			if (panel->Visible)
				DrawPanel(panel);
		}
	}

	void TPanelWindow::DrawPanel(TPanel* panel)
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

	void TPanelWindow::SetClip(int x1, int y1, int x2, int y2)
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

	void TPanelWindow::FillClip(PaletteIndex ix)
	{
		for (int y = Clip.Y1; y < Clip.Y2; y++)
			for (int x = Clip.X1; x < Clip.X2; x++)
				Buffer[y * Width + x] = Pal->GetColorRGB(ix);
	}

	void TPanelWindow::RemoveClip()
	{
		SetClip(0, 0, Width, Height);
	}

	void TPanelWindow::DrawImage(TImage* img, int x, int y, int pw, int ph)
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

	void TPanelWindow::EraseImage(TImage* img, int x, int y, int pw, int ph)
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
