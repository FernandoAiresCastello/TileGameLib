#include <CppUtils.h>
using namespace CppUtils;

#include "Internal/TRGBWindow.h"
#include "Internal/TGamepad.h"
#include "Internal/TKey.h"
#include "Internal/TSound.h"
using namespace TGL_Internal;

#include "TGL.h"

#define DEFAULT_WND_W			160
#define DEFAULT_WND_H			144
#define WND_SIZE_FACTOR_MIN		1
#define WND_SIZE_FACTOR_MAX		5
#define TILE_SIZE				8
#define STRING_FMT_MAXBUFLEN	1024

TRGBWindow* wnd = nullptr;
TSound* snd = nullptr;

TGL::TGL()
{
	init();
}
TGL::~TGL()
{
	exit();
}
void TGL::init()
{
	is_running = false;
	wnd_title = "";
	snd = new TSound();
	volume(150);

	SDL_Init(SDL_INIT_EVERYTHING);
	Util::Randomize();
	init_default_font();
}
int TGL::exit()
{
	if (!is_running) return 0;

	is_running = false;
	
	delete wnd;
	wnd = nullptr;
	delete snd;
	snd = nullptr;

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
void TGL::window(rgb back_color, int size_factor)
{
	if (size_factor < WND_SIZE_FACTOR_MIN) size_factor = WND_SIZE_FACTOR_MIN;
	else if (size_factor > WND_SIZE_FACTOR_MAX) size_factor = WND_SIZE_FACTOR_MAX;
	create_window(back_color, size_factor);
}
bool TGL::running()
{
	return is_running;
}
void TGL::title(string str)
{
	if (wnd) {
		wnd->SetTitle(str);
	} else {
		wnd_title = str;
	}
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
int TGL::mouse_x()
{
	int x = 0;
	SDL_GetMouseState(&x, NULL);
	return x;
}
int TGL::mouse_y()
{
	int y = 0;
	SDL_GetMouseState(NULL, &y);
	return y;
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

	wnd->SetTitle(wnd_title);
	wnd->Show();

	is_running = true;
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
void TGL::color(rgb c1)
{
	palette.ignore_c0 = true;
	palette.c0 = 0;
	palette.c1 = c1;
	palette.c2 = 0;
	palette.c3 = 0;
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
void TGL::font_reset()
{
	font_new();
	init_default_font();
}
void TGL::font_new()
{
	font_patterns.clear();
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
bool TGL::collision(int obj1_x, int obj1_y, int obj2_x, int obj2_y)
{
	return	(obj1_x >= obj2_x - TILE_SIZE) && (obj1_x <= obj2_x + TILE_SIZE) &&
			(obj1_y >= obj2_y - TILE_SIZE) && (obj1_y <= obj2_y + TILE_SIZE);
}
string TGL::fmt(const char* str, ...)
{
	char output[STRING_FMT_MAXBUFLEN] = { 0 };
	
	va_list arg;
	va_start(arg, str);
	vsprintf(output, str, arg);
	va_end(arg);

	return output;
}
void TGL::volume(int vol)
{
	snd->SetVolume(vol);
}
void TGL::play(string notes)
{
	snd->PlaySubSound(notes);
}
void TGL::play_loop(string notes)
{
	snd->PlayMainSound(notes);
}
void TGL::play_stop()
{
	snd->StopMainSound();
	snd->StopSubSound();
}
void TGL::sound(float freq, int len)
{
	snd->Beep(freq, len);
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
void TGL::init_default_font()
{
	font(32, "0000000000000000000000000000000000000000000000000000000000000000"); // 32 Space
	font(33, "0011000000110000001100000011000000110000000000000011000000000000"); // 33 !
	font(34, "0110110001101100011011000000000000000000000000000000000000000000"); // 34 "
	font(35, "0000000000010100001111100001010000111110000101000000000000000000"); // 35 #
	font(36, "0001000011111110110100001111111000010110110101101111111000010000"); // 36 $
	font(37, "0000000001100010011001000000100000010000001001100100011000000000"); // 37 %
	font(38, "0001000001111100011000000011100001100000011111000001000000000000"); // 38 &
	font(39, "0000000000011000000110000011000000000000000000000000000000000000"); // 39 '
	font(40, "0000110000011000001100000011000000110000000110000000110000000000"); // 40 (
	font(41, "0011000000011000000011000000110000001100000110000011000000000000"); // 41 )
	font(42, "0000000001101100001110001111111000111000011011000000000000000000"); // 42 *
	font(43, "0000000000011000000110000111111000011000000110000000000000000000"); // 43 +
	font(44, "0000000000000000000000000000000000011000000110000011000000000000"); // 44 ,
	font(45, "0000000000000000000000000111111000000000000000000000000000000000"); // 45 -
	font(46, "0000000000000000000000000000000000000000000110000001100000000000"); // 46 .
	font(47, "0000000100000010000001000000100000010000001000000100000010000000"); // 47 /
	font(48, "0000000011111110110001101101011011010110110001101111111000000000"); // 48 Digit 0
	font(49, "0000000000111000000110000001100000011000000110000111111000000000"); // 49 Digit 1
	font(50, "0000000001111110011001100000011001111110011000000111111000000000"); // 50 Digit 2
	font(51, "0000000001111110000001100011110000000110000001100111111000000000"); // 51 Digit 3
	font(52, "0000000001100110011001100110011001111110000001100000011000000000"); // 52 Digit 4
	font(53, "0000000001111110011000000111111000000110011001100111111000000000"); // 53 Digit 5
	font(54, "0000000001111110011000000111111001100110011001100111111000000000"); // 54 Digit 6
	font(55, "0000000001111110000001100000110000011000001100000011000000000000"); // 55 Digit 7
	font(56, "0000000001111110011001100011110001100110011001100111111000000000"); // 56 Digit 8
	font(57, "0000000001111110011001100110011001111110000001100111111000000000"); // 57 Digit 9
	font(58, "0000000000000000000110000001100000000000000110000001100000000000"); // 58 :
	font(59, "0000000000000000000110000001100000000000000110000001100000001000"); // 59 ;
	font(60, "0000000000000110000110000110000000011000000001100000000000000000"); // 60 <
	font(61, "0000000000000000011111100000000001111110000000000000000000000000"); // 61 =
	font(62, "0000000001100000000110000000011000011000011000000000000000000000"); // 62 >
	font(63, "0111111001100110000001100001111000011000000000000001100000000000"); // 63 ?
	font(64, "1111111010000010101110101010101010111110100000001111111000000000"); // 64 @
	font(65, "0111111001100110011001100110011001111110011001100110011000000000"); // 65 Letter A
	font(66, "0111111001100110011001100111110001100110011001100111111000000000"); // 66 Letter B
	font(67, "0111111001100110011000000110000001100000011001100111111000000000"); // 67 Letter C
	font(68, "0111110001100110011001100110011001100110011001100111110000000000"); // 68 Letter D
	font(69, "0111111001100000011000000111110001100000011000000111111000000000"); // 69 Letter E
	font(70, "0111111001100000011000000111110001100000011000000110000000000000"); // 70 Letter F
	font(71, "0111111001100110011000000110111001100110011001100111111000000000"); // 71 Letter G
	font(72, "0110011001100110011001100111111001100110011001100110011000000000"); // 72 Letter H
	font(73, "0111111000011000000110000001100000011000000110000111111000000000"); // 73 Letter I
	font(74, "0000011000000110000001100000011001100110011001100111111000000000"); // 74 Letter J
	font(75, "0110011001100110011011000111100001100110011001100110011000000000"); // 75 Letter K
	font(76, "0110000001100000011000000110000001100000011000000111111000000000"); // 76 Letter L
	font(77, "1000001011000110111011101111111011010110110101101100011000000000"); // 77 Letter M
	font(78, "0100011001100110011101100111111001101110011001100110001000000000"); // 78 Letter N
	font(79, "0111111001100110011001100110011001100110011001100111111000000000"); // 79 Letter O
	font(80, "0111111001100110011001100110011001111110011000000110000000000000"); // 80 Letter P
	font(81, "0111111001100110011001100110011001100110011011100111111000000011"); // 81 Letter Q
	font(82, "0111111001100110011001100110011001111100011001100110011000000000"); // 82 Letter R
	font(83, "0111111001100110011000000111111000000110011001100111111000000000"); // 83 Letter S
	font(84, "0111111000011000000110000001100000011000000110000001100000000000"); // 84 Letter T
	font(85, "0110011001100110011001100110011001100110011001100111111000000000"); // 85 Letter U
	font(86, "0110011001100110011001100010010000111100000110000001100000000000"); // 86 Letter V
	font(87, "1100011011000110110101101101011011111110011011000110110000000000"); // 87 Letter W
	font(88, "0110011001100110001111000001100000111100011001100110011000000000"); // 88 Letter X
	font(89, "0110011001100110011001100110011001111110000110000001100000000000"); // 89 Letter Y
	font(90, "0111111000000110000011000001100000110000011000000111111000000000"); // 90 Letter Z
	font(91, "0001111000011000000110000001100000011000000110000001100000011110"); // 91 [
	font(92, "1000000001000000001000000001000000001000000001000000001000000001"); // 92 Backslash (\)
	font(93, "0111100000011000000110000001100000011000000110000001100001111000"); // 93 ]
	font(94, "0001000000011000111111001111111011111100000110000001000000000000"); // 94 Right arrow (^)
	font(95, "0000000000000000000000000000000000000000000000000111111000000000"); // 95 _
	font(96, "0000000000011000000110000011000000000000000000000000000000000000"); // 96 Backtick (`)
	font(97, "0000000000000000011111000000110001111100011011000111111000000000"); // 97 Letter a
	font(98, "0111000000110000001111100011011000110110001101100011111000000000"); // 98 Letter b
	font(99, "0000000000000000011111100110011001100000011000000111111000000000"); // 99 Letter c
	font(100, "0000111000001100011111000110110001101100011011000111110000000000"); // 100 Letter d
	font(101, "0000000000000000011111100110011001111110011000000111111000000000"); // 101 Letter e
	font(102, "0000000000111110001100000111110000110000001100000011000000000000"); // 102 Letter f
	font(103, "0000000000000000011111100110110001101100011111000000110001111100"); // 103 Letter g
	font(104, "0110000001100000011111000110110001101100011011000110111000000000"); // 104 Letter h
	font(105, "0001100000000000001110000001100000011000000110000111111000000000"); // 105 Letter i
	font(106, "0000011000000000000001100000011000000110001101100011011000111110"); // 106 Letter j
	font(107, "0110000001100000011001100110110001111000011001100110011000000000"); // 107 Letter k
	font(108, "0011100000011000000110000001100000011000000110000111111000000000"); // 108 Letter l
	font(109, "0000000000000000111111101101011011010110110101101101011000000000"); // 109 Letter m
	font(110, "0000000000000000011111100011011000110110001101100011011000000000"); // 110 Letter n
	font(111, "0000000000000000011111100110011001100110011001100111111000000000"); // 111 Letter o
	font(112, "0000000000000000011111100011011000110110001111100011000000110000"); // 112 Letter p
	font(113, "0000000000000000011111000110110001101100011111000000110000001110"); // 113 Letter q
	font(114, "0000000000000000011111100011011000110000001100000011000000000000"); // 114 Letter r
	font(115, "0000000000000000011111100110000001111110000001100111111000000000"); // 115 Letter s
	font(116, "0000000000110000011111100011000000110000001100000011111000000000"); // 116 Letter t
	font(117, "0000000000000000011011000110110001101100011011000111111000000000"); // 117 Letter u
	font(118, "0000000000000000011001100110011001100110001111000001100000000000"); // 118 Letter v
	font(119, "0000000000000000110101101101011011010110111111100110110000000000"); // 119 Letter w
	font(120, "0000000000000000011001100011110000011000001111000110011000000000"); // 120 Letter x
	font(121, "0000000000000000011101100011011000110110001111100000011000111110"); // 121 Letter y
	font(122, "0000000000000000011111100000011000011000011000000111111000000000"); // 122 Letter z
	font(123, "0000111000001000000010000011000000001000000010000000111000000000"); // 123 {
	font(124, "0001100000011000000110000001100000011000000110000001100000011000"); // 124 |
	font(125, "0111000000010000000100000000110000010000000100000111000000000000"); // 125 }
	font(126, "0000000001101100111111101111111001111100001110000001000000000000"); // 126 Heart (~)
}
