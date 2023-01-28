//=============================================================================
//		TGL	(TileGameLib)
//		2018-2023 Developed by Fernando Aires Castello
//=============================================================================
#pragma once
#include "TGL_global.h"
#include "TGL_tile.h"
#include "TGL_tile_f.h"
#include "TGL_tilemap.h"

struct TGL
{
	// Initialize the library
	void init();
	// Terminate program and close window
	int exit();
	// Stop program execution but keep window open
	int halt();
	// Execute the system procedure
	bool sysproc();
	// Set window title
	void title(string title);
	// Create the application window
	void screen(int width, int height, int hstr, int vstr, rgb back_color);
	// Set window background color
	void bgcolor(rgb color);
	// Enable drawing exclusively inside the bounds of the specified rectangular area
	void clip(int x1, int y1, int x2, int y2);
	// Enable drawing anywhere on the window
	void unclip();
	// Clear screen to background color
	void cls();
	// Draw a tile
	void drawtile(tile& tile, int x, int y);
	// Draw a tile map
	void drawtilemap(tilemap& tilemap, int x, int y);

private:
	TGL_Internal::TRGBWindow* wnd = nullptr;

	string wnd_title;
	SDL_Keycode kb_last = 0;

	bool process_default_events(SDL_Event* e);
};
