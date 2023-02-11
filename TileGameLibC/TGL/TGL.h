#pragma once
#include <SDL.h>
#include "TGL_global.h"

struct TGL
{
	void init();
	int exit();
	void system();
	int halt();
	void pause(int ms);
	void window(rgb back_color);
	void window(rgb back_color, int size_factor);
	void title(string str);
	void error(string msg);
	void abort(string msg);
	void clear();
	void update();
	void tile_pat(string pattern_id, string pixels);
	void tile_new(string tile_id);
	void tile_add(string tile_id, string pattern_id);
	void view_new(string view_id, int x1, int y1, int x2, int y2, rgb back_color, bool clear_bg);
	void view_new(string view_id, rgb back_color);
	void view(string view_id);
	void scroll(int dx, int dy);
	int scroll_x();
	int scroll_y();
	void color(rgb c1, rgb c2, rgb c3);
	void color(rgb c0, rgb c1, rgb c2, rgb c3);
	void draw_free(string tile_id, int x, int y);
	void draw_tiled(string tile_id, int col, int row);
	void font(char ch, string pattern);
	void print_free(string str, int x, int y);
	void print_tiled(string str, int col, int row);
	bool kb_right();
	bool kb_left();
	bool kb_down();
	bool kb_up();
	bool kb_ctrl();
	bool kb_esc();
	bool kb_char(char ch);

private:

	TGL_Internal::TRGBWindow* wnd = nullptr;
	
	struct {
		int x = 0;
		int y = 0;
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

	struct viewport {
		int x1 = 0;
		int y1 = 0;
		int x2 = 0;
		int y2 = 0;
		int scroll_x = 0;
		int scroll_y = 0;
		rgb back_color = 0x000000;
		bool clear_bg = true;
	};

	unordered_map<string, string> tile_patterns;
	unordered_map<string, tileseq> tiles;
	unordered_map<char, string> font_patterns;
	unordered_map<string, viewport> views;
	viewport* cur_view = nullptr;

	void process_default_events(SDL_Event* e);
	void create_window(rgb back_color, int size_factor);
	bool assert_tile_exists(string& id);
	bool assert_tilepattern_exists(string& id);
	bool assert_view_exists(string& id);
	void clip(int x1, int y1, int x2, int y2);
	void unclip();
	void clear_view();
	void pos_free(int x, int y);
	void pos_tiled(int x, int y);
	void draw(string& tile_id);
	void print(string& str);
};
