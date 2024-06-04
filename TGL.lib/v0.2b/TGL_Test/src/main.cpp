#include <TGL.h>
using namespace tgl;

t_window wnd;
t_tileout out(&wnd);

int main(int argc, char* argv[])
{
	wnd.open("TGL Test", 360, 200, 3, 3, 0xffffff);

	SDL_Event e = { 0 };

	while (wnd.is_open()) {
		wnd.clear(t_color::get_random());
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
			else if (key == SDLK_RETURN && (e.key.keysym.mod & KMOD_ALT)) {
				wnd.toggle_full();
			}
		}
	}

	return 0;
}
