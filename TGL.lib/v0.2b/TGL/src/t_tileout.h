#pragma once
#include "common.h"
#include "t_color.h"

class t_window;

class t_tileout
{
public:
	static constexpr int TILE_W = 8;
	static constexpr int TILE_H = 8;
	static constexpr int TILESIZE = TILE_W * TILE_H;

	t_tileout(t_window* wnd);

	void draw_tile(std::string bits, int x, int y, t_color color1, t_color color0, bool grid);
	void draw_text(std::string text, int x, int y, t_color color1, t_color color0, bool grid);

private:
	t_window* wnd = nullptr;
};
