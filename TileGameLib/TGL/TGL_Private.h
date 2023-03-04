#pragma once
#include "TGL.h"
#include "Internal/TSoundFiles.h"
using namespace TGL_Internal;

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
		rgb fore_color = 0xffffff;
		rgb back_color = 0x000000;
		bool transparent = true;
		bool shadow_enabled = false;
		rgb shadow_color = 0x000000;
	} font_style;

	struct {
		rgb fore_color = 0xffffff;
		rgb back_color = 0x000000;
		bool cancelled = false;
		char cursor = '_';
	} text_input;

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
		int frames_max = 0;
		int frames_elapsed = 0;
		bool loop = false;
	};

	struct {
		Uint32 fps_starttime = 0;
		Uint32 fps_lasttime = 0;
		Uint32 fps_current = 0;
		Uint32 fps_frames = 0;
	} perfmon;

	struct t_tileimg {
		rgb pixels[64];
	};

	struct {
		bool enabled = false;
		rgb key = 0xffffff;
	} tile_transparency;

	TGL* tgl_public = nullptr;
	TRGBWindow* wnd = nullptr;
	TSound* snd_notes = nullptr;
	TSoundFiles* snd_files = nullptr;
	bool is_running;
	string title;
	int frame_counter;
	bool fps_enabled = false;
	rgb wnd_back_color;
	unordered_map<string, t_tileimg> tile_img;
	unordered_map<string, t_tileseq> tile_seq;
	unordered_map<char, string> font_patterns;
	unordered_map<string, t_viewport> views;
	t_viewport* cur_view = nullptr;
	unordered_map<string, t_timer> timers;
	TGamepad gamepad;
	SDL_Keycode last_key = 0;

	void process_default_events(SDL_Event* e);
	void create_window(int width, int height, rgb back_color, int size_factor);
	bool assert_tileseq_exists(string& id);
	bool assert_tileimg_exists(string& id);
	bool assert_view_exists(string& id);
	void clip(int x1, int y1, int x2, int y2);
	void unclip();
	void draw_frame();
	void on_draw_frame_begin();
	void on_draw_frame_end();
	void clear_entire_window();
	void clear_view();
	void pos_free(int x, int y);
	void pos_tiled(int x, int y);
	void draw(string& tile_id);
	void print(string str);
	void advance_timers();
	bool is_valid_gpad_selected();
	void font(char ch, string pattern);
	void init_default_font();
	string line_input(int length, int x, int y, bool tiled);
	char keycode_to_char(SDL_Keycode key);
	bool is_shade_of_gray(TColor& color);
	int get_gray_level(TColor& color);
};
