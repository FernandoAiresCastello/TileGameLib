/*=============================================================================

	TGL.lib

	Part of the TileGameLib toolkit:
	https://github.com/FernandoAiresCastello/TileGameLib

	Copyright (c) 2019-2023 Fernando Aires Castello

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and /or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.

//============================================================================*/
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
#include "TGL_PRIVATE.h"

#define WND_SIZE_FACTOR_MIN		1
#define WND_SIZE_FACTOR_MAX		10
#define STRING_FMT_MAXBUFLEN	1024
#define FPS_COLOR				0xd0d0d0

TGL_PRIVATE* tgl = nullptr;

TGL_TILE_RGB::TGL_TILE_RGB()
{
	for (int i = 0; i < 64; i++) {
		pixels[i] = 0x000000;
	}
}
TGL_TILE_RGB::TGL_TILE_RGB(rgb pixels[64])
{
	for (int i = 0; i < 64; i++) {
		this->pixels[i] = pixels[i];
	}
}
TGL_TILE_RGB::TGL_TILE_RGB(rgb pixels[64], rgb transparency_key)
{
	transparent = true;
	this->transparency_key = transparency_key;
	for (int i = 0; i < 64; i++) {
		this->pixels[i] = pixels[i];
	}
}
TGL_TILE_BIN::TGL_TILE_BIN()
{
	bits = std::string(64, '0');
}
TGL_TILE_BIN::TGL_TILE_BIN(std::string bits)
{
	this->bits = std::string(bits);
}
void TGL_TILE_BIN::clear()
{
	for (int i = 0; i < bits.length(); i++) {
		bits[i] = '0';
	}
}
TGL_VIEW::TGL_VIEW()
{
}
TGL_VIEW::TGL_VIEW(int x1, int y1, int x2, int y2, rgb back_color, bool clear_bg)
{
	this->x1 = x1;
	this->y1 = y1;
	this->x2 = x2;
	this->y2 = y2;
	this->back_color = back_color;
	this->clear_bg = clear_bg;
}
void TGL_VIEW::scroll(int dx, int dy)
{
	scroll_x += dx;
	scroll_y += dy;
}
void TGL_VIEW::scroll_to(int x, int y)
{
	scroll_x = x;
	scroll_y = y;
}
TGL_TIMER::TGL_TIMER(int length, bool loop)
{
	this->length = length;
	this->loop = loop;
}
void TGL_TIMER::tick()
{
	if (elapsed < length) {
		elapsed++;
	}
	else if (loop) {
		elapsed = 0;
	}
}
bool TGL_TIMER::done()
{
	return elapsed == length;
}
void TGL_FILE::write(std::string value)
{
	output_buf += value + field_separator;
}
void TGL_FILE::write(int value)
{
	output_buf += TGL_APP::to_string(value) + field_separator;
}
void TGL_FILE::save(std::string path)
{
	TGL_APP::file_csave(path, output_buf);
}
void TGL_FILE::load(std::string path)
{
	std::string data = TGL_APP::file_cload(path);
	input_buf = TGL_APP::split(data, field_separator);
	input_buf_ptr = 0;
}
void TGL_FILE::load_from_memory(std::string data)
{
	input_buf = TGL_APP::split(data, field_separator);
	input_buf_ptr = 0;
}
std::string TGL_FILE::read_string()
{
	return input_buf[input_buf_ptr++];
}
int TGL_FILE::read_int()
{
	return TGL_APP::to_int(input_buf[input_buf_ptr++]);
}
bool TGL_FILE::eof()
{
	return input_buf_ptr >= input_buf.size();
}
int TGL_FILE::fields()
{
	return input_buf.size();
}
TGL_APP::TGL_APP()
{
	tgl = new TGL_PRIVATE(this);
}
TGL_APP::~TGL_APP()
{
	if (tgl && tgl->is_running) {
		exit();
	}
}
int TGL_APP::exit()
{
	tgl->is_running = false;

	delete tgl;
	tgl = nullptr;

	SDL_Quit();
	::exit(0);
	return 0;
}
void TGL_APP::update()
{
	tgl->draw_frame();
	SDL_Event e = { 0 };
	tgl->process_default_events(&e);
}
int TGL_APP::halt(callback fn)
{
	while (true) {
		pause(1, fn);
	}
	return exit();
}
void TGL_APP::pause(int frames, callback fn)
{
	SDL_Event e = { 0 };
	while (frames > 0) {
		if (fn) fn();
		tgl->draw_frame();
		tgl->process_default_events(&e);
		frames--;
	}
}
void TGL_APP::window(int img_width, int img_height, rgb back_color, int size_factor)
{
	if (size_factor < WND_SIZE_FACTOR_MIN) size_factor = WND_SIZE_FACTOR_MIN;
	else if (size_factor > WND_SIZE_FACTOR_MAX) size_factor = WND_SIZE_FACTOR_MAX;
	tgl->create_window(img_width, img_height, back_color, size_factor);
}
void TGL_APP::window_160x144(rgb back_color, int size_factor)
{
	window(160, 144, back_color, size_factor);
}
void TGL_APP::window_256x192(rgb back_color, int size_factor)
{
	window(256, 192, back_color, size_factor);
}
void TGL_APP::window_352x200(rgb back_color, int size_factor)
{
	window(352, 200, back_color, size_factor);
}
bool TGL_APP::window()
{
	return tgl->wnd != nullptr;
}
void TGL_APP::title(std::string str)
{
	if (tgl->wnd) {
		tgl->wnd->SetTitle(str);
	} else {
		tgl->title = str;
	}
}
void TGL_APP::backcolor(rgb back_color)
{
	tgl->wnd->SetBackColor(back_color);
}
void TGL_APP::fullscreen(bool full)
{
	tgl->wnd->SetFullscreen(full);
}
bool TGL_APP::fullscreen()
{
	return tgl->wnd->IsFullscreen();
}
void TGL_APP::mouse(bool show)
{
	SDL_ShowCursor(show);
}
int TGL_APP::mouse_x()
{
	int x = 0;
	SDL_GetMouseState(&x, NULL);
	return x / tgl->wnd->PixelWidth;
}
int TGL_APP::mouse_y()
{
	int y = 0;
	SDL_GetMouseState(NULL, &y);
	return y / tgl->wnd->PixelHeight;
}
bool TGL_APP::mouse_right()
{
	Uint32 buttons = SDL_GetMouseState(NULL, NULL);
	return buttons & SDL_BUTTON_RMASK;
}
bool TGL_APP::mouse_left()
{
	Uint32 buttons = SDL_GetMouseState(NULL, NULL);
	return buttons & SDL_BUTTON_LMASK;
}
bool TGL_APP::mouse_middle()
{
	Uint32 buttons = SDL_GetMouseState(NULL, NULL);
	return buttons & SDL_BUTTON_MMASK;
}
void TGL_APP::error(std::string msg)
{
	MsgBox::Error(msg);
}
void TGL_APP::abort(std::string msg)
{
	error(msg);
	exit();
}
std::string TGL_APP::date()
{
	return Util::CurrentDate();
}
std::string TGL_APP::time()
{
	return Util::CurrentTime();
}
std::string TGL_APP::datetime()
{
	return date() + " " + time();
}
void TGL_APP::to_clipboard(std::string text)
{
	Util::SendTextToClipboard(text);
}
std::string TGL_APP::from_clipboard()
{
	return Util::GetTextFromClipboard();
}
void TGL_APP::clear()
{
	tgl->wnd->ClearBackground();
}
void TGL_APP::view(TGL_VIEW& vw)
{
	tgl->cur_view = &vw;
	tgl->clip(tgl->cur_view->x1, tgl->cur_view->y1, tgl->cur_view->x2 - 1, tgl->cur_view->y2 - 1);
	if (tgl->cur_view->clear_bg) {
		tgl->clear_current_view();
	}
}
void TGL_APP::exit_view()
{
	view(tgl->default_view);
}
TGL_TILE_RGB TGL_APP::tile_load_rgb(std::string path)
{
	TImage img;
	img.Load(path);
	if (img.GetWidth() != TGL_TILESIZE || img.GetHeight() != TGL_TILESIZE) {
		abort("Invalid TGL bitmap file: " + path);
	}
	TGL_TILE_RGB tile;
	tile.transparent = false;
	int i = 0;
	for (auto& color : img.GetPixels()) {
		tile.pixels[i++] = color.ToColorRGB();
	}
	return tile;
}
TGL_TILE_RGB TGL_APP::tile_load_rgb(std::string path, rgb transparency_key)
{
	TGL_TILE_RGB tile = tile_load_rgb(path);
	tile.transparent = true;
	tile.transparency_key = transparency_key;
	return tile;
}
void TGL_PRIVATE::adjust_pos(int& x, int& y)
{
	if (tgl->cur_view) {
		x -= tgl->cur_view->scroll_x;
		y -= tgl->cur_view->scroll_y;
	}
	if (tgl->wnd->HasClip()) {
		x += tgl->wnd->GetClip().X1;
		y += tgl->wnd->GetClip().Y1;
	}
}
void TGL_APP::draw_free(TGL_TILE_RGB& tile, int x, int y)
{
	tgl->adjust_pos(x, y);
	tgl->wnd->DrawPixelBlock8x8(tile.pixels, tile.transparent, tile.transparency_key, x, y, false);
}
void TGL_APP::draw_free(TGL_TILE_BIN& tile, int x, int y, rgb fore_color)
{
	tgl->adjust_pos(x, y);
	tgl->wnd->DrawChar8x8(tile.bits, fore_color, 0, true, x, y, false);
}
void TGL_APP::draw_free(TGL_TILE_BIN& tile, int x, int y, rgb fore_color, rgb back_color)
{
	tgl->adjust_pos(x, y);
	tgl->wnd->DrawChar8x8(tile.bits, fore_color, back_color, false, x, y, false);
}
void TGL_APP::draw_free(std::string binary, int x, int y, rgb fore_color)
{
	tgl->adjust_pos(x, y);
	tgl->wnd->DrawChar8x8(binary, fore_color, 0, true, x, y, false);
}
void TGL_APP::draw_free(std::string binary, int x, int y, rgb fore_color, rgb back_color)
{
	tgl->adjust_pos(x, y);
	tgl->wnd->DrawChar8x8(binary, fore_color, back_color, false, x, y, false);
}
void TGL_APP::draw_tiled(TGL_TILE_RGB& tile, int x, int y)
{
	draw_free(tile, x * TGL_TILESIZE, y * TGL_TILESIZE);
}
void TGL_APP::draw_tiled(TGL_TILE_BIN& tile, int x, int y, rgb fore_color)
{
	draw_free(tile, x * TGL_TILESIZE, y * TGL_TILESIZE, fore_color);
}
void TGL_APP::draw_tiled(TGL_TILE_BIN& tile, int x, int y, rgb fore_color, rgb back_color)
{
	draw_free(tile, x * TGL_TILESIZE, y * TGL_TILESIZE, fore_color, back_color);
}
void TGL_APP::draw_tiled(std::string binary, int x, int y, rgb fore_color)
{
	draw_free(binary, x * TGL_TILESIZE, y * TGL_TILESIZE, fore_color);
}
void TGL_APP::draw_tiled(std::string binary, int x, int y, rgb fore_color, rgb back_color)
{
	draw_free(binary, x * TGL_TILESIZE, y * TGL_TILESIZE, fore_color, back_color);
}
void TGL_APP::text_color(rgb color)
{
	tgl->text_style.fore_color = color;
}
void TGL_APP::text_color(rgb fore_color, rgb back_color)
{
	tgl->text_style.fore_color = fore_color;
	tgl->text_style.back_color = back_color;
}
void TGL_APP::font(char ch, std::string binary)
{
	tgl->font_tiles[ch] = binary;
}
void TGL_APP::text_shadow(bool shadow, rgb shadow_color)
{
	tgl->text_style.shadow_enabled = shadow;
	tgl->text_style.shadow_color = shadow_color;
}
void TGL_APP::text_transparent(bool state)
{
	tgl->text_style.transparent = state;
}
void TGL_APP::font_reset()
{
	font_new();
	tgl->init_default_font();
}
std::string TGL_APP::font_getbits(int ch)
{
	return tgl->font_tiles[ch].bits;
}
int TGL_APP::font_getsize()
{
	return TGL_FONTSIZE;
}
void TGL_APP::font_new()
{
	for (int i = 0; i < TGL_FONTSIZE; i++)
		tgl->font_tiles[i] = TGL_TILE_BIN();
}
void TGL_APP::print_free(std::string str, int x, int y)
{
	tgl->print(str, x, y, false);
}
void TGL_APP::print_tiled(std::string str, int x, int y)
{
	tgl->print(str, x, y, true);
}
rgb TGL_APP::color_rgb(int r, int g, int b)
{
	return TColor(r, g, b).ToColorRGB();
}
int TGL_APP::color_r(rgb color)
{
	return TColor(color).R;
}
int TGL_APP::color_g(rgb color)
{
	return TColor(color).G;
}
int TGL_APP::color_b(rgb color)
{
	return TColor(color).B;
}
int TGL_APP::rnd(int min, int max)
{
	return Util::Random(min, max);
}
bool TGL_APP::rnd_chance(int percent)
{
	if (percent <= 0) return false;
	else if (percent >= 100) return true;
	else return rnd(0, 100) >= (100 - percent);
}
bool TGL_APP::collision(int tile1_x, int tile1_y, int tile2_x, int tile2_y)
{
	return	(tile1_x >= tile2_x - TGL_TILESIZE) && (tile1_x <= tile2_x + TGL_TILESIZE) &&
			(tile1_y >= tile2_y - TGL_TILESIZE) && (tile1_y <= tile2_y + TGL_TILESIZE);
}
bool TGL_APP::file_exists(std::string path)
{
	return File::Exists(path);
}
bool TGL_APP::folder_exists(std::string folder_path)
{
	return File::ExistsFolder(folder_path);
}
std::string TGL_APP::file_cload(std::string path)
{
	return File::ReadText(path);
}
std::vector<std::string> TGL_APP::file_lines(std::string path)
{
	return File::ReadLines(path, "\n");
}
void TGL_APP::file_line_add(std::string path, std::string text)
{
	const std::string crlf = "\n";
	std::vector<std::string> lines;
	if (File::Exists(path)) {
		lines = File::ReadLines(path, crlf);
	}
	lines.push_back(text);
	File::WriteLines(path, lines, crlf);
}
std::vector<byte> TGL_APP::file_bload(std::string path)
{
	return File::ReadBytes(path);
}
void TGL_APP::file_csave(std::string path, std::string text)
{
	return File::WriteText(path, text);
}
void TGL_APP::file_bsave(std::string path, std::vector<byte>& bytes)
{
	return File::WriteBytes(path, bytes);
}
std::vector<std::string> TGL_APP::file_list(std::string folder_path)
{
	return File::List(folder_path, "*", false, false);
}
std::vector<std::string> TGL_APP::folder_list(std::string folder_path)
{
	return File::ListFolders(folder_path, false);
}
void TGL_APP::file_copy(std::string src_path, std::string dest_path)
{
	File::Duplicate(src_path, dest_path);
}
void TGL_APP::file_delete(std::string path)
{
	File::Delete(path);
}
std::string TGL_APP::fmt(const char* str, ...)
{
	char output[STRING_FMT_MAXBUFLEN] = { 0 };
	
	va_list arg;
	va_start(arg, str);
	vsprintf(output, str, arg);
	va_end(arg);

	return output;
}
std::string TGL_APP::ucase(std::string str)
{
	return String::ToUpper(str);
}
std::string TGL_APP::lcase(std::string str)
{
	return String::ToLower(str);
}
std::string TGL_APP::trim(std::string str)
{
	return String::Trim(str);
}
std::vector<std::string> TGL_APP::split(std::string str, char delim)
{
	return String::Split(str, delim, true);
}
std::string TGL_APP::join(std::vector<std::string>& str, std::string separator)
{
	return String::Join(str, separator);
}
int TGL_APP::to_int(std::string str)
{
	return String::ToInt(str);
}
std::string TGL_APP::to_string(int value)
{
	return String::ToString(value);
}
std::string TGL_APP::substr(std::string str, int first, int last)
{
	return String::Substring(str, first, last);
}
std::string TGL_APP::replace(std::string str, std::string original, std::string replacement)
{
	return String::Replace(str, original, replacement);
}
bool TGL_APP::starts_with(std::string str, std::string prefix)
{
	return String::StartsWith(str, prefix);
}
bool TGL_APP::ends_with(std::string str, std::string suffix)
{
	return String::EndsWith(str, suffix);
}
bool TGL_APP::contains(std::string str, std::string other)
{
	return String::Contains(str, other);
}
int TGL_APP::indexof(std::string str, char ch)
{
	return String::IndexOf(str, ch);
}
void TGL_APP::play_volume(int vol)
{
	tgl->snd_notes->SetVolume(vol);
}
void TGL_APP::play_notes(std::string notes)
{
	tgl->snd_notes->PlaySubSound(notes);
}
void TGL_APP::play_notes_loop(std::string notes)
{
	tgl->snd_notes->PlayMainSound(notes);
}
void TGL_APP::play_notes_stop()
{
	tgl->snd_notes->StopMainSound();
	tgl->snd_notes->StopSubSound();
}
void TGL_APP::beep(float freq, int len)
{
	tgl->snd_notes->Beep(freq, len);
}
TGL_SOUND TGL_APP::sound_load(std::string file)
{
	TGL_SOUND snd;
	if (File::Exists(file)) {
		tgl->snd_files->Load(file, file);
		snd.file = file;
	}
	else {
		error("Sound file not found: " + file);
	}
	return snd;
}
void TGL_APP::sound_play(TGL_SOUND& snd)
{
	if (tgl->snd_files->Has(snd.file)) {
		tgl->snd_files->Play(snd.file, true);
	}
	else {
		error("Sound not loaded with file: " + snd.file);
	}
}
void TGL_APP::sound_await(TGL_SOUND& snd)
{
	if (tgl->snd_files->Has(snd.file)) {
		tgl->snd_files->Play(snd.file, false);
	}
	else {
		error("Sound not loaded with file: " + snd.file);
	}
}
void TGL_APP::sound_stop()
{
	tgl->snd_files->StopAll();
}
void TGL_APP::screenshot(std::string path)
{
	tgl->wnd->SaveScreenshot(path);
}
int TGL_APP::width()
{
	return tgl->wnd->HorizontalResolution;
}
int TGL_APP::height()
{
	return tgl->wnd->VerticalResolution;
}
int TGL_APP::cols()
{
	return width() / TGL_TILESIZE;
}
int TGL_APP::rows()
{
	return height() / TGL_TILESIZE;
}
int TGL_APP::framecount()
{
	return tgl->frame_counter;
}
int TGL_APP::fps()
{
	return tgl->perfmon.fps_current;
}
void TGL_APP::input_color(rgb foreground, rgb background)
{
	tgl->text_input.fore_color = foreground;
	tgl->text_input.back_color = background;
}
void TGL_APP::input_cursor(char ch)
{
	tgl->text_input.cursor = ch;
}
void TGL_APP::input_placeholder(std::string text)
{
	tgl->text_input.placeholder = text;
}
std::string TGL_APP::input_free(int length, int x, int y, callback fn)
{
	return tgl->line_input(length, x, y, false, fn);
}
std::string TGL_APP::input_tiled(int length, int col, int row, callback fn)
{
	return tgl->line_input(length, col, row, true, fn);
}
bool TGL_APP::input_ok()
{
	return !tgl->text_input.cancelled;
}
int TGL_APP::kb_inkey()
{
	int key = tgl->last_key;
	tgl->last_key = 0;
	return key;
}
bool TGL_APP::kb_char(char ch)
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
bool TGL_APP::kb_scan(int scancode)
{
	return TKey::IsPressed((SDL_Scancode)scancode);
}
bool TGL_APP::kb_right()
{
	return TKey::IsPressed(SDL_SCANCODE_RIGHT);
}
bool TGL_APP::kb_left()
{
	return TKey::IsPressed(SDL_SCANCODE_LEFT);
}
bool TGL_APP::kb_down()
{
	return TKey::IsPressed(SDL_SCANCODE_DOWN);
}
bool TGL_APP::kb_up()
{
	return TKey::IsPressed(SDL_SCANCODE_UP);
}
bool TGL_APP::kb_ctrl()
{
	return TKey::Ctrl();
}
bool TGL_APP::kb_shift()
{
	return TKey::Shift();
}
bool TGL_APP::kb_alt()
{
	return TKey::Alt();
}
bool TGL_APP::kb_capslock()
{
	return TKey::CapsLock();
}
bool TGL_APP::kb_esc()
{
	return TKey::IsPressed(SDL_SCANCODE_ESCAPE);
}
bool TGL_APP::kb_space()
{
	return TKey::IsPressed(SDL_SCANCODE_SPACE);
}
bool TGL_APP::kb_backspace()
{
	return TKey::IsPressed(SDL_SCANCODE_BACKSPACE);
}
bool TGL_APP::kb_enter()
{
	return TKey::IsPressed(SDL_SCANCODE_RETURN) || TKey::IsPressed(SDL_SCANCODE_KP_ENTER);
}
bool TGL_APP::kb_tab()
{
	return TKey::IsPressed(SDL_SCANCODE_TAB);
}
bool TGL_APP::kb_insert()
{
	return TKey::IsPressed(SDL_SCANCODE_INSERT);
}
bool TGL_APP::kb_delete()
{
	return TKey::IsPressed(SDL_SCANCODE_DELETE);
}
bool TGL_APP::kb_home()
{
	return TKey::IsPressed(SDL_SCANCODE_HOME);
}
bool TGL_APP::kb_end()
{
	return TKey::IsPressed(SDL_SCANCODE_END);
}
bool TGL_APP::kb_pageup()
{
	return TKey::IsPressed(SDL_SCANCODE_PAGEUP);
}
bool TGL_APP::kb_pagedown()
{
	return TKey::IsPressed(SDL_SCANCODE_PAGEDOWN);
}
bool TGL_APP::kb_pausebrk()
{
	return TKey::IsPressed(SDL_SCANCODE_PAUSE);
}
bool TGL_APP::kb_printscr()
{
	return TKey::IsPressed(SDL_SCANCODE_PRINTSCREEN);
}
bool TGL_APP::kb_f1()
{
	return TKey::IsPressed(SDL_SCANCODE_F1);
}
bool TGL_APP::kb_f2()
{
	return TKey::IsPressed(SDL_SCANCODE_F2);
}
bool TGL_APP::kb_f3()
{
	return TKey::IsPressed(SDL_SCANCODE_F3);
}
bool TGL_APP::kb_f4()
{
	return TKey::IsPressed(SDL_SCANCODE_F4);
}
bool TGL_APP::kb_f5()
{
	return TKey::IsPressed(SDL_SCANCODE_F5);
}
bool TGL_APP::kb_f6()
{
	return TKey::IsPressed(SDL_SCANCODE_F6);
}
bool TGL_APP::kb_f7()
{
	return TKey::IsPressed(SDL_SCANCODE_F7);
}
bool TGL_APP::kb_f8()
{
	return TKey::IsPressed(SDL_SCANCODE_F8);
}
bool TGL_APP::kb_f9()
{
	return TKey::IsPressed(SDL_SCANCODE_F9);
}
bool TGL_APP::kb_f10()
{
	return TKey::IsPressed(SDL_SCANCODE_F10);
}
bool TGL_APP::kb_f11()
{
	return TKey::IsPressed(SDL_SCANCODE_F11);
}
bool TGL_APP::kb_f12()
{
	return TKey::IsPressed(SDL_SCANCODE_F12);
}

//=============================================================================
//		TGL_PRIVATE
//=============================================================================

TGL_PRIVATE::TGL_PRIVATE(TGL_APP* tgl_app)
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

	this->tgl_app = tgl_app;

	perfmon.fps_starttime = SDL_GetTicks();
}
TGL_PRIVATE::~TGL_PRIVATE()
{
	delete wnd;
	wnd = nullptr;
	delete snd_notes;
	snd_notes = nullptr;
	delete snd_files;
	snd_files = nullptr;
}
void TGL_PRIVATE::process_default_events(SDL_Event* e)
{
	SDL_PollEvent(e);

	if (e->type == SDL_QUIT) {
		tgl_app->exit();
	} else if (e->type == SDL_KEYDOWN) {
		auto key = e->key.keysym.sym;
		last_key = key;
		if (TKey::Alt() && key == SDLK_RETURN && wnd) {
			wnd->ToggleFullscreen();
		}
	}
}
void TGL_PRIVATE::create_window(int width, int height, rgb back_color, int size_factor)
{
	if (wnd) delete wnd;

	wnd = new TRGBWindow(
		width / TGL_TILESIZE, height / TGL_TILESIZE,
		size_factor, size_factor, back_color);

	wnd_back_color = back_color;
	wnd->SetTitle(title);
	wnd->Show();

	default_view = TGL_VIEW(0, 0, width - 1, height - 1, back_color, true);
	cur_view = &default_view;
	frame_counter = 0;
	is_running = true;
}
void TGL_PRIVATE::draw_frame()
{
	on_draw_frame_begin();
	wnd->Update();
	on_draw_frame_end();
}
void TGL_PRIVATE::on_draw_frame_begin()
{
}
void TGL_PRIVATE::on_draw_frame_end()
{
	frame_counter++;
	
	perfmon.fps_frames++;
	perfmon.fps_lasttime = SDL_GetTicks() - perfmon.fps_starttime;
	if (perfmon.fps_lasttime) {
		double elapsed_sec = perfmon.fps_lasttime / 1000.0;
		perfmon.fps_current = perfmon.fps_frames / elapsed_sec;
	}
}
void TGL_PRIVATE::clip(int x1, int y1, int x2, int y2)
{
	wnd->SetClip(x1, y1, x2, y2);
}
void TGL_PRIVATE::unclip()
{
	wnd->RemoveClip();
}
void TGL_PRIVATE::clear_entire_window()
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
void TGL_PRIVATE::clear_current_view()
{
	rgb prev_back_color = cur_view->back_color;
	wnd->SetBackColor(cur_view->back_color);
	wnd->ClearBackground();
	wnd->SetBackColor(prev_back_color);
}
void TGL_PRIVATE::print(std::string str, int x, int y, bool tiled)
{
	if (tiled) {
		x *= TGL_TILESIZE;
		y *= TGL_TILESIZE;
	}
	int char_x = cur_view ? x - cur_view->scroll_x : x;
	int char_y = cur_view ? y - cur_view->scroll_y : y;

	if (wnd->HasClip()) {
		char_x += wnd->GetClip().X1;
		char_y += wnd->GetClip().Y1;
	}

	for (auto& ch : str) {
		std::string& pixels = font_tiles[ch].bits;
		
		if (text_style.shadow_enabled) {
			wnd->DrawChar8x8(pixels, text_style.shadow_color, text_style.back_color,
				true, char_x + 1, char_y + 1, false);
		}
		wnd->DrawChar8x8(pixels, text_style.fore_color, text_style.back_color,
			text_style.transparent, char_x, char_y, false);

		char_x += TGL_TILESIZE;
	}
}
bool TGL_PRIVATE::is_valid_gpad_selected()
{
	return gamepad.Number >= 0 && gamepad.Number < gamepad.CountOpen();
}
void TGL_PRIVATE::font(char ch, std::string pattern)
{
	font_tiles[ch] = pattern;
}
void TGL_APP::gpad_redetect()
{
	tgl->gamepad.OpenAllAvailable();
}
int TGL_APP::gpad_count()
{
	return tgl->gamepad.CountOpen();
}
bool TGL_APP::gpad_connected(int number)
{
	return number >= 0 && number < tgl->gamepad.CountOpen();
}
bool TGL_APP::gpad(int number)
{
	if (number >= 0 && number < tgl->gamepad.CountOpen()) {
		tgl->gamepad.Number = number;
		return true;
	}
	return false;
}
bool TGL_APP::gpad_right()
{
	return tgl->is_valid_gpad_selected() ? 
		tgl->gamepad.Right() || tgl->gamepad.AxisLX() == SDL_JOYSTICK_AXIS_MAX : false;
}
bool TGL_APP::gpad_left()
{
	return tgl->is_valid_gpad_selected() ? 
		tgl->gamepad.Left() || tgl->gamepad.AxisLX() == SDL_JOYSTICK_AXIS_MIN : false;
}
bool TGL_APP::gpad_down()
{
	return tgl->is_valid_gpad_selected() ? 
		tgl->gamepad.Down() || tgl->gamepad.AxisLY() == SDL_JOYSTICK_AXIS_MAX : false;
}
bool TGL_APP::gpad_up()
{
	return tgl->is_valid_gpad_selected() ? 
		tgl->gamepad.Up() || tgl->gamepad.AxisLY() == SDL_JOYSTICK_AXIS_MIN : false;
}
bool TGL_APP::gpad_a()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.A() : false;
}
bool TGL_APP::gpad_b()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.B() : false;
}
bool TGL_APP::gpad_x()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.X() : false;
}
bool TGL_APP::gpad_y()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.Y() : false;
}
bool TGL_APP::gpad_l()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.L() || tgl->gamepad.AxisLT() : false;
}
bool TGL_APP::gpad_r()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.R() || tgl->gamepad.AxisRT() : false;
}
bool TGL_APP::gpad_start()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.Start() : false;
}
bool TGL_APP::gpad_select()
{
	return tgl->is_valid_gpad_selected() ? tgl->gamepad.Select() : false;
}
void TGL_PRIVATE::init_default_font()
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
std::string TGL_PRIVATE::line_input(int length, int x, int y, bool tiled, callback fn)
{
	bool prev_shadow_enabled = text_style.shadow_enabled;
	bool prev_transparent = text_style.transparent;
	rgb prev_fore_color = text_style.fore_color;
	rgb prev_back_color = text_style.back_color;

	text_input.cancelled = false;
	std::string blanks = String::Repeat(' ', length + 1);
	std::string text = text_input.placeholder;

	bool finished = false;
	while (is_running && !finished) {

		text_style.shadow_enabled = false;
		text_style.transparent = false;
		text_style.fore_color = text_input.fore_color;
		text_style.back_color = text_input.back_color;

		print(blanks, x, y, tiled);
		print(text + text_input.cursor, x, y, tiled);

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

	text_style.shadow_enabled = prev_shadow_enabled;
	text_style.transparent = prev_transparent;
	text_style.fore_color = prev_fore_color;
	text_style.back_color = prev_back_color;

	last_key = 0; // Clear last key, so as not to interfere with the kb_inkey function

	return text;
}
char TGL_PRIVATE::keycode_to_char(SDL_Keycode key)
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
bool TGL_PRIVATE::is_shade_of_gray(TColor& color)
{
	return color.R == color.G && color.G == color.B;
}
int TGL_PRIVATE::get_gray_level(TColor& color)
{
	if (is_shade_of_gray(color))
		return color.R;
	else
		return -1;
}
