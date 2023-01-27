/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include "TGLGlobal.h"
#include "TGLKeyboard.h"
#include "TGLTile.h"
#include "TGLFile.h"
#include "TGLString.h"
#include "TGLView.h"

struct TGL_Old
{
	TGLKeyboard kb;
	TGLFile file;
	TGLString str;

	void init();
	int exit();
	int halt();
	bool sysproc();
	void screen(int cols, int rows, int hstr, int vstr);
	void title(string title);
	void bgcol(rgb color);
	void cls();
	void vsync();
	void view(struct view& view);
	void rview();
	void coord(int x, int y);
	void cell(int col, int row);
	void draw(tile& tile);
	void pause(int ms);
	int rnd(int min, int max);
	void sfx(string notes);
	void music(string notes);
	void sound(float freq, int len);
	void quiet();
	void vol(int value);
	void error(string msg);
	void abort(string msg);

private:
	TRGBWindow* wnd = nullptr;
	TSound snd;

	bool process_default_events(SDL_Event* e);
};
