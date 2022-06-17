/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include "TGlobal.h"

namespace TileGameLib
{
	class TWindowBase
	{
	public:
		TWindowBase(int width, int height);
		virtual ~TWindowBase();

		void* GetHandle();
		virtual void Update();
		void Hide();
		void Show();
		void SetFullscreen(bool full);
		void ToggleFullscreen();
		void SetTitle(std::string title);
		void SetBordered(bool bordered);
		void SetIcon(std::string iconfile);
		void SaveScreenshot(std::string file);
		void SetBackColor(PaletteIndex bg);
		int GetBackColor();

	protected:
		RGB* Buffer;
		RGB BackColor;
		SDL_Window* Window;
		SDL_Renderer* Renderer;
		SDL_Texture* Scrtx;
		const int BufferLength;
		const int Width;
		const int Height;

		void ClearBackground();
		void ClearToRGB(RGB rgb);
		virtual void SetPixel(int x, int y, RGB rgb);
		virtual RGB GetPixel(int x, int y);
	};
}
