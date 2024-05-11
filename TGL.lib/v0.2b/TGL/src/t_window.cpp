#include "t_window.h"

namespace tgl
{
	void t_window::open()
	{
		open("", 360, 200, 3, 3, 0x000000);
	}

	void t_window::open(t_string title, int width, int height, int width_s, int height_s, t_color back_color)
	{
		SDL_SetHint(SDL_HINT_RENDER_DRIVER, "direct3d");
		SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "nearest");

		fullscreen = false;
		scr_w = width;
		scr_h = height;
		scr_ws = width_s;
		scr_hs = height_s;
		wnd_w = width_s * width;
		wnd_h = height_s * height;

		buflen = scr_w * scr_h * sizeof(rgb);
		scrbuf = new rgb[buflen];

		auto wnd_flags = (fullscreen ? SDL_WINDOW_FULLSCREEN_DESKTOP : 0) | SDL_WINDOW_HIDDEN;

		wnd = SDL_CreateWindow(title.c_str(), SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, wnd_w, wnd_h, wnd_flags);
		rend = SDL_CreateRenderer(wnd, -1, SDL_RENDERER_PRESENTVSYNC | SDL_RENDERER_ACCELERATED | SDL_RENDERER_TARGETTEXTURE);
		tex = SDL_CreateTexture(rend, SDL_PIXELFORMAT_ARGB8888, SDL_TEXTUREACCESS_STREAMING, scr_w, scr_h);

		SDL_SetRenderDrawBlendMode(rend, SDL_BLENDMODE_NONE);
		SDL_SetTextureBlendMode(tex, SDL_BLENDMODE_NONE);
		SDL_RenderSetLogicalSize(rend, scr_w, scr_h);
		SDL_SetWindowPosition(wnd, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED);

		clear(back_color);
		update();

		SDL_ShowWindow(wnd);
		SDL_RaiseWindow(wnd);
	}

	void t_window::close()
	{
		if (!is_open())
			return;

		SDL_DestroyTexture(tex);
		SDL_DestroyRenderer(rend);
		SDL_DestroyWindow(wnd);

		tex = nullptr;
		rend = nullptr;
		wnd = nullptr;

		delete scrbuf;
		scrbuf = nullptr;
	}

	bool t_window::is_open()
	{
		return wnd != nullptr;
	}

	void t_window::toggle_full()
	{
		Uint32 flag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 is_full = SDL_GetWindowFlags(wnd) & flag;
		SDL_SetWindowFullscreen(wnd, is_full ? 0 : flag);
		update();
	}

	void t_window::clear(t_color color)
	{
		for (int i = 0; i < buflen; i++)
			scrbuf[i] = color.to_rgb();
	}

	void t_window::update()
	{
		static int pitch;
		static void* pixels;

		SDL_LockTexture(tex, nullptr, &pixels, &pitch);
		SDL_memcpy(pixels, scrbuf, buflen);
		SDL_UnlockTexture(tex);
		SDL_RenderCopy(rend, tex, nullptr, nullptr);
		SDL_RenderPresent(rend);
	}
}
