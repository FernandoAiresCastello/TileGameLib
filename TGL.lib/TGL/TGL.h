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
	void clear();
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
	/// Return the frame count
	int framecount();
	/// Return how many frames are drawn per second
	int fps();

	//=========================================================================
	//		GRAPHICS > VIEWS
	//=========================================================================

	/// Subsequent drawing operations will occur inside the specified view
	void view(TGL_VIEW& vw);
	/// Subsequent drawing operations will occur outside any views, i.e. directly on the window
	void exit_view();

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
	/// Get binary tile from font character
	string font_getbits(int ch);
	/// Get number of characters in font
	int font_getsize();
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

	/// Set volume for playing MML (Music Macro Language)
	void play_volume(int vol);
	/// Play MML string once
	void play_notes(string notes);
	/// Play MML string, repeatedly
	void play_notes_loop(string notes);
	/// Stop playing MML
	void play_notes_stop();
	/// Generate a beeping sound with the specified frequency and duration
	void beep(float freq, int len);
	/// Load a WAV sound resource from a file
	TGL_SOUND sound_load(string file);
	/// Play a WAV sound resource asynchronously
	void sound_play(TGL_SOUND& snd);
	/// Play a WAV sound resource and pause program execution until the sound has finished
	void sound_await(TGL_SOUND& snd);
	/// Stop playing WAV sounds
	void sound_stop();

	//=========================================================================
	//		STRING MANIPULATION
	//=========================================================================

	/// Format a string (works like sprintf in standard C)
	string fmt(const char* str, ...);
	/// Return specified string in uppercase
	string ucase(string str);
	/// Return specified string in lowercase
	string lcase(string str);
	/// Remove leading and trailing spaces from string
	string trim(string str);
	/// Split string into a list
	vector<string> split(string str, char delim);
	/// Join all strings from a list into a single string
	string join(vector<string>& str, string separator);
	/// Convert string to integer
	int to_int(string str);
	/// Convert integer to string
	string to_string(int value);
	/// Return a slice of the specified string
	string substr(string str, int first, int last);
	/// Replace occurrences of a substring
	string replace(string str, string original, string replacement);
	/// Return whether the string starts with a prefix
	bool starts_with(string str, string prefix);
	/// Return whether the string ends with a suffix
	bool ends_with(string str, string suffix);
	/// Return whether the string contains a substring
	bool contains(string str, string other);
	/// Return index of first occurrence of character in string
	int indexof(string str, char ch);

	//=========================================================================
	//		MATH
	//=========================================================================

	/// Return pseudo-random number within a range
	int rnd(int min, int max);
	/// Return true with the specified probability (0% to 100%)
	bool rnd_chance(int percent);

	//=========================================================================
	//		COLLISION DETECTION
	//=========================================================================

	/// Return whether two tiles overlap based on their coordinates
	bool collision(int tile1_x, int tile1_y, int tile2_x, int tile2_y);

	//=========================================================================
	//		FILESYSTEM
	//=========================================================================

	/// Return whether a file exists
	bool file_exists(string path);
	/// Return whether a folder exists
	bool folder_exists(string folder_path);
	/// Read text file contents into string
	string file_cload(string path);
	/// Read lines of text file into list of strings
	vector<string> file_lines(string path);
	/// Append line to the end of a text file then save it
	void file_line_add(string path, string text);
	/// Read binary file into list of bytes
	vector<byte> file_bload(string path);
	/// Create or replace contents of text file with specified string then save it
	void file_csave(string path, string text);
	/// Create or replace contents of binary file with specified bytes then save it
	void file_bsave(string path, vector<byte>& bytes);
	/// Return list of files in a folder
	vector<string> file_list(string folder_path);
	/// Return list of subfolders in a folder
	vector<string> folder_list(string folder_path);
	/// Create a new file with same contents as the source file, i.e. duplicate it
	void file_copy(string src_path, string dest_path);
	/// Permanently delete file
	void file_delete(string path);

	//=========================================================================
	//		INPUT > TEXT
	//=========================================================================

	/// Set color of text input field
	void input_color(rgb foreground, rgb background);
	/// Set character used as cursor in text input field
	void input_cursor(char ch);
	/// Show text input field with the maximum specified length, at absolute position, optionally executing the provided callback
	string input_free(int length, int x, int y, callback fn = nullptr);
	/// Show text input field with the maximum specified length, aligned with virtual grid, optionally executing the provided callback
	string input_tiled(int length, int col, int row, callback fn = nullptr);
	/// Return whether the last text input field shown was confirmed
	bool input_ok();

	//=========================================================================
	//		INPUT > MOUSE
	//=========================================================================

	/// Show or hide the mouse pointer
	void mouse(bool show);
	/// Get the absolute X coordinate of mouse pointer
	int mouse_x();
	/// Get the absolute Y coordinate of mouse pointer
	int mouse_y();
	/// Return whether the right mouse button is pressed
	bool mouse_right();
	/// Return whether the left mouse button is pressed
	bool mouse_left();
	/// Return whether the middle mouse button is pressed
	bool mouse_middle();

	//=========================================================================
	//		INPUT > KEYBOARD
	//=========================================================================

	/// Return code of last key pressed, subject to keyboard repeat delay and rate
	int kb_inkey();
	/// Return whether the key that would produce the specified character is pressed
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

	/// Redetect connected controllers
	void gpad_redetect();
	/// Return number of controllers connected
	int gpad_count();
	/// Return whether controller is connected
	bool gpad_connected(int number);
	/// Set the current controller, return whether it is actually connected
	bool gpad(int number);
	/// Return whether d-pad right button is pressed, or if left stick is held to the right
	bool gpad_right();
	/// Return whether d-pad left button is pressed, or if left stick is held to the left
	bool gpad_left();
	/// Return whether d-pad down button is pressed, or if left stick is held down
	bool gpad_down();
	/// Return whether d-pad up button is pressed, or if left stick is held up
	bool gpad_up();
	/// Return whether A button is pressed
	bool gpad_a();
	/// Return whether B button is pressed
	bool gpad_b();
	/// Return whether X button is pressed
	bool gpad_x();
	/// Return whether Y button is pressed
	bool gpad_y();
	/// Return whether left shoulder button or left trigger is pressed
	bool gpad_l();
	/// Return whether right shoulder button or right trigger is pressed
	bool gpad_r();
	/// Return whether the start button is pressed
	bool gpad_start();
	/// Return whether the select (or back) button is pressed
	bool gpad_select();
};
