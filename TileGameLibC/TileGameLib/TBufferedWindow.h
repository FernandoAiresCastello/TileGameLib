/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <map>
#include <string>
#include <vector>
#include <CppUtils.h>
#include "TGlobal.h"
#include "TTile.h"
#include "TTileSeq.h"
#include "TTileBuffer.h"

using byte = CppUtils::byte;

namespace TileGameLib
{
	class TCharset;
	class TPalette;

	class TBufferedWindow
	{
	public:
		const int LayerCount;
		const int Cols;
		const int Rows;
		const int LastCol;
		const int LastRow;
		const int PixelWidth;
		const int PixelHeight;
		const int Width;
		const int Height;

		TBufferedWindow(int layerCount, int cols, int rows, int pixelWidth, int pixelHeight);
		~TBufferedWindow();

		void* GetHandle();
		TCharset* GetCharset();
		TPalette* GetPalette();
		TTileBuffer* GetBuffer();
		void Hide();
		void Show();
		int GetCols();
		int GetRows();
		void SetFullscreen(bool full);
		void ToggleFullscreen();
		void SetTitle(std::string title);
		void SetBordered(bool bordered);
		void SetIcon(std::string iconfile);
		void SaveScreenshot(std::string file);
		void SetBackColor(PaletteIndex bg);
		int GetBackColor();
		void SetAnimationSpeed(int speed);
		void EnableAnimation(bool enable);
		bool IsAnimationEnabled();
		void Update();

	private:
		RGB* Buffer;
		SDL_Window* Window;
		SDL_Renderer* Renderer;
		SDL_Texture* Scrtx;
		TCharset* Chr;
		TPalette* Pal;
		PaletteIndex BackColor;
		const int PixelFormat;
		const int BufferLength;
		TTileBuffer* TileBuf;

		TBufferedWindow(const TBufferedWindow& other) = delete;

		void ClearBackground();
		void ClearToRGB(RGB rgb);
		void SetPixel(int x, int y, RGB rgb);
		RGB GetPixel(int x, int y);
		void DrawTile(TTile& tile, int x, int y, bool transparent);
		void DrawTile(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg, int x, int y, bool transparent);
		void DrawByteAsPixels(byte value, int x, int y, PaletteIndex fg, PaletteIndex bg, bool transparent);
		void DrawTileBuffer();
	};
}
