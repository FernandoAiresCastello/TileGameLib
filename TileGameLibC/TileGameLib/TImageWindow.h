/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include "TGlobal.h"

namespace TileGameLib
{
	class TTiledImage;

	class TImageWindow
	{
	public:
		TImageWindow(int width, int height);
		~TImageWindow();

		void Update();
		void Hide();
		void Show();
		void DrawImageTile(TTiledImage* timg, int tix, int x, int y);

	private:
		RGB* Buffer;
		RGB BackColor;
		SDL_Window* Window;
		SDL_Renderer* Renderer;
		SDL_Texture* Scrtx;
		const int PixelFormat;
		const int BufferLength;
		const int Width;
		const int Height;

		void ClearBackground();
		void ClearToRGB(RGB rgb);
		void SetPixel(int x, int y, RGB rgb);
		RGB GetPixel(int x, int y);
	};
}
