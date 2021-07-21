/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include <tuple>
#include "TGLGlobal.h"
#include "TGLClass.h"
#include "TGLCharset.h"
#include "TGLPalette.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TGLWindow : TGLClass
	{
	public:
		const int ScreenWidth;
		const int ScreenHeight;
		const int WindowWidth;
		const int WindowHeight;
		const int Cols;
		const int Rows;

		TGLWindow(int wScr, int hScr, int wWnd, int hWnd, bool fullscreen);
		TGLWindow(int wScr, int hScr, int zoom, bool fullscreen);
		TGLWindow(const TGLWindow& other) = delete;
		~TGLWindow();

		void SetFullscreen(bool full);
		void ToggleFullscreen();
		void SetTitle(std::string title);
		void SetBordered(bool bordered);
		void SetIcon(std::string iconfile);
		void SaveScreenshot(std::string file);
		void Update();
		void DrawChar(TGLCharset* chars, TGLPalette* pal, 
			TGLCharsetIndex chrix, TGLPaletteIndex fgcix, TGLPaletteIndex bgcix, int x, int y);

	private:
		int* Buffer;
		SDL_Window* Window;
		SDL_Renderer* Renderer;
		SDL_Texture* Scrtx;
		const int PixelFormat;
		const int BufferLength;

		struct GridPosition {
			int X;
			int Y;
		};

		std::vector<std::vector<GridPosition>> GridPositions;

		void Clear(TGLColorRGB rgb);
		void SetPixel(int x, int y, TGLColorRGB rgb);
		void PremultiplyGridPositions();
	};
}
