#pragma once
#include "TGL_Global.h"
#include "TGL_String.h"
#include "TGL_Rect.h"
#include "TGL_Point.h"
#include "TGL_Size.h"
#include "TGL_Color.h"

namespace TGL
{
	class Graphics;

	class TGLAPI Window
	{
	public:
		Window();
		~Window();

		void Open(const Size& size, const Color& backColor, bool show);
		void Open(const Size& size, int sizeMult, const Color& backColor, bool show);
		void Open(const Size& size, int widthMult, int heightMult, const Color& backColor, bool show);
		void Close();
		void Show();
		void Hide();
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
		Graphics* GetGraphics();

	private:
		SDL_Window* window = nullptr;
		SDL_Renderer* renderer = nullptr;
		SDL_Texture* texture = nullptr;
		Size size = { 0, 0 };
		bool isCreated = false;
		bool isVisible = false;
		String title;
		Graphics* gr = nullptr;
	};
}
