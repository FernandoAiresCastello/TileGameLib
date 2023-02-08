#include "TGL.h"
using namespace TGL_Internal;

#define TILE_W	8
#define TILE_H	8

struct TGL tgl;

void TGL::init()
{
	SDL_Init(SDL_INIT_EVERYTHING);

	Util::Randomize();
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
bool TGL::process_default_events(SDL_Event* e)
{
	SDL_PollEvent(e);

	if (e->type == SDL_QUIT) {
		exit();
		return false;
	} else if (e->type == SDL_KEYDOWN) {
		auto key = e->key.keysym.sym;
		if (TKey::Alt() && key == SDLK_RETURN && wnd) {
			wnd->ToggleFullscreen();
		}
	}
	return true;
}
void TGL::window()
{
	int width = 160;
	int height = 144;
	int size_factor = 5;
	rgb back_color = 0xffffff;

	wnd = new TRGBWindow(width / TILE_W, height / TILE_H, size_factor, size_factor, back_color);
	wnd->Show();
}
void TGL::clip(int x1, int y1, int x2, int y2)
{
	wnd->SetClip(x1, y1, x2, y2);
	reset_cursor();
}
void TGL::unclip()
{
	wnd->RemoveClip();
	reset_cursor();
}
void TGL::clear()
{
	wnd->ClearBackground();
}
void TGL::bgcolor(rgb color)
{
	wnd->SetBackColor(color);
}
void TGL::pattern(string id, string pixels)
{
	tile_patterns[id] = pixels;
}
void TGL::tile(string tile_id, string pat1_id)
{
	tiles[tile_id].pattern_ids.push_back(pat1_id);
}
void TGL::tile(string tile_id, string pat1_id, string pat2_id)
{
	tiles[tile_id].pattern_ids.clear();
	tiles[tile_id].pattern_ids.push_back(pat1_id);
	tiles[tile_id].pattern_ids.push_back(pat2_id);
}
void TGL::tile(string tile_id, string pat1_id, string pat2_id, string pat3_id)
{
	tiles[tile_id].pattern_ids.clear();
	tiles[tile_id].pattern_ids.push_back(pat1_id);
	tiles[tile_id].pattern_ids.push_back(pat2_id);
	tiles[tile_id].pattern_ids.push_back(pat3_id);
}
void TGL::tile(string tile_id, string pat1_id, string pat2_id, string pat3_id, string pat4_id)
{
	tiles[tile_id].pattern_ids.clear();
	tiles[tile_id].pattern_ids.push_back(pat1_id);
	tiles[tile_id].pattern_ids.push_back(pat2_id);
	tiles[tile_id].pattern_ids.push_back(pat3_id);
	tiles[tile_id].pattern_ids.push_back(pat4_id);
}
void TGL::pos_free(int x, int y)
{
	cursor.x = x;
	cursor.y = y;
}
void TGL::pos_tiled(int x, int y)
{
	cursor.x = x * TILE_W;
	cursor.y = y * TILE_H;
}
void TGL::scroll(int dx, int dy)
{
	cursor.scroll_x = dx;
	cursor.scroll_y = dy;
}
void TGL::reset_cursor()
{
	cursor.x = 0;
	cursor.y = 0;
	cursor.scroll_x = 0;
	cursor.scroll_y = 0;
}
void TGL::color(rgb c1, rgb c2, rgb c3)
{
	palette.ignore_c0 = true;
	palette.c0 = 0;
	palette.c1 = c1;
	palette.c2 = c2;
	palette.c3 = c3;
}
void TGL::color(rgb c0, rgb c1, rgb c2, rgb c3)
{
	palette.ignore_c0 = false;
	palette.c0 = c0;
	palette.c1 = c1;
	palette.c2 = c2;
	palette.c3 = c3;
}
void TGL::draw(string tile_id)
{
	if (tiles.find(tile_id) == tiles.end()) return;

	tileseq& tile = tiles[tile_id];
	string& pattern_id = tile.pattern_ids[wnd->GetFrame() % tile.pattern_ids.size()];
	string& pixels = tile_patterns[pattern_id];

	int x = cursor.x - cursor.scroll_x;
	int y = cursor.y - cursor.scroll_y;

	if (wnd->HasClip()) {
		x += wnd->GetClip().X1;
		y += wnd->GetClip().Y1;
	}

	wnd->DrawPixelBlock8x8(pixels, palette.c0, palette.c1, palette.c2, palette.c3, palette.ignore_c0, x, y);
}
bool TGL::kb_right()
{
	return TKey::IsPressed(SDL_SCANCODE_RIGHT);
}
bool TGL::kb_left()
{
	return TKey::IsPressed(SDL_SCANCODE_LEFT);
}
bool TGL::kb_down()
{
	return TKey::IsPressed(SDL_SCANCODE_DOWN);
}
bool TGL::kb_up()
{
	return TKey::IsPressed(SDL_SCANCODE_UP);
}
bool TGL::kb_ctrl()
{
	return TKey::Ctrl();
}
