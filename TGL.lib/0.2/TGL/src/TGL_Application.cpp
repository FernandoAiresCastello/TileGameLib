#include "TGL_Application.h"
#include "TGL_Window.h"

namespace TGL
{
	Application::Application(const String& title, const Size& wndSize, const Size& wndSizeStretch, const Color& backColor)
	{
		this->title = title;
		SDL_Init(SDL_INIT_VIDEO | SDL_INIT_AUDIO);
		wnd.Open(wndSize, wndSizeStretch, backColor, true);
		wnd.SetTitle(title);
	}

	Application::~Application()
	{
		SDL_Quit();
	}

	Window* Application::GetWindow()
	{
		return &wnd;
	}

	Graphics* Application::GetGraphics()
	{
		return wnd.GetGraphics();
	}

	Keyboard* Application::GetKeyboard()
	{
		return &kb;
	}

	void Application::Update()
	{
		wnd.Update();
		HandleEvents();
	}

	void Application::Halt()
	{
		while (wnd.IsOpen())
			Update();
	}

	void Application::HandleEvents()
	{
		while (SDL_PollEvent(&event)) {
			const auto type = event.type;
			if (type == SDL_EVENT_QUIT) {
				wnd.Close();
			}
			else if (type == SDL_EVENT_KEY_DOWN) {
				const auto key = event.key.key;
				if (key == SDLK_RETURN && kb.Alt())
					wnd.ToggleFullscreen();
				else
					kb.AddToBuffer(key);
			}
		}
	}
}
