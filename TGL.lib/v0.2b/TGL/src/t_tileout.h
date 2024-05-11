#pragma once
#include "t_color.h"
#include "t_string.h"

namespace tgl
{
	class t_window;

	class t_tileout
	{
	public:
		static constexpr int tile_w = 8;
		static constexpr int tile_h = 8;
		static constexpr int tilesize = tile_w * tile_h;

		t_tileout(t_window* wnd);

		int cols() const;
		int rows() const;
		void draw_tile(t_string bits, int x, int y, t_color color1, t_color color0, bool grid);
		void draw_text(t_string text, int x, int y, t_color color1, t_color color0, bool grid);

	private:
		t_window* wnd = nullptr;
	};
}
