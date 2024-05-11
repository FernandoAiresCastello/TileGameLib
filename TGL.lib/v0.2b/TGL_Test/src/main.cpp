#include <TGL.h>

tgl::t_window wnd;
tgl::t_tileout out(&wnd);

int main(int argc, char* argv[])
{
	wnd.open("TGL Test", 256, 192, 3, 3, 0xffffff);

	SDL_Event e = { 0 };

	while (wnd.is_open()) {
		wnd.clear(tgl::t_color::get_random());
		out.draw_text("Hello World!", 1, 1, 0xff0000, 0xffff00, true);
		wnd.update();

		SDL_PollEvent(&e);

		if (e.type == SDL_QUIT) {
			wnd.close();
		}
		else if (e.type == SDL_KEYDOWN) {
			const auto key = e.key.keysym.sym;
			if (key == SDLK_ESCAPE) {
				wnd.close();
			}
		}
	}

	return 0;
}
