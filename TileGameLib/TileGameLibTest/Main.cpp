#include <SDL.h>
#include <TileGameLib.h>
using namespace TileGameLib;

int main(int argc, char** args)
{
	TGLUtil::Randomize();

	auto win = new TGLWindow(256, 192, 3, false);
	auto chars = new TGLCharset();
	auto pal = new TGLPalette();

	while (true) {
		for (int y = 0; y < win->Rows; y++) {
			for (int x = 0; x < win->Cols; x++) {
				int ch = TGLUtil::Random(0, chars->GetSize() - 1);
				int fgc = TGLUtil::Random(0, pal->GetSize() - 1);
				int bgc = TGLUtil::Random(0, pal->GetSize() - 1);
				win->DrawChar(chars, pal, ch, fgc, bgc, x, y);
			}
		}

		win->Update();

		SDL_Event e = { 0 };
		SDL_PollEvent(&e);
		if (e.type == SDL_QUIT)
			break;
	}

	return 0;
}
