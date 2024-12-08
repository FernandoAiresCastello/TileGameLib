#include "TGL_Application.h"
#include "TGL_Window.h"

namespace TGL
{
	Application::Application() : Application("")
	{
	}

	Application::Application(const String& title)
	{
		SDL_Init(SDL_INIT_VIDEO | SDL_INIT_AUDIO);

		this->title = title;
	}

	Application::~Application()
	{
		delete wnd;
		wnd = nullptr;

		SDL_Quit();
	}

	Window* Application::GetWindow()
	{
		if (!wnd) {
			wnd = new Window();
			wnd->SetTitle(title);
		}

		return wnd;
	}

	void Application::Update()
	{
		wnd->Update();
		HandleEvents();
	}

	void Application::Halt()
	{
		while (wnd->IsOpen())
			Update();
	}

	void Application::HandleEvents()
	{
		while (SDL_PollEvent(&event)) {
			if (event.type == SDL_EVENT_QUIT) {
				wnd->Close();
			}
			else if (event.type == SDL_EVENT_KEY_DOWN) {
				const auto key = event.key.key;
				if (key == SDLK_RETURN && SDL_GetModState() & SDL_KMOD_ALT)
					wnd->ToggleFullscreen();
				else if (key == SDLK_ESCAPE)
					wnd->Close();
			}
		}
	}
}
