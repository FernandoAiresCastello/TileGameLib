#pragma once
#include <SDL.h>
#include "TGL_global.h"

struct TGL
{
	void init();
	int exit();
	int halt();
	bool sysproc();

	void window();
	void clip(int x1, int y1, int x2, int y2);
	void unclip();
	void clear();
	void bgcolor(rgb color);
	void pattern(string id, string pixels);
	void tile(string tile_id, string pat1_id);
	void tile(string tile_id, string pat1_id, string pat2_id);
	void tile(string tile_id, string pat1_id, string pat2_id, string pat3_id);
	void tile(string tile_id, string pat1_id, string pat2_id, string pat3_id, string pat4_id);
	void pos_free(int x, int y);
	void pos_tiled(int x, int y);
	void scroll(int dx, int dy);
	void color(rgb c1, rgb c2, rgb c3);
	void color(rgb c0, rgb c1, rgb c2, rgb c3);
	void draw(string tile_id);
	bool kb_right();
	bool kb_left();
	bool kb_down();
	bool kb_up();
	bool kb_ctrl();

private:

	TGL_Internal::TRGBWindow* wnd = nullptr;
	
	struct {
		int x = 0;
		int y = 0;
		int scroll_x = 0;
		int scroll_y = 0;
	} cursor;

	struct {
		rgb c0 = 0x000000;
		rgb c1 = 0xffffff;
		rgb c2 = 0x808080;
		rgb c3 = 0x202020;
		bool ignore_c0 = false;
	} palette;

	struct tileseq {
		vector<string> pattern_ids;
	};

	map<string, string> tile_patterns;
	map<string, tileseq> tiles;

	bool process_default_events(SDL_Event* e);
	void reset_cursor();
};
