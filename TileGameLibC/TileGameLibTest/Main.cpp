#include "Main.h"

int main(int argc, char* argv[])
{
	TestWindowPanels();

	return 0;
}

void TestWindowPanels()
{
	TWindow* wnd = new TWindow();
	wnd->SetBackColor(5);
	wnd->Clear();
	wnd->Show();

	TPanel* pnl1 = new TPanel(wnd);
	pnl1->SetBounds(50, 50, 500, 300);
	pnl1->SetPixelSize(4, 4);
	pnl1->SetBackColor(0x80);

	TPanel* pnl2 = new TPanel(wnd);
	pnl2->SetBounds(200, 200, 700, 500);
	pnl2->SetPixelSize(2, 3);
	pnl2->SetBackColor(0xa5);
	pnl2->TransparentTiles = true;
	pnl2->Grid = true;

	int mode = 1;

	while (true) {

		wnd->Clear();

		pnl1->Clear();
		pnl1->DrawTile(2, 15, 0, 0, 0);
		pnl2->Clear();
		pnl2->DrawTileString("1. Scroll panel contents", mode == 1 ? 15 : 10, 0, 1, 1);
		pnl2->DrawTileString("2. Move panel", mode == 2 ? 15 : 10, 0, 1, 2);
		pnl2->DrawTileString("3. Resize panel", mode == 3 ? 15 : 10, 0, 1, 3);

		wnd->Update();

		SDL_Event e;
		SDL_PollEvent(&e);
		if (e.type == SDL_QUIT) {
			break;
		}
		else if (e.type == SDL_KEYDOWN) {
			auto key = e.key.keysym.sym;
			if (key == SDLK_ESCAPE)
				break;
			else if (key == SDLK_RETURN && TKey::Alt())
				wnd->ToggleFullscreen();
			else if (key == SDLK_1)
				mode = 1;
			else if (key == SDLK_2)
				mode = 2;
			else if (key == SDLK_3)
				mode = 3;
		}

		if (mode == 1) {
			if (TKey::IsPressed(SDL_SCANCODE_RIGHT))
				pnl1->Scroll(1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_LEFT))
				pnl1->Scroll(-1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_UP))
				pnl1->Scroll(0, -1);
			if (TKey::IsPressed(SDL_SCANCODE_DOWN))
				pnl1->Scroll(0, 1);
		}
		else if (mode == 2) {
			if (TKey::IsPressed(SDL_SCANCODE_RIGHT))
				pnl1->Move(1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_LEFT))
				pnl1->Move(-1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_UP))
				pnl1->Move(0, -1);
			if (TKey::IsPressed(SDL_SCANCODE_DOWN))
				pnl1->Move(0, 1);
		}
		else if (mode == 3) {
			if (TKey::IsPressed(SDL_SCANCODE_RIGHT))
				pnl1->Resize(1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_LEFT))
				pnl1->Resize(-1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_UP))
				pnl1->Resize(0, -1);
			if (TKey::IsPressed(SDL_SCANCODE_DOWN))
				pnl1->Resize(0, 1);
		}
	}

	delete pnl1;
	delete pnl2;
	delete wnd;
}
