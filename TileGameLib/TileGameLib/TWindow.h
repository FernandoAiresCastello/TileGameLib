/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include <vector>
#include "TGlobal.h"

namespace TileGameLib
{
	class TCharset;
	class TPalette;

	class TWindow
	{
	public:
		const int ScreenWidth;
		const int ScreenHeight;
		const int WindowWidth;
		const int WindowHeight;
		const int Cols;
		const int Rows;

		TWindow(int wScr, int hScr, int wWnd, int hWnd, bool fullscreen);
		TWindow(int wScr, int hScr, int zoom, bool fullscreen);
		TWindow(const TWindow& other) = delete;
		~TWindow();

		void* GetHandle();
		void SetFullscreen(bool full);
		void ToggleFullscreen();
		void SetTitle(std::string title);
		void SetBordered(bool bordered);
		void SetIcon(std::string iconfile);
		void SaveScreenshot(std::string file);
		TCharset* GetCharset();
		TPalette* GetPalette();
		void SetBackColor(int bgcix);
		void Update();
		void Clear();
		void DrawTile(int chix, int fgcix, int bgcix, int x, int y);
		void DrawTileTransparent(int chix, int fgcix, int bgcix, int x, int y);

	private:
		int* Buffer;
		SDL_Window* Window;
		SDL_Renderer* Renderer;
		SDL_Texture* Scrtx;
		const int PixelFormat;
		const int BufferLength;
		TCharset* Chr;
		TPalette* Pal;
		int BackColor;

		void ClearToRGB(int rgb);
		void SetPixel(int x, int y, int rgb);
		void DrawTile(int chix, int fgcix, int bgcix, int x, int y, bool transparent);
	};
}
