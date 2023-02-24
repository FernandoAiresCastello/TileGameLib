#pragma once
#include "TGL.h"

struct TGL_Private
{
private:
	friend struct TGL;

	TGL_Private(TGL* tgl_public);
	~TGL_Private();

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

	struct {
		bool enabled;
		rgb color;
	} text_shadow;

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

	TGL* tgl_public = nullptr;
	TRGBWindow* wnd = nullptr;
	TSound* snd = nullptr;
	bool is_running;
	string title;
	rgb wnd_back_color;
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
	void clear_entire_window();
	void clear_view();
	void pos_free(int x, int y);
	void pos_tiled(int x, int y);
	void draw(string& tile_id);
	void print(string& str);
	void advance_timers();
	void font(char ch, string pattern);
	void init_default_font();
};
