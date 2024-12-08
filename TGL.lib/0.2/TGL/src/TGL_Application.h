#pragma once
#include "TGL_Global.h"
#include "TGL_String.h"
#include "TGL_Window.h"
#include "TGL_Keyboard.h"

namespace TGL
{
	class TGLAPI Application
	{
	public:
		Application();
		Application(const String& title);
		~Application();

		Window* GetWindow();
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
