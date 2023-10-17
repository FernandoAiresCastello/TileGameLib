#pragma once
#include "TGL.h"
#include "Internal/TSoundFiles.h"
using namespace TGL_Internal;

constexpr int TGL_FONTSIZE = 256;

struct TGL_PRIVATE
{
private:
	friend struct TGL_APP;

	TGL_PRIVATE(TGL_APP* tgl_app);
	~TGL_PRIVATE();

	struct {
		rgb fore_color = 0xffffff;
		rgb back_color = 0x000000;
		bool transparent = true;
		bool shadow_enabled = false;
		rgb shadow_color = 0x000000;
	} text_style;

	struct {
		rgb fore_color = 0xffffff;
		rgb back_color = 0x000000;
		bool cancelled = false;
		char cursor = '_';
	} text_input;

	struct {
		Uint32 fps_starttime = 0;
		Uint32 fps_lasttime = 0;
		Uint32 fps_current = 0;
		Uint32 fps_frames = 0;
	} perfmon;

	TGL_APP* tgl_app = nullptr;
	TRGBWindow* wnd = nullptr;
	TSound* snd_notes = nullptr;
	TSoundFiles* snd_files = nullptr;
	bool is_running;
	std::string title;
	int frame_counter;
	rgb wnd_back_color;
	TGL_TILE_BIN font_tiles[TGL_FONTSIZE];
	TGL_VIEW* cur_view = nullptr;
	TGL_VIEW default_view;
	TGamepad gamepad;
	SDL_Keycode last_key = 0;

	void process_default_events(SDL_Event* e);
	void create_window(int width, int height, rgb back_color, int size_factor);
	void clip(int x1, int y1, int x2, int y2);
	void unclip();
	void draw_frame();
	void on_draw_frame_begin();
	void on_draw_frame_end();
	void clear_entire_window();
	void clear_current_view();
	void print(std::string str, int x, int y, bool tiled);
	bool is_valid_gpad_selected();
	void font(char ch, std::string pattern);
	void init_default_font();
	std::string line_input(int length, int x, int y, bool tiled, callback fn);
	char keycode_to_char(SDL_Keycode key);
	bool is_shade_of_gray(TColor& color);
	int get_gray_level(TColor& color);
	void adjust_pos(int& x, int& y);
};
