/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include "TGlobal.h"
#include "TRegion.h"

namespace TileGameLib
{
	class TCharset;
	class TPalette;
	class TPixelBlock;

	class TWindow
	{
	public:
		TWindow();
		TWindow(int width, int height);
		~TWindow();

		void* GetHandle();
		TCharset* GetCharset();
		TPalette* GetPalette();
		int GetWidth();
		int GetHeight();
		void Hide();
		void Show();
		void SetFullscreen(bool full);
		void ToggleFullscreen();
		void SetTitle(std::string title);
		void SetBordered(bool bordered);
		void SetIcon(std::string iconfile);
		void SaveScreenshot(std::string file);
		void SetBackColor(PaletteIndex bgcix);
		int GetBackColor();
		void Update();
		void Clear();

	private:
		friend class TPanel;

		const int Width;
		const int Height;
		const int PixelFormat;
		const int BufferLength;

		RGB* Buffer;
		SDL_Window* Window;
		SDL_Renderer* Renderer;
		SDL_Texture* Scrtx;
		TCharset* Chr;
		TPalette* Pal;
		PaletteIndex BackColor;
		int PixelWidth;
		int PixelHeight;
		TRegion Clip;
		bool Grid;
		bool TransparentTiles;

		TWindow(const TWindow& other) = delete;
		
		void ClearToRGB(RGB rgb);
		void SetPixel(int x, int y, RGB rgb);
		void SetPixelSize(int w, int h);
		void SetClip(int x1, int y1, int x2, int y2);
		void FillClip(PaletteIndex ix);
		void RemoveClip();
		void EraseTile(int x, int y);
		void DrawTile(CharsetIndex chix, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y);
		void DrawTileString(std::string str, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y);
		void DrawPixelBlock(TPixelBlock* pixels, int x, int y);
	};
}
