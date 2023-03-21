/*=============================================================================

	TileGameLib (TGL)

	https://github.com/FernandoAiresCastello/TileGameToolkit

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
#pragma once

#include <SDL.h>
#include <string>
#include <vector>
#include <map>
#include <unordered_map>
#include <cstdarg>
using namespace std;

typedef int rgb;
typedef unsigned char byte;

struct TGL
{
	TGL();
	~TGL();

	//=========================================================================
	//		CONSTANTS
	//=========================================================================
	const int tilesize;

	//=========================================================================
	//		SYSTEM
	//=========================================================================
	void update();
	int exit();
	int halt(void(*fn)() = nullptr);
	void pause(int ms, void(*fn)() = nullptr);
	bool running();
	void error(string msg);
	void abort(string msg);
	string date();
	string time();
	string datetime();

	//=========================================================================
	//		GRAPHICS > WINDOW
	//=========================================================================
	void window(int img_width, int img_height, rgb back_color, int size_factor);
	void window_gbc(rgb back_color, int size_factor);
	void window_wide(rgb back_color, int size_factor);
	void title(string str);
	void backcolor(rgb back_color);
	void clear();
	void fullscreen(bool full);
	bool fullscreen();
	void screenshot(string path);
	int width();
	int height();
	int cols();
	int rows();

	//=========================================================================
	//		GRAPHICS > VIEWS
	//=========================================================================
	void view_default();
	void view_new(string view_id, int x1, int y1, int x2, int y2, rgb back_color, bool clear_bg);
	void view(string view_id);
	void scroll(int dx, int dy);
	void scroll_to(int x, int y);
	int scroll_x();
	int scroll_y();

	//=========================================================================
	//		GRAPHICS > COLOR MODES
	//=========================================================================
	void color_normal();
	void color_binary(rgb fore_color);
	void color_binary(rgb fore_color, rgb back_color);

	//=========================================================================
	//		GRAPHICS > TILE SET
	//=========================================================================
	void tile_new(string img_id, rgb pixels[64]);
	void tile_new(string img_id, string binary_pattern);
	void tile_load(string img_id, string path);
	void tile_add(string tile_id, string img_id, int count = 1);
	void tile_transparent(bool state);
	void tile_transparency_key(rgb color);
	void tile_replace_color(string img_id, rgb original_color, rgb new_color);

	//=========================================================================
	//		GRAPHICS > TILE RENDERING
	//=========================================================================
	void draw_free(string tile_id, int x, int y);
	void draw_tiled(string tile_id, int col, int row);

	//=========================================================================
	//		GRAPHICS > TEXT RENDERING
	//=========================================================================
	void font(char ch, string pattern);
	void font_new();
	void font_reset();
	void font_color(rgb color);
	void font_color(rgb fore_color, rgb back_color);
	void font_shadow(bool shadow, rgb shadow_color = 0x000000);
	void font_transparent(bool state);
	void print_free(string str, int x, int y);
	void print_tiled(string str, int col, int row);

	//=========================================================================
	//		SOUND
	//=========================================================================
	void play_volume(int vol);
	void play_notes(string notes);
	void play_notes_loop(string notes);
	void play_notes_stop();
	void beep(float freq, int len);
	void sound_load(string sound_id, string file);
	void sound(string sound_id);
	void sound_await(string sound_id);
	void sound_stop();

	//=========================================================================
	//		TIMERS
	//=========================================================================
	void timer_new(string timer_id, int frames, bool loop);
	bool timer(string timer_id);
	void timer_reset(string timer_id);

	//=========================================================================
	//		STRING MANIPULATION
	//=========================================================================
	string fmt(const char* str, ...);
	string ucase(string str);
	string lcase(string str);
	string trim(string str);
	vector<string> split(string str, char delim);
	string join(vector<string>& str, string separator);
	int to_int(string str);
	string to_string(int value);
	string substr(string str, int first, int last);
	string replace(string str, string original, string replacement);
	bool starts_with(string str, string prefix);
	bool ends_with(string str, string suffix);
	bool contains(string str, string other);
	int indexof(string str, char ch);

	//=========================================================================
	//		MATH
	//=========================================================================
	int rnd(int min, int max);
	bool rnd_chance(int percent);

	//=========================================================================
	//		COLLISION DETECTION
	//=========================================================================
	bool collision(int tile1_x, int tile1_y, int tile2_x, int tile2_y);

	//=========================================================================
	//		FILESYSTEM
	//=========================================================================
	bool file_exists(string path);
	bool folder_exists(string folder_path);
	string file_cload(string path);
	vector<string> file_lines(string path);
	void file_appendln(string path, string text);
	vector<byte> file_bload(string path);
	void file_csave(string path, string text);
	void file_bsave(string path, vector<byte>& bytes);
	vector<string> file_list(string folder_path);
	vector<string> folder_list(string folder_path);
	void file_copy(string src_path, string dest_path);
	void file_delete(string path);

	//=========================================================================
	//		INPUT > TEXT
	//=========================================================================
	void input_color(rgb foreground, rgb background);
	void input_cursor(char ch);
	string input_free(int length, int x, int y, void(*fn)() = nullptr);
	string input_tiled(int length, int col, int row, void(*fn)() = nullptr);
	bool input_confirmed();

	//=========================================================================
	//		INPUT > MOUSE
	//=========================================================================
	void mouse(bool enabled);
	int mouse_x();
	int mouse_y();
	bool mouse_right();
	bool mouse_left();
	bool mouse_middle();

	//=========================================================================
	//		INPUT > KEYBOARD
	//=========================================================================
	int kb_lastkey();
	bool kb_char(char ch);
	bool kb_right();
	bool kb_left();
	bool kb_down();
	bool kb_up();
	bool kb_ctrl();
	bool kb_shift();
	bool kb_alt();
	bool kb_capslock();
	bool kb_esc();
	bool kb_space();
	bool kb_backspace();
	bool kb_enter();
	bool kb_tab();
	bool kb_insert();
	bool kb_delete();
	bool kb_home();
	bool kb_end();
	bool kb_pageup();
	bool kb_pagedown();
	bool kb_pausebrk();
	bool kb_printscr();
	bool kb_f1();
	bool kb_f2();
	bool kb_f3();
	bool kb_f4();
	bool kb_f5();
	bool kb_f6();
	bool kb_f7();
	bool kb_f8();
	bool kb_f9();
	bool kb_f10();
	bool kb_f11();
	bool kb_f12();

	//=========================================================================
	//		INPUT > GAMEPAD
	//=========================================================================
	void gpad_redetect();
	int gpad_count();
	bool gpad_connected(int number);
	bool gpad(int number);
	bool gpad_right();
	bool gpad_left();
	bool gpad_down();
	bool gpad_up();
	bool gpad_a();
	bool gpad_b();
	bool gpad_x();
	bool gpad_y();
	bool gpad_l();
	bool gpad_r();
	bool gpad_start();
	bool gpad_select();

	//=========================================================================
	//		DEBUGGING
	//=========================================================================
	void print_debug(string str, int x, int y, rgb color);
	void show_fps(bool show);
};
