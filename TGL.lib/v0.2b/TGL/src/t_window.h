#pragma once
#include "t_string.h"
#include "t_color.h"

namespace tgl
{
	class t_window
	{
	public:
		void open();
		void open(t_string title, int width, int height, int width_s, int height_s, t_color back_color);
		void close();
		bool is_open();
		void toggle_full();
		void clear(t_color color);
		void update();

	private:
		friend class t_tileout;

		int scr_w = 0;
		int scr_h = 0;
		int buflen = 0;
		int scr_ws = 0;
		int scr_hs = 0;
		int wnd_w = 0;
		int wnd_h = 0;

		void* wnd = nullptr;
		void* rend = nullptr;
		void* tex = nullptr;
		rgb* scrbuf = nullptr;
		bool fullscreen = false;

		void process_events();
	};
}
