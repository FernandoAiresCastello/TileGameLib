#pragma once
#include "TGL_Global.h"
#include "TGL_Color.h"
#include "TGL_String.h"
#include "TGL_Charset.h"
#include "TGL_Palette.h"
#include "TGL_Keyboard.h"
#include "TGL_Image.h"
#include "TGL_Point.h"
#include "TGL_Rect.h"
#include "TGL_ImageTileMap.h"
#include "TGL_Sprite.h"

namespace TGL
{
	class Application;
	class Graphics;
	class Window;
	class Keyboard;

	class TGLAPI GameBase
	{
	protected:
		void Quit();
		void SetBackColor(const Color& color);
		void ClearScreen();
		void Clip(const Rect& rect);
		void Unclip();
		void TextGrid(bool align);
		void Print(const String& text, const Point& pos, const Color& color);
		void Print(const String& text, const Point& pos, const Color& foreColor, const Color& backColor);
		void PutChar(char ch, const Point& pos, const Color& color);
		void PutChar(char ch, const Point& pos, const Color& foreColor, const Color& backColor);
		void DrawImage(Image* img, const Point& pos);
		void DrawImageTile(Image* img, const Rect& tileRect, const Point& pos);
		void DrawTileMap(ImageTileMap* tilemap, const Point& pos);
		void DrawSprite(Sprite* sprite);
		void DrawRect(const Rect& rect, const Color& color);
		void DrawRect(const Point& topLeft, const Size& size, const Color& color);
		bool Key(Scancode key);
		bool Ctrl();
		bool Shift();
		bool Alt();
		bool CapsLock();
		void FlushKeyboard();

	private:
		friend class Application;

		bool running = false;
		Window* wnd = nullptr;
		Graphics* gr = nullptr;
		Keyboard* kb = nullptr;
		Charset charset;
		Palette palette;
		bool textAlignToGrid = false;

		virtual void OnInit() = 0;
		virtual void OnExit() = 0;
		virtual void OnUpdate() = 0;
		virtual void OnKeyPress(Keycode key) = 0;

		void Run(Application* app);
	};
}
