/*=============================================================================

	TGL.lib

	Part of the TileGameLib toolkit:
	https://github.com/FernandoAiresCastello/TileGameLib

	Copyright (c) 2019-2023 Fernando Aires Castello

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and /or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.

//============================================================================*/
#pragma once

#include <SDL.h>
#include <string>
#include <vector>
using namespace std;

/// Color represented as a 24-bit integer (0xRRGGBB)
typedef int rgb;

/// Byte value (0-255)
typedef unsigned char byte;

/// Pointer to callback procedure
typedef void(*callback)();

/// Width and height of a tile
constexpr int TGL_TILESIZE = 8;

/// Structure for an RGB tile
struct TGL_TILE_RGB
{
	rgb pixels[64];
	bool transparent = false;
	rgb transparency_key = 0xffffff;
	TGL_TILE_RGB();
	TGL_TILE_RGB(rgb pixels[64]);
	TGL_TILE_RGB(rgb pixels[64], rgb transparency_key);
};

/// Structure for a binary tile
struct TGL_TILE_BIN
{
	string bits;
	TGL_TILE_BIN();
	TGL_TILE_BIN(string bits);
};

/// Structure for a view
struct TGL_VIEW
{
	int x1 = 0;
	int y1 = 0;
	int x2 = 0;
	int y2 = 0;
	int scroll_x = 0;
	int scroll_y = 0;
	rgb back_color = 0x000000;
	bool clear_bg = true;
	TGL_VIEW();
	TGL_VIEW(int x1, int y1, int x2, int y2, rgb back_color, bool clear_bg = true);
	void scroll(int dx, int dy);
	void scroll_to(int x, int y);
};

/// Structure for a timer
struct TGL_TIMER
{
	int length = 0;
	int elapsed = 0;
	bool loop = false;
	TGL_TIMER(int length, bool loop);
	void tick();
	bool done();
};

/// Structure for a sound resource
struct TGL_SOUND
{
	string file;
};

/// Structure for the TGL application singleton
struct TGL_APP
{
	/// Create the application
	TGL_APP();
	/// Destroy the application
	~TGL_APP();

	//=========================================================================
	//		SYSTEM
	//=========================================================================

	/// Update window and process default events. Should be called after drawing each and every frame
	void update();
	/// Close the window and terminate application.
	int exit();
	/// Enter an infinite loop while processing default events and optionally executing the provided callback
	int halt(callback fn = nullptr);
	/// Pause for the specified number of frames while processing default events and optionally executing the provided callback
	void pause(int frames, callback fn = nullptr);
	/// Show a standard error message box with the specified message, then continue execution normally
	void error(string msg);
	/// Show a standard error message box with the specified message, then terminate application
	void abort(string msg);
	/// Return the system date in MM/DD/YYYY format
	string date();
	/// Return the system time in HH:MM:SS format
	string time();
	/// Return the system date and time in a single string
	string datetime();

	//=========================================================================
	//		GRAPHICS > WINDOW
	//=========================================================================

	/// Create application window with custom resolution and background color
	void window(int img_width, int img_height, rgb back_color, int size_factor);
	/// Create application window with standard resolution of 160x144 and specified background color
	void window_160x144(rgb back_color, int size_factor);
	/// Create application window with standard resolution of 256x192 and specified background color
	void window_256x192(rgb back_color, int size_factor);
	/// Create application window with standard resolution of 360x200 and specified background color
	void window_360x200(rgb back_color, int size_factor);
	/// Return whether the application window is open
	bool window();
	/// Set the window title
	void title(string str);
	/// Set the window background color
	void backcolor(rgb back_color);
	/// Clear the window background
	void clear();
	/// Switch to fullscreen mode or windowed mode
	void fullscreen(bool full);
	/// Return whether the window is in fullscreen mode
	bool fullscreen();
	/// Save a screenshot of the window contents to a bitmap image file
	void screenshot(string path);
	/// Return the horizontal resolution
	int width();
	/// Return the vertical resolution
	int height();
	/// Return the horizontal resolution divided by the tile size
	int cols();
	/// Return the vertical resolution divided by the tile size
	int rows();

	//=========================================================================
	//		GRAPHICS > VIEWS
	//=========================================================================

	/// Subsequent drawing operations will occur inside the selected view
	void view_in(TGL_VIEW& vw);
	/// Subsequent drawing operations will occur outside any views, i.e. directly on the window
	void view_out();

	//=========================================================================
	//		GRAPHICS > TILES
	//=========================================================================

	/// Load RGB tile from an 8x8 24-bit bitmap file
	TGL_TILE_RGB tile_load_rgb(string path);
	/// Load RGB tile from an 8x8 24-bit bitmap file. When drawn, transparency key color will be invisible
	TGL_TILE_RGB tile_load_rgb(string path, rgb transparency_key);
	/// Draw RGB tile at absolute position
	void draw_free(TGL_TILE_RGB& tile, int x, int y);
	/// Draw RGB tile aligned with virtual grid
	void draw_tiled(TGL_TILE_RGB& tile, int x, int y);
	/// Draw binary tile at absolute position, with specified foreground color and invisible background color
	void draw_free(TGL_TILE_BIN& tile, int x, int y, rgb fore_color);
	/// Draw binary tile at absolute position, with specified foreground and background colors
	void draw_free(TGL_TILE_BIN& tile, int x, int y, rgb fore_color, rgb back_color);
	/// Draw binary tile at absolute position, with specified foreground color and invisible background color
	void draw_free(string binary, int x, int y, rgb fore_color);
	/// Draw binary tile at absolute position, with specified foreground and background colors
	void draw_free(string binary, int x, int y, rgb fore_color, rgb back_color);
	/// Draw binary tile aligned with virtual grid, with specified foreground color and invisible background color
	void draw_tiled(TGL_TILE_BIN& tile, int x, int y, rgb fore_color);
	/// Draw binary tile aligned with virtual grid, with specified foreground and background colors
	void draw_tiled(TGL_TILE_BIN& tile, int x, int y, rgb fore_color, rgb back_color);
	/// Draw binary tile aligned with virtual grid, with specified foreground color and invisible background color
	void draw_tiled(string binary, int x, int y, rgb fore_color);
	/// Draw binary tile aligned with virtual grid, with specified foreground and background colors
	void draw_tiled(string binary, int x, int y, rgb fore_color, rgb back_color);

	//=========================================================================
	//		GRAPHICS > TEXT
	//=========================================================================

	/// Set binary tile to be used for the specified character in the text font
	void font(char ch, string binary);
	/// Clear all characters in the text font
	void font_new();
	/// Reset all characters in the text font to their default tiles
	void font_reset();
	/// Set text color without changing background color
	void text_color(rgb color);
	/// Set text and background colors
	void text_color(rgb fore_color, rgb back_color);
	/// Enable or disable text shadow, optionally set color of shadow
	void text_shadow(bool shadow, rgb shadow_color = 0x000000);
	/// Enable or disable text background
	void text_transparent(bool state);
	/// Print text at absolute position
	void print_free(string str, int x, int y);
	/// Print text aligned with virtual grid
	void print_tiled(string str, int x, int y);

	//=========================================================================
	//		AUDIO
	//=========================================================================
	void play_volume(int vol);
	void play_notes(string notes);
	void play_notes_loop(string notes);
	void play_notes_stop();
	void beep(float freq, int len);
	TGL_SOUND sound_load(string file);
	void sound_play(TGL_SOUND& snd);
	void sound_await(TGL_SOUND& snd);
	void sound_stop();

	//=========================================================================
	//		STRING MANIPULATION
	//=========================================================================
	string fmt(const char* str, ...);
	string ucase(string str);
	string lcase(string str);
	string trim(string str);
	vector<string> split(string str, char delim);
	string join(vector<string>& str, string separator);
	int to_int(string str);
	string to_string(int value);
	string substr(string str, int first, int last);
	string replace(string str, string original, string replacement);
	bool starts_with(string str, string prefix);
	bool ends_with(string str, string suffix);
	bool contains(string str, string other);
	int indexof(string str, char ch);

	//=========================================================================
	//		MATH
	//=========================================================================
	int rnd(int min, int max);
	bool rnd_chance(int percent);

	//=========================================================================
	//		COLLISION DETECTION
	//=========================================================================
	bool collision(int tile1_x, int tile1_y, int tile2_x, int tile2_y);

	//=========================================================================
	//		FILESYSTEM
	//=========================================================================
	bool file_exists(string path);
	bool folder_exists(string folder_path);
	string file_cload(string path);
	vector<string> file_lines(string path);
	void file_appendln(string path, string text);
	vector<byte> file_bload(string path);
	void file_csave(string path, string text);
	void file_bsave(string path, vector<byte>& bytes);
	vector<string> file_list(string folder_path);
	vector<string> folder_list(string folder_path);
	void file_copy(string src_path, string dest_path);
	void file_delete(string path);

	//=========================================================================
	//		INPUT > TEXT
	//=========================================================================
	void input_color(rgb foreground, rgb background);
	void input_cursor(char ch);
	string input_free(int length, int x, int y, callback fn = nullptr);
	string input_tiled(int length, int col, int row, callback fn = nullptr);
	bool input_ok();

	//=========================================================================
	//		INPUT > MOUSE
	//=========================================================================
	void mouse(bool enabled);
	int mouse_x();
	int mouse_y();
	bool mouse_right();
	bool mouse_left();
	bool mouse_middle();

	//=========================================================================
	//		INPUT > KEYBOARD
	//=========================================================================
	int kb_inkey();
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
	//		INPUT > GAMEPAD
	//=========================================================================
	void gpad_redetect();
	int gpad_count();
	bool gpad_connected(int number);
	bool gpad(int number);
	bool gpad_right();
	bool gpad_left();
	bool gpad_down();
	bool gpad_up();
	bool gpad_a();
	bool gpad_b();
	bool gpad_x();
	bool gpad_y();
	bool gpad_l();
	bool gpad_r();
	bool gpad_start();
	bool gpad_select();

	//=========================================================================
	//		DEBUGGING
	//=========================================================================
	void print_debug(string str, int x, int y, rgb color);
	void show_fps(bool show);
};
