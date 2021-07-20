/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "Graphics.h"
#include "Charset.h"
#include "Char.h"
#include "Palette.h"
#include "File.h"

namespace TBRLGPT
{
	Graphics::Graphics(int screenWidth, int screenHeight, int windowWidth, int windowHeight, bool fullscreen) :
		PixelFormat(SDL_PIXELFORMAT_ARGB8888),
		ScreenWidth(screenWidth), ScreenHeight(screenHeight),
		BufferLength(sizeof(int) * screenWidth * screenHeight),
		WindowWidth(windowWidth), WindowHeight(windowHeight),
		Cols(screenWidth / Char::Width), Rows(screenHeight / Char::Height)
	{
		Buffer = new int[BufferLength];

		Init("", fullscreen);
		Clear(0);
		Update();
	}

	Graphics::~Graphics()
	{
		Dispose();

		delete[] Buffer;
	}

	void Graphics::Init(std::string title, bool fullscreen)
	{
		SDL_Init(SDL_INIT_EVERYTHING);
		SDL_SetHint(SDL_HINT_RENDER_DRIVER, "direct3d");
		SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "nearest");

		Window = SDL_CreateWindow(title.c_str(),
			SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED,
			WindowWidth, WindowHeight, fullscreen ? SDL_WINDOW_FULLSCREEN_DESKTOP : 0);

		Renderer = SDL_CreateRenderer(Window, -1,
			SDL_RENDERER_PRESENTVSYNC || SDL_RENDERER_ACCELERATED || SDL_RENDERER_TARGETTEXTURE);

		SDL_RenderSetLogicalSize(Renderer, ScreenWidth, ScreenHeight);

		ScreenTexture = SDL_CreateTexture(Renderer,
			PixelFormat, SDL_TEXTUREACCESS_STREAMING, ScreenWidth, ScreenHeight);

		SDL_SetWindowPosition(Window, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED);
		SDL_RaiseWindow(Window);
	}

	void Graphics::Dispose()
	{
		SDL_DestroyTexture(ScreenTexture);
		SDL_DestroyRenderer(Renderer);
		SDL_DestroyWindow(Window);
		SDL_Quit();
	}

	void Graphics::SetFullscreen(bool full)
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;
		
		if ((full && isFullscreen) || (!full && !isFullscreen))
			return;

		SDL_SetWindowFullscreen(Window, full ? fullscreenFlag : 0);
		SDL_ShowCursor(isFullscreen);
	}

	void Graphics::ToggleFullscreen()
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;
		SDL_SetWindowFullscreen(Window, isFullscreen ? 0 : fullscreenFlag);
		SDL_ShowCursor(isFullscreen);
	}

	void Graphics::SetWindowTitle(std::string title)
	{
		SDL_SetWindowTitle(Window, title.c_str());
	}

	void Graphics::SetWindowBordered(bool bordered)
	{
		SDL_SetWindowBordered(Window, bordered ? SDL_TRUE : SDL_FALSE);
	}

	void Graphics::SetWindowIcon(std::string iconfile)
	{
		SDL_Surface icon;
		SDL_LoadBMP(iconfile.c_str());
		SDL_SetWindowIcon(Window, &icon);
		SDL_FreeSurface(&icon);
	}

	bool Graphics::WindowClosed()
	{
		static SDL_Event windowClosedEvent = { 0 };
		SDL_PollEvent(&windowClosedEvent);
		return windowClosedEvent.type == SDL_QUIT;
	}

	void Graphics::SaveScreenshot(std::string file)
	{
		file += ".bmp";
		if (!File::Exists(file))
			File::Create(file);

		SDL_Surface* surface = SDL_CreateRGBSurfaceWithFormat(0, ScreenWidth, ScreenHeight, 32, PixelFormat);
		SDL_memcpy(surface->pixels, Buffer, BufferLength);
		SDL_SaveBMP(surface, file.c_str());
		SDL_FreeSurface(surface);
	}

	void Graphics::Update()
	{
		static int pitch;
		static void* pixels;

		SDL_LockTexture(ScreenTexture, NULL, &pixels, &pitch);
		SDL_memcpy(pixels, Buffer, BufferLength);
		SDL_UnlockTexture(ScreenTexture);
		SDL_RenderCopy(Renderer, ScreenTexture, NULL, NULL);
		SDL_RenderPresent(Renderer);
	}

	void Graphics::Clear(int color)
	{
		for (int y = 0; y < ScreenHeight; y++)
			for (int x = 0; x < ScreenWidth; x++)
				SetPixel(x, y, color);
	}

	void Graphics::ClearTile(int x, int y, int color)
	{
		int tx = x * Char::Width;
		int ty = y * Char::Height;

		for (int y = ty; y < ty + Char::Height; y++)
			for (int x = tx; x < tx + Char::Width; x++)
				SetPixel(x, y, color);
	}

	void Graphics::ClearRow(int row, int color)
	{
		for (int x = 0; x < Cols; x++)
			ClearTile(x, row, color);
	}

	void Graphics::ClearRows(int first, int last, int color)
	{
		for (int row = first; row <= last; row++)
			ClearRow(row, color);
	}

	void Graphics::ClearRect(int x, int y, int w, int h, int color)
	{
		for (int px = x; px < x + w; px++)
			for (int py = y; py < y + h; py++)
				ClearTile(px, py, color);
	}

	void Graphics::SetPixel(int x, int y, int color)
	{
		if (x >= 0 && y >= 0 && x < ScreenWidth && y < ScreenHeight)
			Buffer[y * ScreenWidth + x] = color;
	}

	void Graphics::Fill(Charset* charset, int index, int forecolor, int backcolor)
	{
		for (int y = 0; y < ScreenHeight; y++)
			for (int x = 0; x < ScreenWidth; x++)
				PutChar(charset, index, x, y, forecolor, backcolor);
	}

	void Graphics::PutChar(Charset* charset, int index, int x, int y, int forecolor, int backcolor)
	{
		DrawChar(charset, index, x * Char::Width, y * Char::Height, forecolor, backcolor);
	}

	void Graphics::DrawChar(Charset* charset, int index, int x, int y, int forecolor, int backcolor)
	{
		Char& ch = charset->Get(index);
		const int initialX = x;

		for (int pos = Char::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow0 & (1 << pos)) ? forecolor : backcolor);
		x = initialX; y++;
		for (int pos = Char::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow1 & (1 << pos)) ? forecolor : backcolor);
		x = initialX; y++;
		for (int pos = Char::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow2 & (1 << pos)) ? forecolor : backcolor);
		x = initialX; y++;
		for (int pos = Char::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow3 & (1 << pos)) ? forecolor : backcolor);
		x = initialX; y++;
		for (int pos = Char::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow4 & (1 << pos)) ? forecolor : backcolor);
		x = initialX; y++;
		for (int pos = Char::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow5 & (1 << pos)) ? forecolor : backcolor);
		x = initialX; y++;
		for (int pos = Char::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow6 & (1 << pos)) ? forecolor : backcolor);
		x = initialX; y++;
		for (int pos = Char::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow7 & (1 << pos)) ? forecolor : backcolor);
	}

	void Graphics::Print(Charset* charset, int x, int y, int forecolor, int backcolor, std::string str)
	{
		unsigned i = 0;
		while (true) {
			if (i >= str.size())
				break;

			PutChar(charset, str[i++], x++, y, forecolor, backcolor);
		}
	}
}
