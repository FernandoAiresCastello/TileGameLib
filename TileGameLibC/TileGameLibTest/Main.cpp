#include "Main.h"

int main(int argc, char* argv[])
{
	//TestWindowPanels();
	TestMosaic();

	return 0;
}

void TestMosaic()
{
	TWindow* wnd = new TWindow();
	wnd->SetBackColor(0);
	wnd->Clear();
	wnd->Show();

	TPanel* pnl = new TPanel(wnd);
	pnl->SetPixelSize(4, 4);
	pnl->SetBackColor(0x0f);
	pnl->Grid = true;

	int ch, fgc, bgc = 0;

	while (true) {
		wnd->Clear();
		for (int y = 0; y < 50; y++) {
			for (int x = 0; x < 50; x++) {
				ch = Util::Random(255);
				fgc = Util::Random(255);
				bgc = Util::Random(255);
				pnl->AddTile(ch, fgc, bgc, x, y);
			}
		}
		pnl->Draw();
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
		}
	}

	delete pnl;
	delete wnd;
}

void TestWindowPanels()
{
	TWindow* wnd = new TWindow();
	wnd->SetBackColor(5);
	wnd->Clear();
	wnd->Show();

	TPanel* pnl1 = new TPanel(wnd);
	pnl1->SetLocation(50, 50);
	pnl1->SetSize(1200, 650);
	pnl1->SetPixelSize(4, 4);
	pnl1->SetBackColor(0x80);

	TPanel* pnl2 = new TPanel(wnd);
	pnl2->SetBounds(200, 200, 700, 600);
	pnl2->SetPixelSize(2, 3);
	pnl2->SetBackColor(0xa5);
	pnl2->TransparentTiles = true;
	pnl2->Grid = true;

	int mode = 1;

	while (true) {
		
		wnd->Clear();

		pnl1->AddTile(2, 15, 0, 0, 0);
		pnl1->Draw();

		pnl2->AddTileString("1. Scroll panel contents", mode == 1 ? 15 : 10, 0, 1, 1);
		pnl2->AddTileString("2. Move panel", mode == 2 ? 15 : 10, 0, 1, 2);
		pnl2->AddTileString("3. Resize panel", mode == 3 ? 15 : 10, 0, 1, 3);
		pnl2->AddTileString(String::Format(" X:%03i  Y:%03i", pnl1->GetX(), pnl1->GetY()), 10, 0, 1, 10);
		pnl2->AddTileString(String::Format(" W:%03i  H:%03i", pnl1->GetWidth(), pnl1->GetHeight()), 10, 0, 1, 11);
		pnl2->AddTileString(String::Format("SX:%03i SY:%03i", pnl1->GetScrollX(), pnl1->GetScrollY()), 10, 0, 1, 12);
		pnl2->Draw();

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
