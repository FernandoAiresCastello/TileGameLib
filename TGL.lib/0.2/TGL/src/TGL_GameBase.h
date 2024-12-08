#pragma once
#include "TGL_Global.h"
#include "TGL_Color.h"
#include "TGL_String.h"
#include "TGL_Charset.h"
#include "TGL_Keyboard.h"
#include "TGL_Image.h"
#include "TGL_Point.h"
#include "TGL_Rect.h"
#include "TGL_TileMap.h"
#include "TGL_Sprite.h"

namespace TGL
{
	class Application;
	class Graphics;
	class Window;

	class TGLAPI GameBase
	{
	public:
		void Run(Application* app);
		void Quit();

	protected:
		void SetBackColor(const Color& color);
		void ClearScreen();
		void ClipScreen(const Rect& rect);
		void UnclipScreen();
		void TextGrid(bool align);
		void Print(const String& text, const Point& pos, const Color& color);
		void Print(const String& text, const Point& pos, const Color& foreColor, const Color& backColor);
		void PutChar(char ch, const Point& pos, const Color& color);
		void PutChar(char ch, const Point& pos, const Color& foreColor, const Color& backColor);
		void DrawImage(Image* img, const Point& pos);
		void DrawImageTile(Image* img, const Rect& tileRect, const Point& pos);
		void DrawTileMap(TileMap* tilemap);
		void DrawSprite(Sprite* sprite);

	private:
		bool running = false;
		Window* wnd = nullptr;
		Graphics* gr = nullptr;
		Charset font;
		bool textAlignToGrid = false;

		virtual void OnInit() = 0;
		virtual void OnExit() = 0;
		virtual void OnUpdate() = 0;
		virtual void OnKeyPress(Keycode key) = 0;
	};
}
