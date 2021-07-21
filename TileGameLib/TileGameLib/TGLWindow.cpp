/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TGLWindow.h"
#include "TGLChar.h"

namespace TileGameLib
{
	TGLWindow::TGLWindow(int wScr, int hScr, int wWnd, int hWnd, bool fullscreen) :
		ScreenWidth(wScr), ScreenHeight(hScr), 
		WindowWidth(wWnd), WindowHeight(hWnd),
		Cols(wScr / TGLChar::Width), Rows(hScr / TGLChar::Height),
		PixelFormat(SDL_PIXELFORMAT_ARGB8888),
		BufferLength(sizeof(int) * wScr * hScr)
	{
		Buffer = new int[BufferLength];
		Clear(0);
		PremultiplyGridPositions();

		SDL_Init(SDL_INIT_EVERYTHING);
		SDL_SetHint(SDL_HINT_RENDER_DRIVER, "direct3d");
		SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "nearest");

		Window = SDL_CreateWindow("",
			SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED,
			WindowWidth, WindowHeight, fullscreen ? SDL_WINDOW_FULLSCREEN_DESKTOP : 0);

		Renderer = SDL_CreateRenderer(Window, -1,
			SDL_RENDERER_PRESENTVSYNC | SDL_RENDERER_ACCELERATED | SDL_RENDERER_TARGETTEXTURE);

		SDL_RenderSetLogicalSize(Renderer, ScreenWidth, ScreenHeight);

		Scrtx = SDL_CreateTexture(Renderer,
			PixelFormat, SDL_TEXTUREACCESS_STREAMING, ScreenWidth, ScreenHeight);

		Update();

		SDL_SetWindowPosition(Window, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED);
		SDL_RaiseWindow(Window);
	}

	TGLWindow::TGLWindow(int wScr, int hScr, int zoom, bool fullscreen) :
		TGLWindow(wScr, hScr, zoom * wScr, zoom * hScr, fullscreen)
	{
	}

	TGLWindow::~TGLWindow()
	{
		SDL_DestroyTexture(Scrtx);
		SDL_DestroyRenderer(Renderer);
		SDL_DestroyWindow(Window);
		SDL_Quit();

		delete[] Buffer;
	}

	void TGLWindow::SetFullscreen(bool full)
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;

		if ((full && isFullscreen) || (!full && !isFullscreen))
			return;

		SDL_SetWindowFullscreen(Window, full ? fullscreenFlag : 0);
		SDL_ShowCursor(isFullscreen);
	}

	void TGLWindow::ToggleFullscreen()
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;
		SDL_SetWindowFullscreen(Window, isFullscreen ? 0 : fullscreenFlag);
		SDL_ShowCursor(isFullscreen);
	}

	void TGLWindow::SetTitle(std::string title)
	{
		SDL_SetWindowTitle(Window, title.c_str());
	}

	void TGLWindow::SetBordered(bool bordered)
	{
		SDL_SetWindowBordered(Window, bordered ? SDL_TRUE : SDL_FALSE);
	}

	void TGLWindow::SetIcon(std::string iconfile)
	{
		SDL_Surface icon;
		SDL_LoadBMP(iconfile.c_str());
		SDL_SetWindowIcon(Window, &icon);
		SDL_FreeSurface(&icon);
	}

	void TGLWindow::SaveScreenshot(std::string file)
	{
		SDL_Surface* surface = SDL_CreateRGBSurfaceWithFormat(0, ScreenWidth, ScreenHeight, 32, PixelFormat);
		SDL_memcpy(surface->pixels, Buffer, BufferLength);
		SDL_SaveBMP(surface, file.c_str());
		SDL_FreeSurface(surface);
	}

	void TGLWindow::Update()
	{
		static int pitch;
		static void* pixels;

		SDL_LockTexture(Scrtx, nullptr, &pixels, &pitch);
		SDL_memcpy(pixels, Buffer, BufferLength);
		SDL_UnlockTexture(Scrtx);
		SDL_RenderCopy(Renderer, Scrtx, nullptr, nullptr);
		SDL_RenderPresent(Renderer);
	}

	void TGLWindow::DrawChar(TGLCharset* chars, TGLPalette* pal,
		TGLCharsetIndex chrix, TGLPaletteIndex fgcix, TGLPaletteIndex bgcix, int x, int y)
	{
		static GridPosition* grid;
		grid = &GridPositions[y][x];
		x = grid->X;
		y = grid->Y;

		const int initialX = x;
		TGLChar& ch = chars->Get(chrix);
		TGLColorRGB fgc = pal->GetColorRGB(fgcix);
		TGLColorRGB bgc = pal->GetColorRGB(bgcix);

		for (int pos = TGLChar::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow0 & (1 << pos)) ? fgc : bgc);
		x = initialX; y++;
		for (int pos = TGLChar::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow1 & (1 << pos)) ? fgc : bgc);
		x = initialX; y++;
		for (int pos = TGLChar::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow2 & (1 << pos)) ? fgc : bgc);
		x = initialX; y++;
		for (int pos = TGLChar::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow3 & (1 << pos)) ? fgc : bgc);
		x = initialX; y++;
		for (int pos = TGLChar::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow4 & (1 << pos)) ? fgc : bgc);
		x = initialX; y++;
		for (int pos = TGLChar::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow5 & (1 << pos)) ? fgc : bgc);
		x = initialX; y++;
		for (int pos = TGLChar::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow6 & (1 << pos)) ? fgc : bgc);
		x = initialX; y++;
		for (int pos = TGLChar::Width - 1; pos >= 0; pos--, x++)
			SetPixel(x, y, (ch.PixelRow7 & (1 << pos)) ? fgc : bgc);
	}

	void TGLWindow::Clear(TGLColorRGB rgb)
	{
		for (int y = 0; y < ScreenHeight; y++)
			for (int x = 0; x < ScreenWidth; x++)
				Buffer[y * ScreenWidth + x] = rgb;
	}

	void TGLWindow::SetPixel(int x, int y, TGLColorRGB rgb)
	{
		if (x >= 0 && y >= 0 && x < ScreenWidth && y < ScreenHeight)
			Buffer[y * ScreenWidth + x] = rgb;
	}

	void TGLWindow::PremultiplyGridPositions()
	{
		for (int y = 0; y < Rows; y++) {
			std::vector<GridPosition> row;
			for (int x = 0; x < Cols; x++) {
				row.push_back({ x * TGLChar::Width, y * TGLChar::Height });
			}
			GridPositions.push_back(row);
		}
	}
}
