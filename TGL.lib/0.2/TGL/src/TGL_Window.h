#pragma once
#include <SDL.h>
#include "TGL_Globals.h"
#include "TGL_String.h"
#include "TGL_Rgb.h"
#include "TGL_Color.h"

namespace TGL
{
	class TGL_Image;

	class TGLAPI TGL_Window
	{
	public:
		const TGL_Color DefaultBackColor = 0xffffff;

		TGL_Window();
		~TGL_Window();

		void Open(int width, int height, const TGL_Color& backColor, bool show);
		void Open(int width, int height, int sizeMult, const TGL_Color& backColor, bool show);
		void Open(int width, int height, int widthMult, int heightMult, const TGL_Color& backColor, bool show);
		void Close();
		void WaitClose();
		void Show();
		void Hide();
		void ClearBackground();
		void ClearToColor(const TGL_Color& color);
		void Update();
		bool IsOpen() const;
		void SetFullscreen(bool full);
		void ToggleFullscreen();
		bool IsFullscreen() const;
		void SetBordered(bool bordered);
		void SetTitle(const TGL_String& title);
		void SetIcon(const TGL_String& iconfile);
		void SaveScreenshot(const TGL_String& file) const;
		void SetBackColor(const TGL_Color& color);
		TGL_Color GetBackColor() const;
		void SetPixelRgb(int x, int y, TGL_Rgb rgb);
		void SetPixel(int x, int y, const TGL_Color& color);
		void FillRect(int x, int y, int w, int h, const TGL_Color& color);
		TGL_Rgb GetPixelRgb(int x, int y);
		TGL_Color GetPixel(int x, int y);
		void DrawImage(TGL_Image* img, int x, int y);

	private:
		SDL_Window* Window = nullptr;
		SDL_Renderer* Renderer = nullptr;
		SDL_Texture* Texture = nullptr;
		TGL_Rgb* Buffer = nullptr;
		TGL_Color BackColor = 0x000000;
		int BufferLength = 0;
		int Width = 0;
		int Height = 0;
		bool IsCreated = false;
		bool IsVisible = false;
		TGL_String Title;
	};
}
