#include <SDL.h>
#include <cassert>
#include <TileGameLib.h>
using namespace TileGameLib;

int main(int argc, char** args)
{
	TBoard* board = new TBoard(32, 24, 2);
	TObject* o1 = new TObject(1, 2, 3);
	TObject* o2 = new TObject(TTileSequence(TTile(4, 5, 6)));
	board->PutObject(o1, 10, 20, 1);
	board->PutObject(o2, 10, 20, 1);
	delete board;

	TUtil::Randomize();

	auto win = new TWindow(256, 192, 3, false);
	auto chars = new TCharset();
	auto pal = new TPalette();

	while (true) {
		for (int y = 0; y < win->Rows; y++) {
			for (int x = 0; x < win->Cols; x++) {
				int ch = TUtil::Random(0, chars->GetSize() - 1);
				int fgc = TUtil::Random(0, pal->GetSize() - 1);
				int bgc = TUtil::Random(0, pal->GetSize() - 1);
				win->DrawChar(chars, pal, ch, fgc, bgc, x, y);
			}
		}
		win->DrawString(chars, pal, "Hello World!", 1, 0, 1, 1);
		win->Update();

		SDL_Event e = { 0 };
		SDL_PollEvent(&e);
		if (e.type == SDL_QUIT)
			break;
	}

	return 0;
}
