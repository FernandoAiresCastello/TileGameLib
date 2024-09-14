#pragma once
#include <SDL.h>
#include "TGL_Globals.h"
#include "TGL_String.h"
#include "TGL_Rgb.h"
#include "TGL_Color.h"

namespace TGL
{
	class Image;

	class TGLAPI Window
	{
	public:
		const Color DefaultBackColor = 0xffffff;

		Window();
		~Window();

		void Open(int width, int height, const Color& backColor, bool show);
		void Open(int width, int height, int sizeMult, const Color& backColor, bool show);
		void Open(int width, int height, int widthMult, int heightMult, const Color& backColor, bool show);
		void Close();
		void WaitClose();
		void Show();
		void Hide();
		void ClearBackground();
		void ClearToColor(const Color& color);
		void Update();
		bool IsOpen() const;
		void SetFullscreen(bool full);
		void ToggleFullscreen();
		bool IsFullscreen() const;
		void SetBordered(bool bordered);
		void SetTitle(const String& title);
		void SetIcon(const String& iconfile);
		void SaveScreenshot(const String& file) const;
		void SetBackColor(const Color& color);
		Color GetBackColor() const;
		void SetPixelRGB(int x, int y, RGB rgb);
		void SetPixel(int x, int y, const Color& color);
		void FillRect(int x, int y, int w, int h, const Color& color);
		RGB GetPixelRGB(int x, int y);
		Color GetPixel(int x, int y);
		void DrawImage(Image* img, int x, int y);

	private:
		SDL_Window* window = nullptr;
		SDL_Renderer* renderer = nullptr;
		SDL_Texture* texture = nullptr;
		RGB* buffer = nullptr;
		Color backColor = 0x000000;
		int bufferLength = 0;
		int width = 0;
		int height = 0;
		bool isCreated = false;
		bool isVisible = false;
		String title;
	};
}
