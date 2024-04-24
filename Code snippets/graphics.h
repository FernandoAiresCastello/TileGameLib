#pragma once
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
#include <time.h>
#include <SDL.h>

typedef int rgb;

void open_window(const char* title);
void close_window();
bool has_window();
void toggle_fullscreen();
void clear_window(rgb color);
void update_window();
void set_pixel(int x, int y, rgb color);
int get_random_int(int min, int max);
rgb pack_rgb(int r, int g, int b);
rgb get_random_color();
void draw_tile(const char* bits, int x, int y, rgb color1, rgb color0, bool grid);
void draw_text(const char* text, int x, int y, rgb color1, rgb color0, bool grid);
void draw_test_frame_colors();
void draw_test_frame_pixels();
void draw_test_frame_tiles();
