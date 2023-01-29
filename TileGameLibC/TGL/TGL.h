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
	/*** SYSTEM ***/
	
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

	/*** GRAPHICS ***/

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
	
	/*** KEYBOARD ***/

	bool kb_right();
	bool kb_left();
	bool kb_down();
	bool kb_up();
	bool kb_space();
	bool kb_enter();
	bool kb_bs();
	bool kb_tab();
	bool kb_shift();
	bool kb_ctrl();
	bool kb_alt();
	bool kb_caps();
	bool kb_ins();
	bool kb_del();
	bool kb_home();
	bool kb_end();
	bool kb_pgup();
	bool kb_pgdn();
	bool kb_esc();
	bool kb_char(char ch);
	bool kb_code(int code);

private:
	TGL_Internal::TRGBWindow* wnd;
	TGL_Internal::TGamepad gpad;
	
	string wnd_title;
	SDL_Keycode kb_last;
	bool has_gpad;

	bool process_default_events(SDL_Event* e);
};
