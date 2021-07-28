/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include <vector>
#include "TGlobal.h"
#include "TClass.h"

namespace TileGameLib
{
	class TCharset;
	class TPalette;
	class TTile;

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
		void ClearAt(TPalette* pal, TPaletteIndex ix, int x, int y);
		void ClearRect(TPalette* pal, TPaletteIndex ix, int x, int y, int w, int h);
		void DrawChar(TCharset* chars, TPalette* pal, 
			TCharsetIndex chrix, TPaletteIndex fgcix, TPaletteIndex bgcix, int x, int y);
		void DrawChars(TCharset* chars, TPalette* pal,
			std::vector<TCharsetIndex>& str, TPaletteIndex fgcix, TPaletteIndex bgcix, int x, int y);
		void DrawTile(TCharset* chars, TPalette* pal, TTile* tile, int x, int y);
		void DrawSpriteTile(TCharset* chars, TPalette* pal, TTile* tile, int x, int y);
		void DrawString(TCharset* chars, TPalette* pal,
			std::string str, TPaletteIndex fgcix, TPaletteIndex bgcix, int x, int y);

	private:
		int* Buffer;
		SDL_Window* Window;
		SDL_Renderer* Renderer;
		SDL_Texture* Scrtx;
		const int PixelFormat;
		const int BufferLength;

		struct TGridPosition { int X, Y; };
		std::vector<std::vector<TGridPosition>> Grid;

		void ClearToRGB(TColorRGB rgb);
		void SetPixel(int x, int y, TColorRGB rgb);
		void PremultiplyGrid();
	};
}
