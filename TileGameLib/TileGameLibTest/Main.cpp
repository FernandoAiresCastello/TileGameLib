#include <SDL.h>
#include <TileGameLib.h>
#include <CppUtils.h>
using namespace TileGameLib;
using namespace CppUtils;

int main(int argc, char* argv[])
{
	TWindow* wnd = TWindow::CreateWithAbsoluteSize(800, 600);
	wnd->SetBackColor(0x80);
	wnd->Clear();
	wnd->Show();

	int sx = 0;
	int sy = 0;
	

	while (true) {
		wnd->RemoveClip();
		wnd->FillClip(0xff0000);
		wnd->SetPixelSize(1, 1);
		wnd->DrawTileString("Hello World!", 15, 0, sx, sy, true, false);
		
		wnd->SetClip(300, 300, 500, 500);
		wnd->FillClip(0x00ff00);
		wnd->SetPixelSize(3, 3);
		wnd->DrawTileString("This is cool", 15, 0, sx, sy, false, true);

		wnd->Update();

		SDL_Event e = { 0 };
		SDL_PollEvent(&e);
		if (e.type == SDL_KEYDOWN) {
			SDL_Keycode key = e.key.keysym.sym;
			if (key == SDLK_RIGHT) sx++;
			else if (key == SDLK_LEFT) sx--;
			else if (key == SDLK_UP) sy--;
			else if (key == SDLK_DOWN) sy++;
		}
	}

	delete wnd;
	return 0;
}
