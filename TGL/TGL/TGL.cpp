#include <CppUtils.h>
using namespace CppUtils;

#include "Internal/TRGBWindow.h"
#include "Internal/TGamepad.h"
#include "Internal/TKey.h"
#include "Internal/TSound.h"
#include "Internal/TSoundFiles.h"
#include "Internal/TImage.h"
using namespace TGL_Internal;

#include "TGL.h"
#include "TGL_Private.h"

#define GAMEBOY_SCR_W			160
#define GAMEBOY_SCR_H			144
#define WIDE_SCR_W				360
#define WIDE_SCR_H				200
#define WND_SIZE_FACTOR_MIN		1
#define WND_SIZE_FACTOR_MAX		5
#define TILE_SIZE				8
#define STRING_FMT_MAXBUFLEN	1024
#define FPS_COLOR				0xd0d0d0

TGL_Private* tgl = nullptr;

TGL::TGL() : tilesize(TILE_SIZE)
{
	tgl = new TGL_Private(this);
}
TGL::~TGL()
{
	if (tgl && tgl->is_running) {
		exit();
	}
}
int TGL::exit()
{
	tgl->is_running = false;

	delete tgl;
	tgl = nullptr;

	SDL_Quit();
	::exit(0);
	return 0;
}
void TGL::update()
{
	tgl->draw_frame();
	tgl->advance_timers();
	SDL_Event e = { 0 };
	tgl->process_default_events(&e);
}
int TGL::halt(void(*fn)())
{
	while (true) {
		pause(1, fn);
	}
	return exit();
}
void TGL::pause(int ms, void(*fn)())
{
	SDL_Event e = { 0 };
	while (ms > 0) {
		if (fn) fn();
		tgl->draw_frame();
		tgl->process_default_events(&e);
		SDL_Delay(1);
		ms--;
	}
}
void TGL::window(int img_width, int img_height, rgb back_color, int size_factor)
{
	if (size_factor < WND_SIZE_FACTOR_MIN) size_factor = WND_SIZE_FACTOR_MIN;
	else if (size_factor > WND_SIZE_FACTOR_MAX) size_factor = WND_SIZE_FACTOR_MAX;
	tgl->create_window(img_width, img_height, back_color, size_factor);
}
void TGL::window_gbc(rgb back_color, int size_factor)
{
	window(GAMEBOY_SCR_W, GAMEBOY_SCR_H, back_color, size_factor);
}
void TGL::window_wide(rgb back_color, int size_factor)
{
	window(WIDE_SCR_W, WIDE_SCR_H, back_color, size_factor);
}
bool TGL::running()
{
	return tgl->is_running;
}
void TGL::title(string str)
{
	if (tgl->wnd) {
		tgl->wnd->SetTitle(str);
	} else {
		tgl->title = str;
	}
}
void TGL::backcolor(rgb back_color)
{
	tgl->wnd->SetBackColor(back_color);
}
void TGL::fullscreen(bool full)
{
	tgl->wnd->SetFullscreen(full);
}
bool TGL::fullscreen()
{
	return tgl->wnd->IsFullscreen();
}
void TGL::mouse(bool enabled)
{
	SDL_ShowCursor(enabled);
}
int TGL::mouse_x()
{
	int x = 0;
	SDL_GetMouseState(&x, NULL);
	return x / tgl->wnd->PixelWidth;
}
int TGL::mouse_y()
{
	int y = 0;
	SDL_GetMouseState(NULL, &y);
	return y / tgl->wnd->PixelHeight;
}
bool TGL::mouse_right()
{
	Uint32 buttons = SDL_GetMouseState(NULL, NULL);
	return buttons & SDL_BUTTON_RMASK;
}
bool TGL::mouse_left()
{
	Uint32 buttons = SDL_GetMouseState(NULL, NULL);
	return buttons & SDL_BUTTON_LMASK;
}
bool TGL::mouse_middle()
{
	Uint32 buttons = SDL_GetMouseState(NULL, NULL);
	return buttons & SDL_BUTTON_MMASK;
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
string TGL::date()
{
	return Util::CurrentDate();
}
string TGL::time()
{
	return Util::CurrentTime();
}
string TGL::datetime()
{
	return date() + " " + time();
}
void TGL::clear()
{
	tgl->wnd->ClearBackground();
}
void TGL::tile_new(string img_id, rgb pixels[64])
{
	for (int i = 0; i < 64; i++) {
		tgl->tile_img[img_id].pixels[i] = pixels[i];
	}
}
void TGL::tile_new(string img_id, string binary_pattern)
{
	for (int i = 0; i < 64; i++) {
		tgl->tile_img[img_id].pixels[i] = binary_pattern[i] == '1' ? 0x000000 : 0xffffff;
	}
}
void TGL::tile_load(string img_id, string path)
{
	TImage img;
	img.Load(path);
	if (img.GetWidth() != tilesize || img.GetHeight() != tilesize) {
		abort("Invalid tile bitmap: " + path);
		return;
	}
	for (int i = 0; i < 64; i++) {
		tgl->tile_img[img_id].pixels[i] = img.GetPixel(i).ToColorRGB();
	}
}
void TGL::tile_add(string tile_id, string img_id, int count)
{
	if (tgl->assert_tileimg_exists(img_id)) {
		for (int i = 0; i < count; i++) {
			tgl->tile_seq[tile_id].pattern_ids.push_back(img_id);
		}
	}
}
void TGL::tile_transparency_key(rgb color)
{
	tgl->tile_transparency.enabled = true;
	tgl->tile_transparency.key = color;
}
void TGL::tile_replace_color(string img_id, rgb original_color, rgb new_color)
{
	if (tgl->assert_tileimg_exists(img_id)) {
		auto& tile = tgl->tile_img[img_id];
		for (int i = 0; i < 64; i++) {
			if (tile.pixels[i] == original_color) {
				tile.pixels[i] = new_color;
			}
		}
	}
}
void TGL::tile_transparent(bool state)
{
	tgl->tile_transparency.enabled = state;
}
void TGL::view_new(string view_id, int x1, int y1, int x2, int y2, rgb back_color, bool clear_bg)
{
	TGL_Private::t_viewport vw;
	vw.x1 = x1; vw.y1 = y1; vw.x2 = x2; vw.y2 = y2;
	vw.back_color = back_color; vw.clear_bg = clear_bg;
	tgl->views[view_id] = vw;
}
void TGL::view(string view_id)
{
	if (!tgl->assert_view_exists(view_id)) return;
	
	tgl->cur_view = &tgl->views[view_id];
	tgl->clip(tgl->cur_view->x1, tgl->cur_view->y1, tgl->cur_view->x2 - 1, tgl->cur_view->y2 - 1);

	if (tgl->cur_view->clear_bg) {
		tgl->clear_view();
	}
}
void TGL::scroll(string view_id, int dx, int dy)
{
	if (!tgl->assert_view_exists(view_id)) return;

	tgl->views[view_id].scroll_x += dx;
	tgl->views[view_id].scroll_y += dy;
}
void TGL::scroll_to(string view_id, int x, int y)
{
	if (!tgl->assert_view_exists(view_id)) return;

	tgl->views[view_id].scroll_x = x;
	tgl->views[view_id].scroll_y = y;
}
int TGL::scroll_x(string view_id)
{
	return tgl->views[view_id].scroll_x;
}
int TGL::scroll_y(string view_id)
{
	return tgl->views[view_id].scroll_y;
}
void TGL::color_normal()
{
	tgl->color_normal();
}
void TGL::color_binary(rgb fore_color)
{
	tgl->color_binary(fore_color);
}
void TGL::color_binary(rgb fore_color, rgb back_color)
{
	tgl->color_binary(fore_color, back_color);
}
void TGL::draw_free(string tile_id, int x, int y)
{
	tgl->pos_free(x, y);
	tgl->draw(tile_id);
}
void TGL::draw_tiled(string tile_id, int col, int row)
{
	tgl->pos_tiled(col, row);
	tgl->draw(tile_id);
}
void TGL::font_color(rgb color)
{
	tgl->font_style.fore_color = color;
}
void TGL::font_color(rgb fore_color, rgb back_color)
{
	tgl->font_style.fore_color = fore_color;
	tgl->font_style.back_color = back_color;
}
void TGL::font(char ch, string pattern)
{
	tgl->font_patterns[ch] = pattern;
}
void TGL::font_shadow(bool shadow, rgb shadow_color)
{
	tgl->font_style.shadow_enabled = shadow;
	tgl->font_style.shadow_color = shadow_color;
}
void TGL::font_transparent(bool state)
{
	tgl->font_style.transparent = state;
}
void TGL::font_reset()
{
	font_new();
	tgl->init_default_font();
}
void TGL::font_new()
{
	tgl->font_patterns.clear();
}
void TGL::print_free(string str, int x, int y)
{
	tgl->pos_free(x, y);
	tgl->print(str);
}
void TGL::print_tiled(string str, int col, int row)
{
	tgl->pos_tiled(col, row);
	tgl->print(str);
}
int TGL::rnd(int min, int max)
{
	return Util::Random(min, max);
}
bool TGL::rnd_chance(int percent)
{
	if (percent <= 0) return false;
	else if (percent >= 100) return true;
	else return rnd(0, 100) >= (100 - percent);
}
void TGL::timer_new(string timer_id, int frames, bool loop)
{
	TGL_Private::t_timer tmr;
	tmr.frames_max = frames;
	tmr.frames_elapsed = 0;
	tmr.loop = loop;
	tgl->timers[timer_id] = tmr;
}
bool TGL::timer(string timer_id)
{
	if (tgl->timers.find(timer_id) == tgl->timers.end()) return false;

	TGL_Private::t_timer& tmr = tgl->timers[timer_id];
	return tmr.frames_elapsed >= tmr.frames_max;
}
void TGL::timer_reset(string timer_id)
{
	if (tgl->timers.find(timer_id) == tgl->timers.end()) return;
	tgl->timers[timer_id].frames_elapsed = 0;
}
bool TGL::collision(int tile1_x, int tile1_y, int tile2_x, int tile2_y)
{
	return	(tile1_x >= tile2_x - TILE_SIZE) && (tile1_x <= tile2_x + TILE_SIZE) &&
			(tile1_y >= tile2_y - TILE_SIZE) && (tile1_y <= tile2_y + TILE_SIZE);
}
bool TGL::file_exists(string path)
{
	return File::Exists(path);
}
bool TGL::folder_exists(string folder_path)
{
	return File::ExistsFolder(folder_path);
}
string TGL::file_cload(string path)
{
	return File::ReadText(path);
}
vector<string> TGL::file_lines(string path)
{
	return File::ReadLines(path, "\n");
}
void TGL::file_appendln(string path, string text)
{
	const string crlf = "\n";
	vector<string> lines;
	if (File::Exists(path)) {
		lines = File::ReadLines(path, crlf);
	}
	lines.push_back(text);
	File::WriteLines(path, lines, crlf);
}
vector<byte> TGL::file_bload(string path)
{
	return File::ReadBytes(path);
}
void TGL::file_csave(string path, string text)
{
	return File::WriteText(path, text);
}
void TGL::file_bsave(string path, vector<byte>& bytes)
{
	return File::WriteBytes(path, bytes);
}
vector<string> TGL::file_list(string folder_path)
{
	return File::List(folder_path, "*", false, false);
}
vector<string> TGL::folder_list(string folder_path)
{
	return File::ListFolders(folder_path, false);
}
void TGL::file_copy(string src_path, string dest_path)
{
	File::Duplicate(src_path, dest_path);
}
void TGL::file_delete(string path)
{
	File::Delete(path);
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
string TGL::ucase(string str)
{
	return String::ToUpper(str);
}
string TGL::lcase(string str)
{
	return String::ToLower(str);
}
string TGL::trim(string str)
{
	return String::Trim(str);
}
vector<string> TGL::split(string str, char delim)
{
	return String::Split(str, delim, true);
}
string TGL::join(vector<string>& str, string separator)
{
	return String::Join(str, separator);
}
int TGL::to_int(string str)
{
	return String::ToInt(str);
}
string TGL::to_string(int value)
{
	return String::ToString(value);
}
string TGL::substr(string str, int first, int last)
{
	return String::Substring(str, first, last);
}
string TGL::replace(string str, string original, string replacement)
{
	return String::Replace(str, original, replacement);
}
bool TGL::starts_with(string str, string prefix)
{
	return String::StartsWith(str, prefix);
}
bool TGL::ends_with(string str, string suffix)
{
	return String::EndsWith(str, suffix);
}
bool TGL::contains(string str, string other)
{
	return String::Contains(str, other);
}
int TGL::indexof(string str, char ch)
{
	return String::IndexOf(str, ch);
}
void TGL::play_volume(int vol)
{
	tgl->snd_notes->SetVolume(vol);
}
void TGL::play_notes(string notes)
{
	tgl->snd_notes->PlaySubSound(notes);
}
void TGL::play_notes_loop(string notes)
{
	tgl->snd_notes->PlayMainSound(notes);
}
void TGL::play_notes_stop()
{
	tgl->snd_notes->StopMainSound();
	tgl->snd_notes->StopSubSound();
}
void TGL::beep(float freq, int len)
{
	tgl->snd_notes->Beep(freq, len);
}
void TGL::sound_load(string sound_id, string file)
{
	if (File::Exists(file)) {
		tgl->snd_files->Load(sound_id, file);
	} else {
		error("Sound file not found: " + file);
	}
}
void TGL::sound(string sound_id)
{
	if (tgl->snd_files->Has(sound_id)) {
		tgl->snd_files->Play(sound_id, true);
	} else {
		error("Sound not found with ID: " + sound_id);
	}
}
void TGL::sound_await(string sound_id)
{
	if (tgl->snd_files->Has(sound_id)) {
		tgl->snd_files->Play(sound_id, false);
	} else {
		error("Sound not found with ID: " + sound_id);
	}
}
void TGL::sound_stop()
{
	tgl->snd_files->StopAll();
}
void TGL::screenshot(string path)
{
	tgl->wnd->SaveScreenshot(path);
}
int TGL::width()
{
	return tgl->wnd->HorizontalResolution;
}
int TGL::height()
{
	return tgl->wnd->VerticalResolution;
}
int TGL::cols()
{
	return width() / tilesize;
}
int TGL::rows()
{
	return height() / tilesize;
}
void TGL::input_color(rgb foreground, rgb background)
{
	tgl->text_input.fore_color = foreground;
	tgl->text_input.back_color = background;
}
void TGL::input_cursor(char ch)
{
	tgl->text_input.cursor = ch;
}
string TGL::input_free(int length, int x, int y, void(*fn)())
{
	return tgl->line_input(length, x, y, false, fn);
}
string TGL::input_tiled(int length, int col, int row, void(*fn)())
{
	return tgl->line_input(length, col, row, true, fn);
}
bool TGL::input_confirmed()
{
	return !tgl->text_input.cancelled;
}
int TGL::kb_lastkey()
{
	int key = tgl->last_key;
	tgl->last_key = 0;
	return key;
}
bool TGL::kb_char(char ch)
{
	SDL_Scancode key = SDL_SCANCODE_UNKNOWN;

	switch (toupper(ch)) {

		case '0': return TKey::IsPressed(SDL_SCANCODE_0) || TKey::IsPressed(SDL_SCANCODE_KP_0);
		case '1': return TKey::IsPressed(SDL_SCANCODE_1) || TKey::IsPressed(SDL_SCANCODE_KP_1);
		case '2': return TKey::IsPressed(SDL_SCANCODE_2) || TKey::IsPressed(SDL_SCANCODE_KP_2);
		case '3': return TKey::IsPressed(SDL_SCANCODE_3) || TKey::IsPressed(SDL_SCANCODE_KP_3);
		case '4': return TKey::IsPressed(SDL_SCANCODE_4) || TKey::IsPressed(SDL_SCANCODE_KP_4);
		case '5': return TKey::IsPressed(SDL_SCANCODE_5) || TKey::IsPressed(SDL_SCANCODE_KP_5);
		case '6': return TKey::IsPressed(SDL_SCANCODE_6) || TKey::IsPressed(SDL_SCANCODE_KP_6);
		case '7': return TKey::IsPressed(SDL_SCANCODE_7) || TKey::IsPressed(SDL_SCANCODE_KP_7);
		case '8': return TKey::IsPressed(SDL_SCANCODE_8) || TKey::IsPressed(SDL_SCANCODE_KP_8);
		case '9': return TKey::IsPressed(SDL_SCANCODE_9) || TKey::IsPressed(SDL_SCANCODE_KP_9);

		case 'A': case 'a': return TKey::IsPressed(SDL_SCANCODE_A);
		case 'B': case 'b': return TKey::IsPressed(SDL_SCANCODE_B);
		case 'C': case 'c': return TKey::IsPressed(SDL_SCANCODE_C);
		case 'D': case 'd': return TKey::IsPressed(SDL_SCANCODE_D);
		case 'E': case 'e': return TKey::IsPressed(SDL_SCANCODE_E);
		case 'F': case 'f': return TKey::IsPressed(SDL_SCANCODE_F);
		case 'G': case 'g': return TKey::IsPressed(SDL_SCANCODE_G);
		case 'H': case 'h': return TKey::IsPressed(SDL_SCANCODE_H);
		case 'I': case 'i': return TKey::IsPressed(SDL_SCANCODE_I);
		case 'J': case 'j': return TKey::IsPressed(SDL_SCANCODE_J);
		case 'K': case 'k': return TKey::IsPressed(SDL_SCANCODE_K);
		case 'L': case 'l': return TKey::IsPressed(SDL_SCANCODE_L);
		case 'M': case 'm': return TKey::IsPressed(SDL_SCANCODE_M);
		case 'N': case 'n': return TKey::IsPressed(SDL_SCANCODE_N);
		case 'O': case 'o': return TKey::IsPressed(SDL_SCANCODE_O);
		case 'P': case 'p': return TKey::IsPressed(SDL_SCANCODE_P);
		case 'Q': case 'q': return TKey::IsPressed(SDL_SCANCODE_Q);
		case 'R': case 'r': return TKey::IsPressed(SDL_SCANCODE_R);
		case 'S': case 's': return TKey::IsPressed(SDL_SCANCODE_S);
		case 'T': case 't': return TKey::IsPressed(SDL_SCANCODE_T);
		case 'U': case 'u': return TKey::IsPressed(SDL_SCANCODE_U);
		case 'V': case 'v': return TKey::IsPressed(SDL_SCANCODE_V);
		case 'W': case 'w': return TKey::IsPressed(SDL_SCANCODE_W);
		case 'X': case 'x': return TKey::IsPressed(SDL_SCANCODE_X);
		case 'Y': case 'y': return TKey::IsPressed(SDL_SCANCODE_Y);
		case 'Z': case 'z': return TKey::IsPressed(SDL_SCANCODE_Z);

		case '\'': return TKey::IsPressed(SDL_SCANCODE_APOSTROPHE);
		case '\\': return TKey::IsPressed(SDL_SCANCODE_BACKSLASH);
		case '/': return TKey::IsPressed(SDL_SCANCODE_SLASH) || TKey::IsPressed(SDL_SCANCODE_KP_DIVIDE);
		case '-': return TKey::IsPressed(SDL_SCANCODE_MINUS) || TKey::IsPressed(SDL_SCANCODE_KP_MINUS);
		case '+': return TKey::IsPressed(SDL_SCANCODE_KP_PLUS);
		case '=': return TKey::IsPressed(SDL_SCANCODE_EQUALS);
		case '*': return TKey::IsPressed(SDL_SCANCODE_KP_MULTIPLY);
		case ',': return TKey::IsPressed(SDL_SCANCODE_COMMA) || TKey::IsPressed(SDL_SCANCODE_KP_COMMA);
		case '.': return TKey::IsPressed(SDL_SCANCODE_PERIOD) || TKey::IsPressed(SDL_SCANCODE_KP_PERIOD);
		case '<': return TKey::IsPressed(SDL_SCANCODE_COMMA);
		case '>': return TKey::IsPressed(SDL_SCANCODE_PERIOD);
		case ';': return TKey::IsPressed(SDL_SCANCODE_SEMICOLON);
		case '[': return TKey::IsPressed(SDL_SCANCODE_LEFTBRACKET);
		case ']': return TKey::IsPressed(SDL_SCANCODE_RIGHTBRACKET);
	}

	return false;
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
bool TGL::kb_shift()
{
	return TKey::Shift();
}
bool TGL::kb_alt()
{
	return TKey::Alt();
}
bool TGL::kb_capslock()
{
	return TKey::CapsLock();
}
bool TGL::kb_esc()
{
	return TKey::IsPressed(SDL_SCANCODE_ESCAPE);
}
bool TGL::kb_space()
{
	return TKey::IsPressed(SDL_SCANCODE_SPACE);
}
bool TGL::kb_backspace()
{
	return TKey::IsPressed(SDL_SCANCODE_BACKSPACE);
}
bool TGL::kb_enter()
{
	return TKey::IsPressed(SDL_SCANCODE_RETURN) || TKey::IsPressed(SDL_SCANCODE_KP_ENTER);
}
bool TGL::kb_tab()
{
	return TKey::IsPressed(SDL_SCANCODE_TAB);
}
bool TGL::kb_insert()
{
	return TKey::IsPressed(SDL_SCANCODE_INSERT);
}
bool TGL::kb_delete()
{
	return TKey::IsPressed(SDL_SCANCODE_DELETE);
}
bool TGL::kb_home()
{
	return TKey::IsPressed(SDL_SCANCODE_HOME);
}
bool TGL::kb_end()
{
	return TKey::IsPressed(SDL_SCANCODE_END);
}
bool TGL::kb_pageup()
{
	return TKey::IsPressed(SDL_SCANCODE_PAGEUP);
}
bool TGL::kb_pagedown()
{
	return TKey::IsPressed(SDL_SCANCODE_PAGEDOWN);
}
bool TGL::kb_pausebrk()
{
	return TKey::IsPressed(SDL_SCANCODE_PAUSE);
}
bool TGL::kb_printscr()
{
	return TKey::IsPressed(SDL_SCANCODE_PRINTSCREEN);
}
bool TGL::kb_f1()
{
	return TKey::IsPressed(SDL_SCANCODE_F1);
}
bool TGL::kb_f2()
{
	return TKey::IsPressed(SDL_SCANCODE_F2);
}
bool TGL::kb_f3()
{
	return TKey::IsPressed(SDL_SCANCODE_F3);
}
bool TGL::kb_f4()
{
	return TKey::IsPressed(SDL_SCANCODE_F4);
}
bool TGL::kb_f5()
{
	return TKey::IsPressed(SDL_SCANCODE_F5);
}
bool TGL::kb_f6()
{
	return TKey::IsPressed(SDL_SCANCODE_F6);
}
bool TGL::kb_f7()
{
	return TKey::IsPressed(SDL_SCANCODE_F7);
}
bool TGL::kb_f8()
{
	return TKey::IsPressed(SDL_SCANCODE_F8);
}
bool TGL::kb_f9()
{
	return TKey::IsPressed(SDL_SCANCODE_F9);
}
bool TGL::kb_f10()
{
	return TKey::IsPressed(SDL_SCANCODE_F10);
}
bool TGL::kb_f11()
{
	return TKey::IsPressed(SDL_SCANCODE_F11);
}
bool TGL::kb_f12()
{
	return TKey::IsPressed(SDL_SCANCODE_F12);
}
void TGL::print_debug(string str, int x, int y, rgb color)
{
	for (auto& ch : str) {
		string& pixels = tgl->font_patterns[ch];
		tgl->wnd->DrawChar8x8(pixels, color, 0, true, x, y, true);
		x += TILE_SIZE;
	}
}
void TGL::show_fps(bool show)
{
	tgl->fps_enabled = show;
}

//=============================================================================
//		TGL_Private
//=============================================================================

TGL_Private::TGL_Private(TGL* tgl_public)
{
	SDL_Init(SDL_INIT_EVERYTHING);
	Util::Randomize();

	is_running = false;
	title = "";
	
	snd_notes = new TSound();
	snd_notes->SetVolume(150);
	snd_files = new TSoundFiles();
	
	init_default_font();
	gamepad.OpenAllAvailable();

	this->tgl_public = tgl_public;

	perfmon.fps_starttime = SDL_GetTicks();
}
TGL_Private::~TGL_Private()
{
	delete wnd;
	wnd = nullptr;
	delete snd_notes;
	snd_notes = nullptr;
	delete snd_files;
	snd_files = nullptr;
}
void TGL_Private::process_default_events(SDL_Event* e)
{
	SDL_PollEvent(e);

	if (e->type == SDL_QUIT) {
		tgl_public->exit();
	} else if (e->type == SDL_KEYDOWN) {
		auto key = e->key.keysym.sym;
		last_key = key;
		if (TKey::Alt() && key == SDLK_RETURN && wnd) {
			wnd->ToggleFullscreen();
		}
	}
}
void TGL_Private::create_window(int width, int height, rgb back_color, int size_factor)
{
	if (wnd) delete wnd;

	wnd = new TRGBWindow(
		width / TILE_SIZE, height / TILE_SIZE,
		size_factor, size_factor, back_color);

	wnd_back_color = back_color;
	wnd->SetTitle(title);
	wnd->Show();

	if (views.find("default") == views.end()) {
		t_viewport def_view;
		def_view.x1 = 0;
		def_view.y1 = 0;
		def_view.x2 = width - 1;
		def_view.y2 = height - 1;
		def_view.back_color = back_color;
		def_view.clear_bg = true;
		views["default"] = def_view;
	}
	cur_view = &views["default"];
	frame_counter = 0;
	is_running = true;
}
void TGL_Private::draw_frame()
{
	on_draw_frame_begin();
	wnd->Update();
	on_draw_frame_end();
}
void TGL_Private::on_draw_frame_begin()
{
	if (fps_enabled) {
		tgl_public->print_debug(String::Format("FPS: %i", perfmon.fps_current), 0, 0, FPS_COLOR);
	}
}
void TGL_Private::on_draw_frame_end()
{
	frame_counter++;
	
	perfmon.fps_frames++;
	perfmon.fps_lasttime = SDL_GetTicks() - perfmon.fps_starttime;
	if (perfmon.fps_lasttime) {
		double elapsed_sec = perfmon.fps_lasttime / 1000.0;
		perfmon.fps_current = perfmon.fps_frames / elapsed_sec;
	}
}
void TGL_Private::clip(int x1, int y1, int x2, int y2)
{
	wnd->SetClip(x1, y1, x2, y2);

	cursor.x = 0;
	cursor.y = 0;
}
void TGL_Private::unclip()
{
	wnd->RemoveClip();

	cursor.x = 0;
	cursor.y = 0;
}
void TGL_Private::clear_entire_window()
{
	if (cur_view) {
		rgb prev_back_color = cur_view->back_color;
		wnd->SetBackColor(wnd_back_color);
		wnd->ClearBackground();
		wnd->SetBackColor(prev_back_color);
	} else {
		wnd->SetBackColor(wnd_back_color);
		wnd->ClearBackground();
	}
}
void TGL_Private::clear_view()
{
	rgb prev_back_color = cur_view->back_color;
	wnd->SetBackColor(cur_view->back_color);
	wnd->ClearBackground();
	wnd->SetBackColor(prev_back_color);
}
bool TGL_Private::assert_tileseq_exists(string& id)
{
	if (tile_seq.find(id) == tile_seq.end()) {
		tgl_public->abort("Tile sequence not found with id: \"" + id + "\"");
		return false;
	}
	return true;
}
bool TGL_Private::assert_tileimg_exists(string& id)
{
	if (tile_img.find(id) == tile_img.end()) {
		tgl_public->abort("Tile not found with id: \"" + id + "\"");
		return false;
	}
	return true;
}
bool TGL_Private::assert_view_exists(string& id)
{
	if (views.find(id) == views.end()) {
		tgl_public->abort("View not found with id: \"" + id + "\"");
		return false;
	}
	return true;
}
void TGL_Private::pos_free(int x, int y)
{
	cursor.x = x;
	cursor.y = y;
}
void TGL_Private::pos_tiled(int x, int y)
{
	cursor.x = x * TILE_SIZE;
	cursor.y = y * TILE_SIZE;
}
void TGL_Private::draw(string& tile_id)
{
	if (!assert_tileseq_exists(tile_id)) return;

	t_tileseq& tileseq = tile_seq[tile_id];
	string& pattern_id = tileseq.pattern_ids[wnd->GetFrame() % tileseq.pattern_ids.size()];
	t_tileimg& tile = tile_img[pattern_id];

	int x = cursor.x;
	int y = cursor.y;

	if (cur_view) {
		x -= cur_view->scroll_x;
		y -= cur_view->scroll_y;
	}
	if (wnd->HasClip()) {
		x += wnd->GetClip().X1;
		y += wnd->GetClip().Y1;
	}

	if (color_mode == t_colormode::normal) {
		wnd->DrawPixelBlock8x8(tile.pixels, tile_transparency.enabled, tile_transparency.key, x, y, false);
	} else if (color_mode == t_colormode::binary) {
		wnd->DrawChar8x8(tile.pixels, binary_color.fore, binary_color.back, tile_transparency.enabled, x, y, false);
	}
}
void TGL_Private::print(string str)
{
	int char_x = cur_view ? cursor.x - cur_view->scroll_x : cursor.x;
	int char_y = cur_view ? cursor.y - cur_view->scroll_y : cursor.y;

	if (wnd->HasClip()) {
		char_x += wnd->GetClip().X1;
		char_y += wnd->GetClip().Y1;
	}

	for (auto& ch : str) {
		string& pixels = font_patterns[ch];
		
		if (font_style.shadow_enabled) {
			wnd->DrawChar8x8(pixels, font_style.shadow_color, font_style.back_color,
				true, char_x + 1, char_y + 1, false);
		}
		wnd->DrawChar8x8(pixels, font_style.fore_color, font_style.back_color,
			font_style.transparent, char_x, char_y, false);

		char_x += TILE_SIZE;
	}
}
void TGL_Private::advance_timers()
{
	for (auto& tmr_entry : timers) {
		t_timer& tmr = tmr_entry.second;
		tmr.frames_elapsed++;
		if (tmr.frames_elapsed > tmr.frames_max) {
			if (tmr.loop) {
				tmr.frames_elapsed = 0;
			} else {
				tmr.frames_elapsed = tmr.frames_max;
			}
		}
	}
}
bool TGL_Private::is_valid_gpad_selected()
{
	return gamepad.Number >= 0 && gamepad.Number < gamepad.CountOpen();
}
void TGL_Private::font(char ch, string pattern)
{
	font_patterns[ch] = pattern;
}
void TGL::gpad_redetect()
{
	tgl->gamepad.OpenAllAvailable();
}
int TGL::gpad_count()
{
	return tgl->gamepad.CountOpen();
}
bool TGL::gpad_connected(int number)
{
	return number >= 0 && number < tgl->gamepad.CountOpen();
}
bool TGL::gpad(int number)
{
	if (number >= 0 && number < tgl->gamepad.CountOpen()) {
		tgl->gamepad.Number = number;
		return true;
	}
	return false;
}
bool TGL::gpad_right()
{
	return tgl->is_valid_gpad_selected() ? 
		tgl->gamepad.Right() || tgl->gamepad.AxisLX() == SDL_JOYSTICK_AXIS_MAX : false;
}
bool TGL::gpad_left()
{
	return tgl->is_valid_gpad_selected() ? 
		tgl->gamepad.Left() || tgl->gamepad.AxisLX() == SDL_JOYSTICK_AXIS_MIN : false;
}
bool TGL::gpad_down()
{
	return tgl->is_valid_gpad_selected() ? 
		tgl->gamepad.Down() || tgl->gamepad.AxisLY() == SDL_JOYSTICK_AXIS_MAX : false;
}
bool TGL::gpad_up()
{
	return tgl->is_valid_gpad_selected() ? 
		tgl->gamepad.Up() || tgl->gamepad.AxisLY() == SDL_JOYSTICK_AXIS_MIN : false;
}
bool TGL::gpad_a()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.A() : false;
}
bool TGL::gpad_b()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.B() : false;
}
bool TGL::gpad_x()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.X() : false;
}
bool TGL::gpad_y()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.Y() : false;
}
bool TGL::gpad_l()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.L() || tgl->gamepad.AxisLT() : false;
}
bool TGL::gpad_r()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.R() || tgl->gamepad.AxisRT() : false;
}
bool TGL::gpad_start()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.Start() : false;
}
bool TGL::gpad_select()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.Select() : false;
}
void TGL_Private::init_default_font()
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
	font(94, "1111111111111111111111111111111111111111111111111111111111111111"); // 94 Solid box (^)
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
string TGL_Private::line_input(int length, int x, int y, bool tiled, void(*fn)())
{
	bool prev_shadow_enabled = font_style.shadow_enabled;
	bool prev_transparent = font_style.transparent;
	rgb prev_fore_color = font_style.fore_color;
	rgb prev_back_color = font_style.back_color;

	text_input.cancelled = false;
	string blanks = String::Repeat(' ', length + 1);
	string text = "";

	bool finished = false;
	while (is_running && !finished) {

		font_style.shadow_enabled = false;
		font_style.transparent = false;
		font_style.fore_color = text_input.fore_color;
		font_style.back_color = text_input.back_color;

		if (tiled) pos_tiled(x, y); else pos_free(x, y); print(blanks);
		if (tiled) pos_tiled(x, y); else pos_free(x, y); print(text + text_input.cursor);

		if (fn) fn();

		draw_frame();

		SDL_Event e = { 0 };
		process_default_events(&e);

		if (e.type == SDL_KEYDOWN) {
			SDL_Keycode key = e.key.keysym.sym;
			
			// ENTER = Confirm
			if (key == SDLK_RETURN && !TKey::Alt()) {
				finished = true;
			}
			// ESC = Cancel
			else if (key == SDLK_ESCAPE) {
				text_input.cancelled = true;
				finished = true;
			}
			// BACKSPACE = Erase last char
			else if (key == SDLK_BACKSPACE) {
				if (!text.empty()) {
					text.pop_back();
				}
			}
			// HOME = Clear
			else if (key == SDLK_HOME) {
				text = "";
			}
			// Any other typable character
			else if (text.length() < length) {
				char ch = keycode_to_char(key);
				if (ch) text += ch;
			}
		}
	}

	font_style.shadow_enabled = prev_shadow_enabled;
	font_style.transparent = prev_transparent;
	font_style.fore_color = prev_fore_color;
	font_style.back_color = prev_back_color;

	return text;
}
char TGL_Private::keycode_to_char(SDL_Keycode key)
{
	bool shift = TKey::Shift();

	if (key == SDLK_SPACE) return ' ';

	else if (key >= SDLK_a && key <= SDLK_z) {
		if (TKey::CapsLock() || shift) {
			return toupper(key);
		} else {
			return tolower(key);
		}
	}
	else if (key >= SDLK_0 && key <= SDLK_9) {
		if (TKey::Shift()) {
			if (key == SDLK_0) return ')';
			if (key == SDLK_1) return '!';
			if (key == SDLK_2) return '@';
			if (key == SDLK_3) return '#';
			if (key == SDLK_4) return '$';
			if (key == SDLK_5) return '%';
			if (key == SDLK_6) return '~';
			if (key == SDLK_7) return '&';
			if (key == SDLK_8) return '*';
			if (key == SDLK_9) return '(';
		} else {
			return key;
		}
	}
	else {
		if (key == SDLK_KP_0) return '0';
		if (key == SDLK_KP_1) return '1';
		if (key == SDLK_KP_2) return '2';
		if (key == SDLK_KP_3) return '3';
		if (key == SDLK_KP_4) return '4';
		if (key == SDLK_KP_5) return '5';
		if (key == SDLK_KP_6) return '6';
		if (key == SDLK_KP_7) return '7';
		if (key == SDLK_KP_8) return '8';
		if (key == SDLK_KP_9) return '9';
	}

	if (key == SDLK_QUOTE) return shift ? '\"' : '\'';
	if (key == SDLK_MINUS || key == SDLK_KP_MINUS) return shift ? '_' : '-';
	if (key == SDLK_EQUALS) return shift ? '+' : '=';
	if (key == SDLK_PLUS || key == SDLK_KP_PLUS) return '+';
	if (key == SDLK_ASTERISK || key == SDLK_KP_MULTIPLY) return '*';
	if (key == SDLK_SLASH || key == SDLK_KP_DIVIDE) return shift ? '?' : '/';
	if (key == SDLK_PERIOD || key == SDLK_KP_PERIOD) return shift ? '>' : '.';
	if (key == SDLK_COMMA || key == SDLK_KP_COMMA) return shift ? '<' : ',';
	if (key == SDLK_SEMICOLON) return shift ? ':' : ';';
	if (key == SDLK_LEFTBRACKET) return shift ? '{' : '[';
	if (key == SDLK_RIGHTBRACKET) return shift ? '}' : ']';
	if (key == SDLK_BACKSLASH) return shift ? '|' : '\\';

	return 0;
}
bool TGL_Private::is_shade_of_gray(TColor& color)
{
	return color.R == color.G && color.G == color.B;
}
int TGL_Private::get_gray_level(TColor& color)
{
	if (is_shade_of_gray(color))
		return color.R;
	else
		return -1;
}
void TGL_Private::color_normal()
{
	color_mode = t_colormode::normal;
}
void TGL_Private::color_binary(rgb fore_color)
{
	color_mode = t_colormode::binary;
	binary_color.fore = fore_color;
}
void TGL_Private::color_binary(rgb fore_color, rgb back_color)
{
	color_mode = t_colormode::binary;
	binary_color.fore = fore_color;
	binary_color.back = back_color;
}
