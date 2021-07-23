#include <SDL.h>
#include <cassert>
#include <TileGameLib.h>
using namespace TileGameLib;

int main(int argc, char** args)
{
	//TPalette::Default->Load("data/atari7800.pal");
	//TCharset::Default->Load("data/msx.chr");

	TWindow* win = new TWindow(256, 192, 3, false);

	int x = 1;
	int y = 1;
	const int initialX = x;
	const int colorsPerRow = 29;
	const int tilesPerRow = 29;

	const int palSize = TPalette::Default->GetSize();
	for (int i = 0; i < palSize; i++) {
		win->DrawChar(TCharset::Default, TPalette::Default, 0, i, i, x, y);
		x++;
		if ((i + 1) % colorsPerRow == 0) {
			x = initialX;
			y++;
		}
	}
	
	x = 1;
	y += 2;
	const int chrSize = TCharset::Default->GetSize();
	for (int i = 0; i < chrSize; i++) {
		win->DrawChar(TCharset::Default, TPalette::Default, i, 15, 0, x, y);
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
