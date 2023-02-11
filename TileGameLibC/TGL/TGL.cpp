#include "TGL.h"
using namespace TGL_Internal;

#define DEFAULT_WND_W			160
#define DEFAULT_WND_H			144
#define DEFAULT_WND_BGCOLOR		0xffffff
#define WND_SIZE_FACTOR_MIN		1
#define WND_SIZE_FACTOR_MAX		5
#define DEFAULT_WND_SIZE_FACTOR	5

#define TILE_SIZE	8

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
void TGL::system()
{
	update();
	advance_timers();

	SDL_Event e;
	process_default_events(&e);
}
int TGL::halt()
{
	while (true) {
		pause(1);
	}
	return exit();
}
void TGL::pause(int ms)
{
	while (ms > 0) {
		system();
		SDL_Delay(1);
		ms--;
	}
}
void TGL::window()
{
	window(DEFAULT_WND_BGCOLOR, DEFAULT_WND_SIZE_FACTOR);
}
void TGL::window(rgb back_color)
{
	window(back_color, DEFAULT_WND_SIZE_FACTOR);
}
void TGL::window(rgb back_color, int size_factor)
{
	if (size_factor < WND_SIZE_FACTOR_MIN) size_factor = WND_SIZE_FACTOR_MIN;
	else if (size_factor > WND_SIZE_FACTOR_MAX) size_factor = WND_SIZE_FACTOR_MAX;
	create_window(back_color, size_factor);
}
void TGL::title(string str)
{
	wnd->SetTitle(str);
}
int TGL::width()
{
	return wnd->HorizontalResolution;
}
int TGL::height()
{
	return wnd->VerticalResolution;
}
int TGL::tilesize()
{
	return TILE_SIZE;
}
int TGL::cols()
{
	return width() / TILE_SIZE;
}
int TGL::rows()
{
	return height() / TILE_SIZE;
}
void TGL::mouse_on()
{
	SDL_ShowCursor(true);
}
void TGL::mouse_off()
{
	SDL_ShowCursor(false);
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
void TGL::process_default_events(SDL_Event* e)
{
	SDL_PollEvent(e);

	if (e->type == SDL_QUIT) {
		exit();
	} else if (e->type == SDL_KEYDOWN) {
		auto key = e->key.keysym.sym;
		if (TKey::Alt() && key == SDLK_RETURN && wnd) {
			wnd->ToggleFullscreen();
		}
	}
}
void TGL::create_window(rgb back_color, int size_factor)
{
	if (wnd) delete wnd;

	wnd = new TRGBWindow(
		DEFAULT_WND_W / TILE_SIZE, DEFAULT_WND_H / TILE_SIZE,
		size_factor, size_factor, back_color);

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
void TGL::clear_view()
{
	rgb prev_back_color = cur_view->back_color;
	wnd->SetBackColor(cur_view->back_color);
	wnd->ClearBackground();
	wnd->SetBackColor(prev_back_color);
}
void TGL::clear()
{
	wnd->ClearBackground();
}
void TGL::update()
{
	wnd->Update();
}
void TGL::tile_pat(string pattern_id, string pixels)
{
	tile_patterns[pattern_id] = pixels;
}
void TGL::tile_add(string tile_id, string pattern_id)
{
	if (assert_tilepattern_exists(pattern_id))
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
void TGL::view_new(string view_id, int x1, int y1, int x2, int y2, rgb back_color, bool clear_bg)
{
	t_viewport vw;
	vw.x1 = x1; vw.y1 = y1; vw.x2 = x2; vw.y2 = y2;
	vw.back_color = back_color; vw.clear_bg = clear_bg;
	views[view_id] = vw;
}
void TGL::view(string view_id)
{
	if (!assert_view_exists(view_id)) return;
	
	cur_view = &views[view_id];
	clip(cur_view->x1, cur_view->y1, cur_view->x2 - 1, cur_view->y2 - 1);

	if (cur_view->clear_bg) {
		clear_view();
	}
}
void TGL::pos_free(int x, int y)
{
	cursor.x = x;
	cursor.y = y;
}
void TGL::pos_tiled(int x, int y)
{
	cursor.x = x * TILE_SIZE;
	cursor.y = y * TILE_SIZE;
}
void TGL::scroll(int dx, int dy)
{
	cur_view->scroll_x += dx;
	cur_view->scroll_y += dy;
}
void TGL::scroll_to(int x, int y)
{
	cur_view->scroll_x = x;
	cur_view->scroll_y = y;
}
int TGL::scroll_x()
{
	return cur_view->scroll_x;
}
int TGL::scroll_y()
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

	t_tileseq& tile = tiles[tile_id];
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
void TGL::font(char ch, string pattern)
{
	font_patterns[ch] = pattern;
}
void TGL::print_free(string str, int x, int y)
{
	pos_free(x, y);
	print(str);
}
void TGL::print_tiled(string str, int col, int row)
{
	pos_tiled(col, row);
	print(str);
}
void TGL::print(string& str)
{
	int char_x = cursor.x - cur_view->scroll_x;
	int char_y = cursor.y - cur_view->scroll_y;

	if (wnd->HasClip()) {
		char_x += wnd->GetClip().X1;
		char_y += wnd->GetClip().Y1;
	}

	for (auto& ch : str) {
		string& pixels = font_patterns[ch];
		wnd->DrawPixelBlock8x8(pixels, palette.c0, palette.c1, palette.c2, palette.c3, palette.ignore_c0, char_x, char_y);
		char_x += TILE_SIZE;
	}
}
int TGL::rnd(int min, int max)
{
	return Util::Random(min, max);
}
void TGL::timer_new(string timer_id, int cycles, bool loop)
{
	t_timer tmr;
	tmr.cycles_max = cycles;
	tmr.cycles_elapsed = 0;
	tmr.loop = loop;
	timers[timer_id] = tmr;
}
bool TGL::timer(string timer_id)
{
	if (timers.find(timer_id) == timers.end()) return false;

	t_timer& tmr = timers[timer_id];
	return tmr.cycles_elapsed >= tmr.cycles_max;
}
void TGL::advance_timers()
{
	for (auto& tmr_entry : timers) {
		t_timer& tmr = tmr_entry.second;
		tmr.cycles_elapsed++;
		if (tmr.cycles_elapsed > tmr.cycles_max) {
			if (tmr.loop) {
				tmr.cycles_elapsed = 0;
			} else {
				tmr.cycles_elapsed = tmr.cycles_max;
			}
		}
	}
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
bool TGL::kb_esc()
{
	return TKey::IsPressed(SDL_SCANCODE_ESCAPE);
}
bool TGL::kb_space()
{
	return TKey::IsPressed(SDL_SCANCODE_SPACE);
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
