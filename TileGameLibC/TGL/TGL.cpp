#include "TGL.h"
using namespace TGL_Internal;

#define TILE_W	8
#define TILE_H	8

struct TGL tgl;

void TGL::init()
{
	SDL_Init(SDL_INIT_EVERYTHING);
	
	Util::Randomize();

	create_window();
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
	while (system());

	return exit();
}
bool TGL::system()
{
	wnd->Update();
	SDL_Event e;
	return process_default_events(&e);
}
void TGL::title(string str)
{
	wnd->SetTitle(str);
}
void TGL::error(string msg)
{
	MsgBox::Error(msg);
}
void TGL::abort(string msg)
{
	error(msg);
	exit();
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
void TGL::create_window()
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

	cursor.x = 0;
	cursor.y = 0;
}
void TGL::unclip()
{
	wnd->RemoveClip();

	cursor.x = 0;
	cursor.y = 0;
}
void TGL::clear()
{
	wnd->ClearBackground();
}
void TGL::bgcolor(rgb color)
{
	wnd->SetBackColor(color);
}
void TGL::tile_pat(string pattern_id, string pixels)
{
	tile_patterns[pattern_id] = pixels;
}
void TGL::tile_new(string tile_id)
{
	tiles[tile_id] = tileseq();
}
void TGL::tile_add(string tile_id, string pattern_id)
{
	if (assert_tile_exists(tile_id) && assert_tilepattern_exists(pattern_id))
		tiles[tile_id].pattern_ids.push_back(pattern_id);
}
bool TGL::assert_tile_exists(string& id)
{
	if (tiles.find(id) == tiles.end()) {
		abort("Tile not found with id: \"" + id + "\"");
		return false;
	}
	return true;
}
bool TGL::assert_tilepattern_exists(string& id)
{
	if (tile_patterns.find(id) == tile_patterns.end()) {
		abort("Tile pattern not found with id: \"" + id + "\"");
		return false;
	}
	return true;
}
bool TGL::assert_view_exists(string& id)
{
	if (views.find(id) == views.end()) {
		abort("View not found with id: \"" + id + "\"");
		return false;
	}
	return true;
}
void TGL::mkview(string view_id, int x1, int y1, int x2, int y2, rgb back_color, bool clear_bg)
{
	viewport vw;
	vw.x1 = x1; vw.y1 = y1; vw.x2 = x2; vw.y2 = y2;
	vw.back_color = back_color; vw.clear_bg = clear_bg;
	views[view_id] = vw;
}
void TGL::view(string view_id)
{
	if (!assert_view_exists(view_id)) return;
	
	cur_view = &views[view_id];

	tgl.clip(cur_view->x1, cur_view->y1, cur_view->x2 - 1, cur_view->y2 - 1);
	tgl.bgcolor(cur_view->back_color);
	if (cur_view->clear_bg) {
		tgl.clear();
	}
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
	cur_view->scroll_x += dx;
	cur_view->scroll_y += dy;
}
int TGL::scroll_getx()
{
	return cur_view->scroll_x;
}
int TGL::scroll_gety()
{
	return cur_view->scroll_y;
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
void TGL::draw_free(string tile_id, int x, int y)
{
	pos_free(x, y);
	draw(tile_id);
}
void TGL::draw_tiled(string tile_id, int col, int row)
{
	pos_tiled(col, row);
	draw(tile_id);
}
void TGL::draw(string& tile_id)
{
	if (!cur_view || !assert_tile_exists(tile_id)) return;

	tileseq& tile = tiles[tile_id];
	string& pattern_id = tile.pattern_ids[wnd->GetFrame() % tile.pattern_ids.size()];
	string& pixels = tile_patterns[pattern_id];

	int x = cursor.x - cur_view->scroll_x;
	int y = cursor.y - cur_view->scroll_y;

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
bool TGL::kb_char(char ch)
{
	SDL_Scancode key = SDL_SCANCODE_UNKNOWN;

	switch (toupper(ch)) {
		case '0': key = SDL_SCANCODE_0; break;
		case '1': key = SDL_SCANCODE_1; break;
		case '2': key = SDL_SCANCODE_2; break;
	}

	return key != SDL_SCANCODE_UNKNOWN && TKey::IsPressed(key);
}
