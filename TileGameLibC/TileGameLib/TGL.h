/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include <vector>
#include <map>
#include "TileGameLib.h"
#include "TGLKeyboard.h"
#include "TGLTile.h"
#include "TGLBuffer.h"
#include "TGLPaletteAndTileset.h"
using namespace std;
using namespace TileGameLib;

extern struct TGL tgl;

struct TGL
{
	//============================================================================
	//									TGLAPI
	//============================================================================

	TGLKeyboard key;
	TGLTile tile;
	TGLBuffer buf;
	TGLPalette pal;
	TGLTileset chr;

	void init();
	void exit();
	void halt();
	bool global_proc();
	void screen(int cols, int rows, int layers, int hstr, int vstr);
	void title(string title);
	void wcol(int ix);
	void cls();
	void cll();
	void clr(int x, int y, int w, int h);
	void vsync();
	void layer(int layer);
	void locate(int x, int y);
	void tron();
	void troff();
	void color(int fgc, int bgc);
	void fcolor(int ix);
	void bcolor(int ix);
	void print(const char* fmt, ...);
	void println(const char* fmt, ...);
	void print_raw(string text);
	void print_add(string text);
	void pause(int ms);
	void put();
	void get();
	void del();
	void rect(int x, int y, int w, int h);
	void fill();
	void mov(int dx, int dy);
	void movb(int x, int y, int w, int h, int dx, int dy);
	int rnd(int min, int max);
	void play(string notes);
	void lplay(string notes);
	void sound(float freq, int len);
	void quiet();
	void vol(int value);
	string input(int maxlen);

	//============================================================================

private:
	TBufferedWindow* wnd = nullptr;
	bool transparency = false;
	TSound snd;

	struct {
		int layer = 0;
		int x = 0;
		int y = 0;
	} csr;

	struct {
		int fg = 1;
		int bg = 0;
	} text_color;

	bool global_proc(SDL_Event* e);
	void print_tile_string(string text, bool raw, bool add_frames, int fgc, int bgc);
};
