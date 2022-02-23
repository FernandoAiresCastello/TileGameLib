#include <SDL.h>
#include <TileGameLib.h>
#include <CppUtils.h>
using namespace TileGameLib;
using namespace CppUtils;

TWindow* Wnd = nullptr;

void Halt();
void Pause(int ms);
void ProcGlobalEvents();

void TestScrolling()
{
	TPanel* pnl = Wnd->AddPanel();
	pnl->SetBackColor(0x80);
	pnl->SetPixelSize(4, 4);
	pnl->SetBounds(50, 50, 800, 600);
	pnl->Visible = true;
	pnl->TransparentTiles = true;
	pnl->Grid = true;

	while (true) {
		pnl->AddTile(3, 15, 0, 0, 10);
		pnl->AddTile(4, 15, 0, 1, 10);
		pnl->AddTile(5, 15, 0, 0, 11);
		pnl->AddTile(6, 15, 0, 1, 11);
		pnl->AddTileString("Hello!", 15, 0, 0, 0);
		Wnd->Update();
		ProcGlobalEvents();

		if (TKey::Alt()) {
			if (TKey::IsPressed(SDL_SCANCODE_RIGHT))
				pnl->ScrollContents(1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_LEFT))
				pnl->ScrollContents(-1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_UP))
				pnl->ScrollContents(0, -1);
			if (TKey::IsPressed(SDL_SCANCODE_DOWN))
				pnl->ScrollContents(0, 1);
		}
		else {
			if (TKey::IsPressed(SDL_SCANCODE_RIGHT))
				pnl->ScrollView(1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_LEFT))
				pnl->ScrollView(-1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_UP))
				pnl->ScrollView(0, -1);
			if (TKey::IsPressed(SDL_SCANCODE_DOWN))
				pnl->ScrollView(0, 1);
		}
	}
}

void TestImages()
{
	TTiledImage* tiledImg = new TTiledImage("test2.bmp", 16, 16, TColor(255, 0, 255));

	int tile = 0;
	while (true) {
		Wnd->EraseImage(tiledImg->GetTile(tile), 0, 0, 4, 4);
		Wnd->DrawImage(tiledImg->GetTile(tile), 0, 0, 4, 4);
		Wnd->Update();

		tile++;
		if (tile >= tiledImg->GetTileCount())
			tile = 0;

		Pause(10);
	}

	delete tiledImg;
}

void TestMosaic()
{
	TPanel* pnl = Wnd->AddPanel();
	pnl->SetPixelSize(4, 3);
	pnl->SetBackColor(0x0f);
	pnl->Grid = true;
	pnl->Visible = true;

	int ch, fgc, bgc = 0;

	while (true) {
		Wnd->SetTitle(String::Format("Panel count: %i; pnl1 tiles: %i",
			Wnd->GetPanelCount(), pnl->GetTileCount()));

		Wnd->ClearAllPanels();

		for (int y = 0; y < 30; y++) {
			for (int x = 0; x < 40; x++) {
				ch = Util::Random(255);
				fgc = Util::Random(255);
				bgc = Util::Random(255);
				pnl->AddTile(ch, fgc, bgc, x, y);
			}
		}

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
}

void TestModalPanel()
{
	TPanel* pnl = Wnd->AddPanel();

	pnl->SetLocation(10, 10);
	pnl->SetSize(600, 400);
	pnl->SetPixelSize(3, 3);
	pnl->SetBackColor(0xb3);
	pnl->Visible = true;
	pnl->TransparentTiles = true;

	while (true) {
		pnl->AddTileString("Hello World!", 0xbc, 0, 0, 0);
		Wnd->Update();
		SDL_Event e = { 0 };
		SDL_PollEvent(&e);
		if (e.type == SDL_KEYDOWN) {
			if (e.key.keysym.sym == SDLK_RETURN)
				break;
			else if (e.key.keysym.sym == SDLK_v)
				pnl->Maximize();
		}
	}

	Wnd->RemovePanel(pnl);
}

void TestPanels()
{
	Wnd->SetBackColor(0x33);

	// Setup MAIN panel
	TPanel* pnlMain = Wnd->AddPanel();
	pnlMain->SetLocation(50, 50);
	pnlMain->SetSize(1100, 500);
	pnlMain->SetPixelSize(4, 4);
	pnlMain->SetBackColor(0x80);
	pnlMain->TransparentTiles = true;
	pnlMain->Grid = true;
	pnlMain->Visible = true;

	TTileSeq anim1;
	anim1.Add(3, 15, 0);
	anim1.Add(4, 10, 0);
	anim1.Add(5, 5, 0);
	TTileSeq anim2;
	anim2.Add(0xdb, 15, 0);
	anim2.Add(0, 15, 0);

	pnlMain->AddAnimatedTile(anim1, 0, 0);
	pnlMain->AddAnimatedTile(anim1, 1, 0);
	pnlMain->AddAnimatedTile(anim1, 0, 1);
	pnlMain->AddAnimatedTile(anim2, 4, 4);

	// Setup INFO panel
	TPanel* pnlInfo = Wnd->AddPanel();
	pnlInfo->SetBounds(200, 200, 800, 600);
	pnlInfo->SetPixelSize(2, 3);
	pnlInfo->SetBackColor(0xa5);
	pnlInfo->TransparentTiles = true;
	pnlInfo->Grid = true;
	pnlInfo->Visible = true;
	pnlInfo->AddTileString("[1] Scroll panel contents", 10, 0, 1, 1);
	pnlInfo->AddTileString("[2] Move panel", 10, 0, 1, 2);
	pnlInfo->AddTileString("[3] Resize panel", 10, 0, 1, 3);
	pnlInfo->AddTileString("[Z] Show/hide main panel", 10, 0, 1, 5);
	pnlInfo->AddTileString("[X] Show/hide this panel", 10, 0, 1, 6);
	pnlInfo->AddTileString("[C] Tile animation on/off", 10, 0, 1, 7);
	pnlInfo->AddTileString("[V] Maximize main panel", 10, 0, 1, 8);
	pnlInfo->AddTileString("[ENTER] Open/close modal panel", 10, 0, 1, 9);

	int mode = 1;

	while (true) {
		Wnd->SetTitle(String::Format("Panel count: %i; pnl1/pnlInfo tiles: %i/%i", 
			Wnd->GetPanelCount(), pnlMain->GetTileCount(), pnlInfo->GetTileCount()));

		Wnd->Update();

		SDL_Event e = { 0 };
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
			else if (key == SDLK_z)
				pnlMain->Visible = !pnlMain->Visible;
			else if (key == SDLK_x)
				pnlInfo->Visible = !pnlInfo->Visible;
			else if (key == SDLK_c)
				Wnd->EnableAnimation(!Wnd->IsAnimationEnabled());
			else if (key == SDLK_v) {
				pnlMain->Maximize();
			}
			else if (key == SDLK_RETURN) {
				TestModalPanel();
				continue;
			}
		}

		if (mode == 1) {
			if (TKey::IsPressed(SDL_SCANCODE_RIGHT))
				pnlMain->ScrollContents(1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_LEFT))
				pnlMain->ScrollContents(-1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_UP))
				pnlMain->ScrollContents(0, -1);
			if (TKey::IsPressed(SDL_SCANCODE_DOWN))
				pnlMain->ScrollContents(0, 1);
		}
		else if (mode == 2) {
			if (TKey::IsPressed(SDL_SCANCODE_RIGHT))
				pnlMain->Move(1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_LEFT))
				pnlMain->Move(-1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_UP))
				pnlMain->Move(0, -1);
			if (TKey::IsPressed(SDL_SCANCODE_DOWN))
				pnlMain->Move(0, 1);
		}
		else if (mode == 3) {
			if (TKey::IsPressed(SDL_SCANCODE_RIGHT))
				pnlMain->Resize(1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_LEFT))
				pnlMain->Resize(-1, 0);
			if (TKey::IsPressed(SDL_SCANCODE_UP))
				pnlMain->Resize(0, -1);
			if (TKey::IsPressed(SDL_SCANCODE_DOWN))
				pnlMain->Resize(0, 1);
		}
	}
}

void Halt()
{
	while (true) {
		Wnd->Update();
		ProcGlobalEvents();
	}
}

void Pause(int ms)
{
	if (ms <= 0) {
		ProcGlobalEvents();
		return;
	}

	for (int i = 0; i < ms; i++) {
		Wnd->Update();
		ProcGlobalEvents();
		SDL_Delay(1);
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
	Wnd->Show();

	//TestScrolling();
	TestPanels();
	//TestMosaic();
	//TestImages();
	
	delete Wnd;
	return 0;
}
