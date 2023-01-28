//=============================================================================
//		TGL	- TileGameLib
//		2018-2023 (C) developed by Fernando Aires Castello
//=============================================================================
#pragma once
#include "TGL_global.h"
#include "TGL_tile.h"

struct TGL
{
	void init();
	int exit();
	int halt();
	bool sysproc();
	void screen(int width, int height, int hstr, int vstr, rgb back_color);
	void bgcolor(rgb color);
	void clip(int x1, int y1, int x2, int y2);
	void unclip();
	void cls();
	void draw(tile& tile, int x, int y);

private:
	TGL_Internal::TRGBWindow* wnd = nullptr;

	SDL_Keycode kb_last = 0;

	bool process_default_events(SDL_Event* e);
};
