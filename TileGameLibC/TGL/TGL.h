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
	void screen(int width, int height, int hstr, int vstr);
	void bgcolor(rgb color);

private:
	TGL_Internal::TRGBWindow* wnd = nullptr;

	SDL_Keycode kb_last = 0;

	bool process_default_events(SDL_Event* e);
	void render_frame();
};
