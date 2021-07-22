/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include "TGlobal.h"
#include "TClass.h"
#include "TCharset.h"
#include "TPalette.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TWindow : TClass
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

		void SetFullscreen(bool full);
		void ToggleFullscreen();
		void SetTitle(std::string title);
		void SetBordered(bool bordered);
		void SetIcon(std::string iconfile);
		void SaveScreenshot(std::string file);
		void Update();
		void Clear(TPalette* pal, TPaletteIndex ix);
		void DrawChar(TCharset* chars, TPalette* pal, 
			TCharsetIndex chrix, TPaletteIndex fgcix, TPaletteIndex bgcix, int x, int y);
		void DrawString(TCharset* chars, TPalette* pal,
			std::string str, TPaletteIndex fgcix, TPaletteIndex bgcix, int x, int y);
		void DrawString(TCharset* chars, TPalette* pal,
			std::vector<int>& str, TPaletteIndex fgcix, TPaletteIndex bgcix, int x, int y);

	private:
		int* Buffer;
		SDL_Window* Window;
		SDL_Renderer* Renderer;
		SDL_Texture* Scrtx;
		const int PixelFormat;
		const int BufferLength;

		struct GridPosition { int X, Y; };
		std::vector<std::vector<GridPosition>> Grid;

		void ClearToRGB(TColorRGB rgb);
		void SetPixel(int x, int y, TColorRGB rgb);
		void PremultiplyGrid();
	};
}
