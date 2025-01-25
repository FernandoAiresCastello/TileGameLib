#pragma once
#include "TGL_Global.h"
#include "TGL_String.h"
#include "TGL_Window.h"
#include "TGL_Keyboard.h"

namespace TGL
{
	class GameBase;

	class TGLAPI Application
	{
	public:
		Application(const String& title, const Size& wndSize, const Size& wndSizeStretch, const Color& backColor);
		~Application();

		void RunGame(GameBase* game);

		Window* GetWindow();
		Graphics* GetGraphics();
		Keyboard* GetKeyboard();

		void Update();
		void Halt();

	private:
		String title = "";
		Window wnd;
		Keyboard kb;
		SDL_Event event = { 0 };

		void HandleEvents();
	};
}
