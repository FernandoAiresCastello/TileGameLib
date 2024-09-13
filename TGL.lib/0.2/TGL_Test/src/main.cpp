#include <TGL.h>

using namespace TGL;

int main(int argc, char* argv[])
{
	TGL_Window wnd;
	wnd.Open(256, 192, 4, 3, 0x101010, true);
	wnd.SetTitle("TGL Demo");

	TGL_Image img;
	img.Load("tileset.bmp");
	wnd.DrawImage(&img, 0, 0);
	wnd.Update();

	while (wnd.IsOpen()) {
		SDL_Event e;
		while (SDL_PollEvent(&e)) {
			if (e.type == SDL_QUIT) {
				wnd.Close();
			}
			else if (e.type == SDL_KEYDOWN) {
				if (e.key.keysym.sym == SDLK_RETURN && SDL_GetModState() & KMOD_ALT)
					wnd.ToggleFullscreen();
				else if (e.key.keysym.sym == SDLK_ESCAPE)
					wnd.Close();
			}
		}
	}

	return 0;
}
