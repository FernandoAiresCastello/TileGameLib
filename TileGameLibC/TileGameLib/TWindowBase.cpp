/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include <string>
#include <SDL_syswm.h>
#include "TWindowBase.h"

namespace TileGameLib
{
	TWindowBase::TWindowBase(int width, int height) :
		Width(width), Height(height), BufferLength(sizeof(int) * width * height)
	{
		Buffer = new RGB[BufferLength];
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
			SDL_PIXELFORMAT_ARGB8888, SDL_TEXTUREACCESS_STREAMING, Width, Height);

		SDL_SetTextureBlendMode(Scrtx, SDL_BLENDMODE_NONE);
		SDL_SetWindowPosition(Window, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED);
	}

	TWindowBase::~TWindowBase()
	{
		SDL_DestroyTexture(Scrtx);
		SDL_DestroyRenderer(Renderer);
		SDL_DestroyWindow(Window);
		SDL_VideoQuit();

		delete[] Buffer;
	}

	void* TWindowBase::GetHandle()
	{
		SDL_SysWMinfo wmInfo;
		SDL_VERSION(&wmInfo.version);
		SDL_GetWindowWMInfo(Window, &wmInfo);
		return wmInfo.info.win.window;
	}

	void TWindowBase::Update()
	{
		static int pitch;
		static void* pixels;

		SDL_LockTexture(Scrtx, nullptr, &pixels, &pitch);
		SDL_memcpy(pixels, Buffer, BufferLength);
		SDL_UnlockTexture(Scrtx);
		SDL_RenderCopy(Renderer, Scrtx, nullptr, nullptr);
		SDL_RenderPresent(Renderer);
	}

	void TWindowBase::Hide()
	{
		SDL_HideWindow(Window);
	}

	void TWindowBase::Show()
	{
		SDL_ShowWindow(Window);
		Update();
		SDL_RaiseWindow(Window);
	}

	void TWindowBase::ClearBackground()
	{
		ClearToRGB( BackColor);
	}

	void TWindowBase::ClearToRGB(RGB rgb)
	{
		for (int y = 0; y < Height; y++)
			for (int x = 0; x < Width; x++)
				Buffer[y * Width + x] = rgb;
	}

	void TWindowBase::SetPixel(int x, int y, RGB rgb)
	{
		if (x >= 0 && y >= 0 && x < Width && y < Height) {
			Buffer[y * Width + x] = rgb;
		}
	}

	void TWindowBase::FillRect(int x, int y, int w, int h, RGB rgb)
	{
		int px = x * w;
		int py = y * h;
		const int prevX = px;
		for (int iy = 0; iy < w; iy++) {
			for (int ix = 0; ix < h; ix++) {
				if (px >= 0 && py >= 0 && px < Width && py < Height) {
					Buffer[py * Width + px] = rgb;
				}
				px++;
			}
			px = prevX;
			py++;
		}
	}

	RGB TWindowBase::GetPixel(int x, int y)
	{
		return Buffer[y * Width + x];
	}

	void TWindowBase::SetFullscreen(bool full)
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;

		if ((full && isFullscreen) || (!full && !isFullscreen))
			return;

		SDL_SetWindowFullscreen(Window, full ? fullscreenFlag : 0);
		SDL_ShowCursor(isFullscreen);
		Update();
	}

	void TWindowBase::ToggleFullscreen()
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;
		SDL_SetWindowFullscreen(Window, isFullscreen ? 0 : fullscreenFlag);
		SDL_ShowCursor(isFullscreen);
		Update();
	}

	void TWindowBase::SetTitle(std::string title)
	{
		SDL_SetWindowTitle(Window, title.c_str());
	}

	void TWindowBase::SetBordered(bool bordered)
	{
		SDL_SetWindowBordered(Window, bordered ? SDL_TRUE : SDL_FALSE);
	}

	void TWindowBase::SetIcon(std::string iconfile)
	{
		SDL_Surface icon;
		SDL_LoadBMP(iconfile.c_str());
		SDL_SetWindowIcon(Window, &icon);
		SDL_FreeSurface(&icon);
	}

	void TWindowBase::SaveScreenshot(std::string file)
	{
		SDL_Surface* surface = SDL_CreateRGBSurfaceWithFormat(0, Width, Height, 32, SDL_PIXELFORMAT_ARGB8888);
		SDL_memcpy(surface->pixels, Buffer, BufferLength);
		SDL_SaveBMP(surface, file.c_str());
		SDL_FreeSurface(surface);
	}

	void TWindowBase::SetBackColor(RGB rgb)
	{
		BackColor = rgb;
	}

	RGB TWindowBase::GetBackColor()
	{
		return BackColor;
	}
}
