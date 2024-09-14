#pragma once
#include <SDL.h>
#include "TGL_Globals.h"
#include "TGL_String.h"
#include "TGL_Rgb.h"
#include "TGL_Color.h"
#include "TGL_Rect.h"
#include "TGL_Point.h"
#include "TGL_Size.h"

namespace TGL
{
	class Image;

	class TGLAPI Window
	{
	public:
		const Color DefaultBackColor = 0xffffff;

		Window();
		~Window();

		void Open(const Size& size, const Color& backColor, bool show);
		void Open(const Size& size, int sizeMult, const Color& backColor, bool show);
		void Open(const Size& size, int widthMult, int heightMult, const Color& backColor, bool show);
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
		Size GetSize() const;
		Rect GetRect() const;
		void SetTitle(const String& title);
		void SetIcon(const String& iconfile);
		void SaveScreenshot(const String& file) const;
		void SetBackColor(const Color& color);
		Color GetBackColor() const;
		void SetPixel(const Point& pos, const Color& color);
		void FillRect(const Rect& rect, const Color& color);
		Color GetPixel(int x, int y);
		void DrawImage(Image* img, const Point& pos);
		void DrawImageTile(Image* img, const Rect& imgRect, const Point& dest);

	private:
		SDL_Window* window = nullptr;
		SDL_Renderer* renderer = nullptr;
		SDL_Texture* texture = nullptr;
		RGB* buffer = nullptr;
		Color backColor = DefaultBackColor;
		int bufferLength = 0;
		Size size = { 0, 0 };
		bool isCreated = false;
		bool isVisible = false;
		String title;
	};
}
