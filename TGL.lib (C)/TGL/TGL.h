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

typedef unsigned int rgb;
typedef unsigned char byte;

void tgl_init(int buf_width, int buf_height, int wnd_size, rgb back_color);
void tgl_exit();
void tgl_halt();
void tgl_proc_default_events();
void tgl_update();
void tgl_fullscreen(bool full);
void tgl_toggle_fullscreen();
void tgl_clear();
int tgl_width();
int tgl_height();
byte tgl_color_r(rgb color);
byte tgl_color_g(rgb color);
byte tgl_color_b(rgb color);
rgb tgl_color_rgb(byte r, byte g, byte b);
void tgl_pset(int x, int y, rgb rgb);
int tgl_rnd(int min, int max);
void tgl_test_static();

#endif
