/*=============================================================================

	TGL.h

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
#ifndef _TGL_H_
#define _TGL_H_

#include <stdbool.h>

//==============================================================================
//      TYPES
//==============================================================================
typedef unsigned int rgb;
typedef unsigned char byte;

//==============================================================================
//      SYSTEM
//==============================================================================
void tgl_init();
void tgl_exit();
void tgl_abort(char* msg);
void tgl_halt();
void tgl_update();
void tgl_hcf();
void tgl_title(char* title);

//==============================================================================
//      SCREEN
//==============================================================================
void tgl_screen(int buf_width, int buf_height, int wnd_size, rgb back_color);
void tgl_screen_128x128(int wnd_size, rgb back_color);
void tgl_screen_160x144(int wnd_size, rgb back_color);
void tgl_screen_256x192(int wnd_size, rgb back_color);
void tgl_screen_360x200(int wnd_size, rgb back_color);
void* tgl_window();
void tgl_fullscreen(bool full);
void tgl_toggle_fullscreen();
void tgl_backcolor(rgb color);
void tgl_clear();
int tgl_width();
int tgl_height();
int tgl_cols();
int tgl_rows();
void tgl_clip(int x1, int y1, int x2, int y2);
void tgl_unclip();

//==============================================================================
//      SCREEN MODES
//==============================================================================
void tgl_mode_rgb();
void tgl_mode_bin();

//==============================================================================
//      COLOR
//==============================================================================
byte tgl_color_r(rgb color);
byte tgl_color_g(rgb color);
byte tgl_color_b(rgb color);
rgb tgl_color_rgb(byte r, byte g, byte b);
void tgl_color(rgb fore_color, rgb back_color);
void tgl_transparent(bool flag);

//==============================================================================
//      TILE SET
//==============================================================================
void tgl_tileset(int size);
void tgl_tile_rgb(int index, rgb* pixels);
void tgl_tile_bin(int index, char* pixels);
void tgl_tile_rgb_load(int index, char* file);

//==============================================================================
//      TILE DRAWING
//==============================================================================
void tgl_draw_free(int tile_index, int x, int y);
void tgl_draw_tiled(int tile_index, int x, int y);

//==============================================================================
//      TEXT DRAWING
//==============================================================================
void tgl_font_clear();
void tgl_font(int char_index, char* pixels);
void tgl_print_free(char* str, int x, int y);
void tgl_print_tiled(char* str, int x, int y);

//==============================================================================
//      STRINGS
//==============================================================================
char* tgl_fmt(char* str, ...);

//==============================================================================
//      MATH
//==============================================================================
int tgl_rnd(int min, int max);

//==============================================================================
//      SOUND
//==============================================================================
void tgl_sound_load(int index, char* file);
void tgl_sound_play(int index);

//==============================================================================
//      KEYBOARD
//==============================================================================
int tgl_inkey();
bool tgl_key(int scancode);
bool tgl_kshift();
bool tgl_kctrl();
bool tgl_kalt();
bool tgl_kcaps();

#endif
