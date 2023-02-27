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

struct TGL
{
	TGL();
	~TGL();

	//=========================================================================
	//		CONSTANTS
	//=========================================================================
	const int tilesize;
	const int width;
	const int height;
	const int cols;
	const int rows;

	//=========================================================================
	//		SYSTEM
	//=========================================================================
	void system();
	int exit();
	int halt();
	void pause(int ms);
	bool running();
	void error(string msg);
	void abort(string msg);

	//=========================================================================
	//		GRAPHICS > WINDOW
	//=========================================================================
	void window(rgb back_color = 0xffffff, int size_factor = 5);
	void title(string str);
	void fullscreen(bool full);
	bool fullscreen();
	void screenshot(string path);
	int window_width();
	int window_height();

	//=========================================================================
	//		GRAPHICS > VIEWS
	//=========================================================================
	void clear();
	void view_new(string view_id, int x1, int y1, int x2, int y2, rgb back_color, bool clear_bg);
	void view_default();
	void view(string view_id);
	void scroll(int dx, int dy);
	void scroll_to(int x, int y);
	int scroll_x();
	int scroll_y();

	//=========================================================================
	//		GRAPHICS > TILE SET
	//=========================================================================
	void tile_pat(string pattern_id, string pixels);
	void tile_add(string tile_id, string pattern_id);

	//=========================================================================
	//		GRAPHICS > COLOR MODES
	//=========================================================================
	void color_single(rgb c1);
	void color_sprite(rgb c1, rgb c2, rgb c3);
	void color_normal(rgb c0, rgb c1, rgb c2, rgb c3);

	//=========================================================================
	//		GRAPHICS > TILE RENDERING
	//=========================================================================
	void draw_free(string tile_id, int x, int y);
	void draw_tiled(string tile_id, int col, int row);

	//=========================================================================
	//		GRAPHICS > TEXT RENDERING
	//=========================================================================
	void font(char ch, string pattern);
	void font_shadow(bool shadow, rgb shadow_color = 0x000000);
	void font_reset();
	void font_new();
	void print_free(string str, int x, int y);
	void print_tiled(string str, int col, int row);

	//=========================================================================
	//		SOUND
	//=========================================================================
	void volume(int vol);
	void play(string notes);
	void play_loop(string notes);
	void play_stop();
	void sound(float freq, int len);

	//=========================================================================
	//		TIMERS
	//=========================================================================
	void timer_new(string timer_id, int frames, bool loop);
	bool timer(string timer_id);

	//=========================================================================
	//		STRING MANIPULATION
	//=========================================================================
	string fmt(const char* str, ...);

	//=========================================================================
	//		MATH
	//=========================================================================
	int rnd(int min, int max);

	//=========================================================================
	//		COLLISION DETECTION
	//=========================================================================
	bool collision(int tile1_x, int tile1_y, int tile2_x, int tile2_y);

	//=========================================================================
	//		INPUT > MOUSE
	//=========================================================================
	void mouse(bool enabled);
	int mouse_x();
	int mouse_y();

	//=========================================================================
	//		INPUT > KEYBOARD
	//=========================================================================
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
};
