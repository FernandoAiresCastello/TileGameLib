#pragma once
#include "TGL_Global.h"
#include "TGL_Color.h"
#include "TGL_String.h"
#include "TGL_Charset.h"
#include "TGL_Keyboard.h"

namespace TGL
{
	class Application;
	class Graphics;

	class TGLAPI GameBase
	{
	public:
		void Run(Application* app);
		void Quit();

	protected:
		void SetBackColor(const Color& color);
		void TextGrid(bool align);
		void Print(const String& text, int x, int y, const Color& color);
		void Print(const String& text, int x, int y, const Color& foreColor, const Color& backColor);

	private:
		bool running = false;
		Graphics* gr = nullptr;
		Charset font;
		bool textAlignToGrid = false;

		virtual void OnInit() = 0;
		virtual void OnExit() = 0;
		virtual void OnUpdate(Keyboard* kb) = 0;
		virtual void OnDraw(Graphics* gr) = 0;
		virtual void OnKeyPress(Keycode key) = 0;
	};
}
