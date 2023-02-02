//=============================================================================
//		TGL	(TileGameLib)
//		2018-2023 Developed by Fernando Aires Castello
//=============================================================================
#pragma once
#include "TGL_global.h"
#include "TGL_tile.h"
#include "TGL_tile_f.h"
#include "TGL_tilemap.h"
#include "TGL_sprite.h"
#include "TGL_spritelist.h"

struct TGL
{
	/*** SYSTEM ***/
	
	void init();
	int exit();
	int halt();
	bool sysproc();
	void title(string title);

	/*** GRAPHICS ***/

	void screen(int width, int height, int hstr, int vstr, rgb back_color);
	void bgcolor(rgb color);
	void clip(int x1, int y1, int x2, int y2);
	void unclip();
	void cls();
	void draw_tile(tile* tile, int x, int y);
	void draw_tilemap(tilemap* tilemap);
	void draw_sprite(sprite* sprite);
	void draw_spritelist(spritelist* sprlist);
	
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

	/*** MOUSE ***/

	void mouse_hide();
	void mouse_show();
	int mouse_x();
	int mouse_y();
	int mouse_x_clip();
	int mouse_y_clip();
	bool mouse_left();
	bool mouse_right();

	/*** SOUND ***/

	void play(string notes);
	void play_loop(string notes);
	void sound(float freq, int length);
	void vol(int vol);
	void quiet();

	/*** UTIL ***/

	int rnd(int min, int max);

private:

	TGL_Internal::TRGBWindow* wnd;
	TGL_Internal::TGamepad gpad;
	TGL_Internal::TSound snd;
	
	string wnd_title;
	SDL_Keycode kb_last;
	bool has_gpad;

	bool process_default_events(SDL_Event* e);
	void drawtile_internal(tile* tile, int x, int y, bool ignore_c0);
	void drawtilemap_internal(tilemap* tilemap, bool ignore_c0);
};
