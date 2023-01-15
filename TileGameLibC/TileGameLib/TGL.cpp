/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#include "TGL.h"
#include "TBufferedWindow.h"
#include "TKey.h"
using namespace TileGameLib;

TBufferedWindow* wnd = nullptr;

void TILEGAMELIB()
{
	SDL_Init(SDL_INIT_EVERYTHING);
}
void EXIT()
{
	delete wnd;
	SDL_Quit();
	exit(0);
}
void HALT()
{
	while (true) {
		if (wnd) {
			wnd->Update();
		}
		SDL_Event e;
		SDL_PollEvent(&e);
		if (e.type == SDL_QUIT) {
			EXIT();
		} else if (e.type == SDL_KEYDOWN) {
			auto key = e.key.keysym.sym;
			if (key == SDLK_ESCAPE) {
				EXIT();
			} else if (TKey::Alt() && key == SDLK_RETURN && wnd) {
				wnd->ToggleFullscreen();
			}
		}
	}
}
void SCREEN(int cols, int rows, int layers, int hstr, int vstr)
{
	wnd = new TBufferedWindow(layers, cols, rows, hstr, vstr);
	wnd->Show();
}
