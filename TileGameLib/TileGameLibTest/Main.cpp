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

	TBoard* board = new TBoard(32, 24, 2);
	board->AddBackTile('-', 1, 2);
	board->AddBackTile('=', 2, 3);
	TObject* o1 = new TObject();
	o1->AddTile(1, 0, 4);
	o1->AddTile(2, 2, 5);
	o1->AddTile(3, 3, 6);

	TObject* o2 = new TObject(TTileSequence(TTile(4, 5, 6)));
	board->PutObject(o1, 0, 0, 1);
	board->PutObject(o2, 1, 1, 0);

	TBoardView* view = new TBoardView(gr, 150);
	view->SetBoard(board);
	const int borderSize = 2;
	view->SetPosition(borderSize, borderSize);
	view->SetSize(gr->Window->Cols - 2 * borderSize, gr->Window->Rows - 2 * borderSize);

	TUtil::Randomize();

	while (true) {
		win->Clear(gr->Pal, 8);
		view->Draw();
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
			else if (key == SDLK_RIGHT)
				if (alt) view->Scroll(1, 0); else o1->Move(1, 0);
			else if (key == SDLK_LEFT)
				if (alt) view->Scroll(-1, 0); else o1->Move(-1, 0);
			else if (key == SDLK_DOWN)
				if (alt) view->Scroll(0, 1); else o1->Move(0, 1);
			else if (key == SDLK_UP)
				if (alt) view->Scroll(0, -1); else o1->Move(0, -1);
		}
	}

	return 0;
}
