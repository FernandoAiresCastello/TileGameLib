#include "TToolkitApp.h"
#include "TBufferedWindow.h"

namespace TileGameLib
{
	TToolkitApp::TToolkitApp()
	{
		Running = false;
		Wnd = new TBufferedWindow(2, 32, 24, 3, 3);
		Wnd->Show();
	}

	TToolkitApp::~TToolkitApp()
	{
		delete Wnd;
	}

	void TToolkitApp::Run()
	{
		Running = true;
		
		while (Running)
		{
			Wnd->Update();
			SDL_Event e = { 0 };
			SDL_PollEvent(&e);
			if (e.type == SDL_QUIT)
			{
				Running = false;
				break;
			}
		}
	}
}
