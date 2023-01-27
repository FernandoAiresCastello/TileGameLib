#include "TGL.h"
using namespace TGL_Internal;

struct TGL tgl;

void TGL::init()
{
	SDL_Init(SDL_INIT_EVERYTHING);
}
int TGL::exit()
{
	delete wnd;

	SDL_Quit();
	::exit(0);
	return 0;
}
int TGL::halt()
{
	while (true) {
		sysproc();
	}
	return exit();
}
bool TGL::sysproc()
{
	render_frame();
	SDL_Event e;
	return process_default_events(&e);
}
void TGL::screen(int width, int height, int hstr, int vstr)
{
	wnd = new TRGBWindow(width / tile::width, height / tile::height, hstr, vstr);
	wnd->Show();
}
void TGL::bgcolor(rgb color)
{
	wnd->SetBackColor(color);
}
bool TGL::process_default_events(SDL_Event* e)
{
	SDL_PollEvent(e);

	if (e->type == SDL_QUIT) {
		exit();
		return true;
	}
	else if (e->type == SDL_KEYDOWN) {
		auto key = e->key.keysym.sym;
		kb_last = key;

		if (key == SDLK_PAUSE) {
			exit();
			return true;
		}
		else if (TKey::Alt() && key == SDLK_RETURN && wnd) {
			wnd->ToggleFullscreen();
			return true;
		}
		else {
			return false;
		}
	}
	return false;
}
void TGL::render_frame()
{
	if (!wnd) return;

	wnd->ClearBackground();
	// draw_graphical_objects();
	wnd->Update();
}
