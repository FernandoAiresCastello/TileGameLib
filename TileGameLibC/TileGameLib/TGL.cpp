/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#include <cstdarg>
#include "TGL.h"

TGL tgl;

void TGL::init()
{
	SDL_Init(SDL_INIT_EVERYTHING);
}
int TGL::exit()
{
	delete wnd;
	SDL_Quit();
	::exit(0);
	return 0;
}
int TGL::halt()
{
	while (true) {
		sysproc();
	}
	return 0;
}
bool TGL::sysproc()
{
	if (wnd) {
		wnd->Update();
	}
	SDL_Event e;
	return process_default_events(&e);
}
void TGL::screen(int cols, int rows, int layers, int hstr, int vstr)
{
	wnd = new TRGBWindow(cols, rows, layers, hstr, vstr);
	wnd->Show();
}
void TGL::title(string title)
{
	wnd->SetTitle(title);
}
void TGL::bgcol(rgb color)
{
	wnd->SetBackColor(color);
}
void TGL::cls()
{
	wnd->ClearBackground();
}
void TGL::vsync()
{
	wnd->Update();
}
void TGL::locate(int x, int y)
{
	csr.px = x;
	csr.py = y;
}
void TGL::tron()
{
	ignore_pixel_c0 = true;
}
void TGL::troff()
{
	ignore_pixel_c0 = false;
}
void TGL::grid()
{
	align_to_grid = true;
}
void TGL::ungrid()
{
	align_to_grid = false;
}
void TGL::draw(tile& tile)
{
	if (!tile.visible) return;

	tile_f frame = tile.frames[wnd->GetAnimationFrameIndex() % tile.frames.size()];
	wnd->DrawPixels(frame.pixels, frame.c0, frame.c1, frame.c2, frame.c3, ignore_pixel_c0, align_to_grid, csr.px, csr.py);
}
void TGL::pause(int ms)
{
	for (int i = 0; i < ms; i++) {
		sysproc();
	}
}
int TGL::rnd(int min, int max)
{
	return Util::Random(min, max);
}
void TGL::play(string notes)
{
	snd.PlaySubSound(notes);
}
void TGL::play_loop(string notes)
{
	snd.PlayMainSound(notes);
}
void TGL::sound(float freq, int len)
{
	snd.Beep(freq, len);
}
void TGL::quiet()
{
	snd.StopMainSound();
	snd.StopSubSound();
}
void TGL::vol(int value)
{
	snd.SetVolume(value);
}
string TGL::input(int maxlen)
{
	return "";
}
void TGL::error(string msg)
{
	MsgBox::Error(msg);
}
void TGL::abort(string msg)
{
	MsgBox::Error(msg);
	exit();
}

//=============================================================================
//								PRIVATE
//=============================================================================

bool TGL::process_default_events(SDL_Event* e)
{
	SDL_PollEvent(e);

	if (e->type == SDL_QUIT) {
		exit();
		return true;
	}
	else if (e->type == SDL_KEYDOWN) {
		auto key = e->key.keysym.sym;
		kb.last_key_pressed = key;

		if (key == SDLK_PAUSE) {
			exit();
			return true;
		}
		else if (TKey::Alt() && key == SDLK_RETURN && wnd) {
			wnd->ToggleFullscreen();
			return true;
		}
		else {
			return false;
		}
	}
	return false;
}
