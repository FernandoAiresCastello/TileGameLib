#include <SDL.h>
#include <TileGameLib.h>
using namespace TileGameLib;

bool running = false;
TWindow* wnd = new TWindow(256, 192, 3, false);

int WindowUpdateThread(void* args) {
	running = true;
	while (running) {
		wnd->Update();
	}
	return 0;
}

int main(int argc, char* argv[]) {

	SDL_CreateThread(WindowUpdateThread, "WindowUpdateThread", nullptr);

	wnd->SetBackColor(14);
	wnd->Clear();

	while (running) {
		for (int i = 0; i < 300; i++) {
			wnd->Clear();
			wnd->DrawTileTransparent('@', 50, 30, i, i);
			SDL_Delay(10);
		}
		for (int i = 300; i >= 0; i--) {
			wnd->Clear();
			wnd->DrawTile('@', 50, 30, i, i);
			SDL_Delay(10);
		}
	}

	delete wnd;
	return 0;
}
