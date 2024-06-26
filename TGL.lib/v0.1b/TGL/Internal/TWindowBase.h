#pragma once
#include <SDL.h>
#include <string>
#include "TGlobal.h"

namespace TGL_Internal
{
	class TWindowBase
	{
	public:
		const int Width;
		const int Height;

		TWindowBase(int width, int height, RGB backColor = 0x000000);
		virtual ~TWindowBase();

		void* GetHandle();
		SDL_Window* GetSDLWindow();
		virtual void Update();
		void Hide();
		void Show();
		void SetFullscreen(bool full);
		void ToggleFullscreen();
		bool IsFullscreen();
		void SetTitle(std::string title);
		void SetBordered(bool bordered);
		void SetIcon(std::string iconfile);
		void SaveScreenshot(std::string file);
		void SetBackColor(RGB rgb);
		RGB GetBackColor();
		virtual void ClearBackground();

	protected:
		RGB* Buffer;
		RGB BackColor;
		SDL_Window* Window;
		SDL_Renderer* Renderer;
		SDL_Texture* Scrtx;
		const int BufferLength;

		void ClearToRGB(RGB rgb);
		virtual void SetPixel(int x, int y, RGB rgb);
		virtual void FillRect(int x, int y, int w, int h, RGB rgb);
		virtual RGB GetPixel(int x, int y);
	};
}
