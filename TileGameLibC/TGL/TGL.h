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
	void window();
	void window(rgb back_color);
	void window(rgb back_color, int size_factor);
	void title(string str);
	int width();
	int height();
	int tilesize();
	int cols();
	int rows();
	void mouse_on();
	void mouse_off();
	void error(string msg);
	void abort(string msg);
	void clear();
	void tile_pat(string pattern_id, string pixels);
	void tile_add(string tile_id, string pattern_id);
	void view_new(string view_id, int x1, int y1, int x2, int y2, rgb back_color, bool clear_bg);
	void view(string view_id);
	void scroll(int dx, int dy);
	void scroll_to(int x, int y);
	int scroll_x();
	int scroll_y();
	void color(rgb c1, rgb c2, rgb c3);
	void color(rgb c0, rgb c1, rgb c2, rgb c3);
	void draw_free(string tile_id, int x, int y);
	void draw_tiled(string tile_id, int col, int row);
	void font(char ch, string pattern);
	void print_free(string str, int x, int y);
	void print_tiled(string str, int col, int row);
	int rnd(int min, int max);
	void timer_new(string timer_id, int cycles, bool loop);
	bool timer(string timer_id);
	bool kb_right();
	bool kb_left();
	bool kb_down();
	bool kb_up();
	bool kb_ctrl();
	bool kb_esc();
	bool kb_space();
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
		rgb c2 = 0xc0c0c0;
		rgb c3 = 0x808080;
		bool ignore_c0 = false;
	} palette;

	struct t_tileseq {
		vector<string> pattern_ids;
	};

	struct t_viewport {
		int x1 = 0;
		int y1 = 0;
		int x2 = 0;
		int y2 = 0;
		int scroll_x = 0;
		int scroll_y = 0;
		rgb back_color = 0x000000;
		bool clear_bg = true;
	};

	struct t_timer {
		int cycles_max = 0;
		int cycles_elapsed = 0;
		bool loop = false;
	};

	unordered_map<string, string> tile_patterns;
	unordered_map<string, t_tileseq> tiles;
	unordered_map<char, string> font_patterns;
	unordered_map<string, t_viewport> views;
	t_viewport* cur_view = nullptr;
	unordered_map<string, t_timer> timers;

	void process_default_events(SDL_Event* e);
	void create_window(rgb back_color, int size_factor);
	bool assert_tile_exists(string& id);
	bool assert_tilepattern_exists(string& id);
	bool assert_view_exists(string& id);
	void clip(int x1, int y1, int x2, int y2);
	void unclip();
	void update();
	void clear_view();
	void pos_free(int x, int y);
	void pos_tiled(int x, int y);
	void draw(string& tile_id);
	void print(string& str);
	void advance_timers();
};
