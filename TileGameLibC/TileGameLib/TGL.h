/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once

#include "TGLGlobal.h"
#include "TGLKeyboard.h"
#include "TGLTile.h"
#include "TGLCursor.h"
#include "TGLFile.h"
#include "TGLString.h"

struct TGL
{
	TGLKeyboard kb;
	TGLCursor csr;
	TGLFile file;
	TGLString str;

	void init();
	int exit();
	int halt();
	bool sysproc();
	void screen(int cols, int rows, int layers, int hstr, int vstr);
	void title(string title);
	void bgcol(rgb color);
	void cls();
	void vsync();
	void locate(int x, int y);
	void tron();
	void troff();
	void grid();
	void ungrid();
	void draw(tile& tile);
	void pause(int ms);
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
	TRGBWindow* wnd = nullptr;
	bool ignore_pixel_c0 = false;
	bool align_to_grid = true;
	TSound snd;

	bool process_default_events(SDL_Event* e);
};
