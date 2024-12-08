#pragma once
#include "TGL_Global.h"
#include "TGL_String.h"

namespace TGL
{
	class Window;

	class TGLAPI Application
	{
	public:
		Application();
		Application(const String& title);
		~Application();

		Window* GetWindow();
		void Update();
		void Halt();

	private:
		String title = "";
		Window* wnd = nullptr;
		SDL_Event event = { 0 };

		void HandleEvents();
	};
}
