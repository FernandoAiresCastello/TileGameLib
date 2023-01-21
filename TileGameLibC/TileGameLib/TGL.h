/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once

#include "TGLGlobal.h"
#include "TGLKeyboard.h"
#include "TGLTile.h"
#include "TGLBuffer.h"
#include "TGLPaletteAndTileset.h"
#include "TGLCursor.h"
#include "TGLFile.h"

struct TGL
{
	TGLKeyboard key;
	TGLTile tile;
	TGLBuffer buf;
	TGLPalette pal;
	TGLTileset chr;
	TGLCursor csr;
	TGLFile file;

	void init();
	void exit();
	void halt();
	bool global_proc();
	void screen(int cols, int rows, int layers, int hstr, int vstr);
	void title(string title);
	void wcol(colorid id);
	void cls();
	void cll();
	void clr(int x, int y, int w, int h);
	void vsync();
	void layer(int layer);
	void locate(int x, int y);
	void tron();
	void troff();
	void color(colorid fgc, colorid bgc);
	void fcolor(colorid id);
	void bcolor(colorid id);
	void print(const char* fmt, ...);
	void println(const char* fmt, ...);
	void print_raw(string text);
	void print_add(string text);
	void putc(char ch);
	void pause(int ms);
	void put();
	void put_r(int count);
	void put_d(int count);
	void put_l(int count);
	void put_u(int count);
	void get();
	void del();
	void rect(int x, int y, int w, int h);
	void fill();
	void mov(int dx, int dy);
	void movb(int x, int y, int w, int h, int dx, int dy);
	int rnd(int min, int max);
	void play(string notes);
	void play_loop(string notes);
	void sound(float freq, int len);
	void quiet();
	void vol(int value);
	string input(int maxlen);
	void error(string msg);
	void abort(string msg);

private:
	TBufferedWindow* wnd = nullptr;
	bool transparency = false;
	TSound snd;

	struct {
		int fg = 1;
		int bg = 0;
	} text_color;

	bool global_proc(SDL_Event* e);
	void print_tile_string(string text, bool raw, bool add_frames, int fgc, int bgc);
};
