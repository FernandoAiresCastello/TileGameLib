//=============================================================================
//
//		TileGameLib (TGL)
//		Developed by Fernando Aires Castello
//		https://github.com/FernandoAiresCastello/TileGameToolkit
//
//=============================================================================
#pragma once
#include <SDL.h>
#include <string>
#include <vector>
#include <map>
#include <unordered_map>
#include <cstdarg>
using namespace std;

//=============================================================================
//		TYPES
//=============================================================================
typedef int rgb;

struct TGL
{
	TGL();
	~TGL();

	//=========================================================================
	//		SYSTEM
	//=========================================================================
	void system();
	int exit();
	int halt();
	void pause(int ms);
	bool running();
	void error(string msg);
	void abort(string msg);

	//=========================================================================
	//		WINDOW
	//=========================================================================
	void window(rgb back_color = 0xffffff, int size_factor = 5);
	void title(string str);

	//=========================================================================
	//		GRAPHICS
	//=========================================================================
	void clear();
	void tile_pat(string pattern_id, string pixels);
	void tile_add(string tile_id, string pattern_id);
	void view_new(string view_id, int x1, int y1, int x2, int y2, rgb back_color, bool clear_bg);
	void view_default();
	void view(string view_id);
	void scroll(int dx, int dy);
	void scroll_to(int x, int y);
	int scroll_x();
	int scroll_y();
	void color(rgb c1);
	void color(rgb c1, rgb c2, rgb c3);
	void color(rgb c0, rgb c1, rgb c2, rgb c3);
	void draw_free(string tile_id, int x, int y);
	void draw_tiled(string tile_id, int col, int row);
	void screenshot(string path);
	int tilesize();
	int width();
	int height();
	int cols();
	int rows();

	//=========================================================================
	//		TEXT
	//=========================================================================
	void font(char ch, string pattern);
	void font_shadow(bool shadow, rgb shadow_color = 0);
	void font_reset();
	void font_new();
	void print_free(string str, int x, int y);
	void print_tiled(string str, int col, int row);

	//=========================================================================
	//		SOUND
	//=========================================================================
	void volume(int vol);
	void play(string notes);
	void play_loop(string notes);
	void play_stop();
	void sound(float freq, int len);

	//=========================================================================
	//		TIMERS
	//=========================================================================
	void timer_new(string timer_id, int cycles, bool loop);
	bool timer(string timer_id);

	//=========================================================================
	//		STRINGS
	//=========================================================================
	string fmt(const char* str, ...);

	//=========================================================================
	//		MATH
	//=========================================================================
	int rnd(int min, int max);

	//=========================================================================
	//		COLLISION DETECTION
	//=========================================================================
	bool collision(int obj1_x, int obj1_y, int obj2_x, int obj2_y);

	//=========================================================================
	//		MOUSE INPUT
	//=========================================================================
	void mouse_on();
	void mouse_off();
	int mouse_x();
	int mouse_y();

	//=========================================================================
	//		KEYBOARD INPUT
	//=========================================================================
	bool kb_char(char ch);
	bool kb_right();
	bool kb_left();
	bool kb_down();
	bool kb_up();
	bool kb_ctrl();
	bool kb_shift();
	bool kb_alt();
	bool kb_capslock();
	bool kb_esc();
	bool kb_space();
	bool kb_backspace();
	bool kb_enter();
	bool kb_tab();
	bool kb_insert();
	bool kb_delete();
	bool kb_home();
	bool kb_end();
	bool kb_pageup();
	bool kb_pagedown();
	bool kb_pausebrk();
	bool kb_printscr();
	bool kb_f1();
	bool kb_f2();
	bool kb_f3();
	bool kb_f4();
	bool kb_f5();
	bool kb_f6();
	bool kb_f7();
	bool kb_f8();
	bool kb_f9();
	bool kb_f10();
	bool kb_f11();
	bool kb_f12();

	//=========================================================================
	//		PRIVATE SECTION
	//=========================================================================
	private:
	
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

	bool is_running;
	string wnd_title;
	rgb wnd_back_color;
	unordered_map<string, string> tile_patterns;
	unordered_map<string, t_tileseq> tiles;
	unordered_map<char, string> font_patterns;
	unordered_map<string, t_viewport> views;
	t_viewport* cur_view = nullptr;
	unordered_map<string, t_timer> timers;

	void init();
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
	void init_default_font();
};
