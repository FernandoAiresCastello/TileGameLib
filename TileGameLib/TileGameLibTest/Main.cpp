#include <SDL.h>
#include <cassert>
#include <TileGameLib.h>
using namespace TileGameLib;

int main(int argc, char** args)
{
	TWindow* win = new TWindow(256, 192, 3, false);
	TCharset* chars = new TCharset();
	TPalette* pal = new TPalette();
	TGraphics* gr = new TGraphics(win, chars, pal);

	int x = 1;
	int y = 1;
	const int initialX = x;
	const int colorsPerRow = 16;
	const int tilesPerRow = 24;

	for (int i = 0; i < pal->GetSize(); i++) {
		win->DrawChar(chars, pal, 0, i, i, x, y);
		x++;
		if ((i + 1) % colorsPerRow == 0) {
			x = initialX;
			y++;
		}
	}

	y++;
	for (int i = 0; i < chars->GetSize(); i++) {
		win->DrawChar(chars, pal, i, 1, 0, x, y);
		x++;
		if ((i + 1) % tilesPerRow == 0) {
			x = initialX;
			y++;
		}
	}

	while (true) {
		win->Update();
		SDL_Event e = { 0 };
		SDL_PollEvent(&e);
		if (e.type == SDL_QUIT)
			break;
		else if (e.type == SDL_KEYDOWN) {
			auto key = e.key.keysym.sym;
			auto alt = TKey::Alt();
			if (key == SDLK_ESCAPE)
				break;
			else if (key == SDLK_RETURN && alt)
				win->ToggleFullscreen();
		}
	}

	return 0;
}
