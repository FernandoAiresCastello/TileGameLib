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
	while (sysproc());

	return exit();
}
bool TGL::sysproc()
{
	wnd->Update();
	SDL_Event e;
	return process_default_events(&e);
}
void TGL::title(string title)
{
	wnd_title = title;
	if (wnd) {
		wnd->SetTitle(title);
	}
}
void TGL::screen(int width, int height, int hstr, int vstr, rgb back_color)
{
	wnd = new TRGBWindow(width / tile::width, height / tile::height, hstr, vstr, back_color);
	wnd->SetTitle(wnd_title);
	wnd->Show();
}
void TGL::bgcolor(rgb color)
{
	wnd->SetBackColor(color);
}
void TGL::clip(int x1, int y1, int x2, int y2)
{
	wnd->SetClip(x1, y1, x2, y2);
}
void TGL::unclip()
{
	wnd->RemoveClip();
}
void TGL::cls()
{
	wnd->ClearBackground();
}
void TGL::drawtile(tile& tile, int x, int y)
{
	if (!tile.visible) return;

	if (wnd->HasClip()) {
		x += wnd->GetClip().X1;
		y += wnd->GetClip().Y1;
	}
	tile_f& frame = tile.frames[wnd->GetFrame() % tile.frames.size()];
	wnd->DrawPixelBlock8x8(frame.pixels, frame.c0, frame.c1, frame.c2, frame.c3, tile.ignore_c0, x, y);
}
void TGL::drawtilemap(tilemap& tilemap, int x, int y)
{
	if (!tilemap.visible) return;

	const int initial_x = x;
	const int initial_y = y;
	int current_x = x;
	int current_y = y;

	for (int y = 0; y < tilemap.rows; y++) {
		for (int x = 0; x < tilemap.cols; x++) {
			tile* tile = tilemap.get(x, y);
			if (tile) {
				drawtile(*tile, current_x, current_y);
			}
			current_x += tile::width;
		}
		current_x = initial_x;
		current_y += tile::height;
	}
}
bool TGL::process_default_events(SDL_Event* e)
{
	SDL_PollEvent(e);

	if (e->type == SDL_QUIT) {
		exit();
		return false;
	}
	else if (e->type == SDL_KEYDOWN) {
		auto key = e->key.keysym.sym;
		kb_last = key;

		if (key == SDLK_ESCAPE) {
			exit();
			return false;
		}
		else if (TKey::Alt() && key == SDLK_RETURN && wnd) {
			wnd->ToggleFullscreen();
		}
	}
	return true;
}
