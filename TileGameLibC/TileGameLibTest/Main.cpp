#include <SDL.h>
#include <TileGameLib.h>
#include <CppUtils.h>
using namespace TileGameLib;
using namespace CppUtils;

TWindow* Wnd = nullptr;

void Halt();
void ProcGlobalEvents();

void TestScrolling()
{
	TPanel* pnl = new TPanel(Wnd);
	pnl->SetBackColor(0x80);
	pnl->SetPixelSize(4, 4);
	pnl->SetBounds(50, 50, 800, 600);
	pnl->Visible = true;
	pnl->Transparency = true;
	pnl->Grid = true;

	while (true) {
		Wnd->Clear();
		pnl->AddTile(3, 15, 0, 0, 10);
		pnl->AddTile(4, 15, 0, 1, 10);
		pnl->AddTile(5, 15, 0, 0, 11);
		pnl->AddTile(6, 15, 0, 1, 11);
		pnl->AddTileString("Hello!", 15, 0, 0, 0);
		pnl->Draw();
		Wnd->Update();
		ProcGlobalEvents();
		if (TKey::IsPressed(SDL_SCANCODE_RIGHT))
			pnl->Scroll(1, 0);
		if (TKey::IsPressed(SDL_SCANCODE_LEFT))
			pnl->Scroll(-1, 0);
		if (TKey::IsPressed(SDL_SCANCODE_UP))
			pnl->Scroll(0, -1);
		if (TKey::IsPressed(SDL_SCANCODE_DOWN))
			pnl->Scroll(0, 1);
	}
}

void TestImages()
{
	Wnd->SetBackColor(0x03);
	Wnd->Clear();

	/*TImage* img = new TImage();
	img->Load("test.bmp", TColor(255, 0, 255));
	Wnd->DrawImage(img, 0, 0, 5, 4);
	Wnd->DrawImage(img, 16, 0, 5, 4);
	Wnd->DrawImage(img, 0, 16, 5, 4);*/

	TTiledImage* tiledImg = new TTiledImage("test2.bmp", 16, 16, TColor(255, 0, 255));
	//Wnd->DrawImage(img->GetImage(), 0, 0, 4, 4);

	int tile = 0;
	while (true) {
		ProcGlobalEvents();
		Wnd->EraseImage(tiledImg->GetTile(tile), 0, 0, 4, 4);
		Wnd->DrawImage(tiledImg->GetTile(tile), 0, 0, 4, 4);
		Wnd->Update();
		tile++;
		if (tile >= tiledImg->GetTileCount())
			tile = 0;

		SDL_Delay(100);
	}

	delete tiledImg;
}

void TestMosaic()
{
	TPanel* pnl = new TPanel(Wnd);
	pnl->SetPixelSize(4, 4);
	pnl->SetBackColor(0x0f);
	pnl->Grid = true;
	pnl->Visible = true;

	int ch, fgc, bgc = 0;

	while (true) {
		Wnd->Clear();
		for (int y = 0; y < 50; y++) {
			for (int x = 0; x < 50; x++) {
				ch = Util::Random(255);
				fgc = Util::Random(255);
				bgc = Util::Random(255);
				pnl->AddTile(ch, fgc, bgc, x, y);
			}
		}
		pnl->Draw();
		Wnd->Update();

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
				Wnd->ToggleFullscreen();
		}
	}

	delete pnl;
}

void TestWindowPanels()
{
	TPanel* pnl1 = new TPanel(Wnd);
	pnl1->SetLocation(50, 50);
	pnl1->SetSize(1200, 650);
	pnl1->SetPixelSize(4, 4);
	pnl1->Scroll(1, 0);
	pnl1->SetBackColor(0x80);
	pnl1->Visible = true;
	pnl1->Grid = true;

	TPanel* pnl2 = new TPanel(Wnd);
	pnl2->SetBounds(200, 200, 700, 600);
	pnl2->SetPixelSize(2, 3);
	pnl2->SetBackColor(0xa5);
	pnl2->SetScroll(-5, -20);
	pnl2->Transparency = true;
	pnl2->Grid = true;
	pnl2->Visible = true;

	int mode = 1;

	while (true) {
		
		Wnd->Clear();

		pnl1->AddTile(2, 15, 0, 0, 0);
		pnl1->Draw();

		pnl2->AddTileString("1. Scroll panel contents", mode == 1 ? 15 : 10, 0, 1, 1);
		pnl2->AddTileString("2. Move panel", mode == 2 ? 15 : 10, 0, 1, 2);
		pnl2->AddTileString("3. Resize panel", mode == 3 ? 15 : 10, 0, 1, 3);
		pnl2->AddTileString(String::Format(" X:%03i  Y:%03i", pnl1->GetX(), pnl1->GetY()), 10, 0, 1, 10);
		pnl2->AddTileString(String::Format(" W:%03i  H:%03i", pnl1->GetWidth(), pnl1->GetHeight()), 10, 0, 1, 11);
		pnl2->AddTileString(String::Format("SX:%03i SY:%03i", pnl1->GetScrollX(), pnl1->GetScrollY()), 10, 0, 1, 12);
		pnl2->Draw();

		Wnd->Update();

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
				Wnd->ToggleFullscreen();
			else if (key == SDLK_1)
				mode = 1;
			else if (key == SDLK_2)
				mode = 2;
			else if (key == SDLK_3)
				mode = 3;
		}

		if (mode == 1) {
			if (TKey::IsPressed(SDL_SCANCODE_RIGHT))
				pnl2->Scroll(1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_LEFT))
				pnl2->Scroll(-1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_UP))
				pnl2->Scroll(0, -1);
			if (TKey::IsPressed(SDL_SCANCODE_DOWN))
				pnl2->Scroll(0, 1);
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
}

void Halt()
{
	while (true) {
		Wnd->Update();
		ProcGlobalEvents();
	}
}

void ProcGlobalEvents()
{
	SDL_Event e;
	SDL_PollEvent(&e);
	if (e.type == SDL_QUIT) {
		exit(0);
	}
	else if (e.type == SDL_KEYDOWN) {
		auto key = e.key.keysym.sym;
		if (key == SDLK_ESCAPE)
			exit(0);
		else if (key == SDLK_RETURN && TKey::Alt())
			Wnd->ToggleFullscreen();
	}
}

int main(int argc, char* argv[])
{
	Wnd = new TWindow();
	Wnd->SetBackColor(0);
	Wnd->Clear();
	Wnd->Show();

	//TestScrolling();
	//TestWindowPanels();
	TestMosaic();
	//TestImages();
	
	delete Wnd;
	return 0;
}
