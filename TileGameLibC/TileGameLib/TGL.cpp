/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#include <cstdarg>
#include "TGL.h"

TGL tgl;

struct {
	int x = 0;
	int y = 0;
} csr;

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
	wnd->ClearBackgroundInsideClip();
}
void TGL::vsync()
{
	wnd->Update();
}
void TGL::view(struct view& view)
{
	wnd->SetClip(view.x1, view.y1, view.x2, view.y2, view.back_color);
	wnd->ClearBackgroundInsideClip();
}
void TGL::rview()
{
	wnd->RemoveClip();
	wnd->ClearBackground();
}
void TGL::coord(int x, int y)
{
	csr.x = x;
	csr.y = y;
}
void TGL::cell(int col, int row)
{
	csr.x = col * tile::width;
	csr.y = row * tile::height;
}
void TGL::draw(tile& tile)
{
	if (!tile.visible) return;

	tile_f& frame = tile.frames[wnd->GetAnimationFrameIndex() % tile.frames.size()];

	int x = wnd->HasClip() ? csr.x + wnd->GetClip().X1 : csr.x;
	int y = wnd->HasClip() ? csr.y + wnd->GetClip().Y1 : csr.y;

	wnd->DrawPixels(frame.pixels, frame.c0, frame.c1, frame.c2, frame.c3, tile.ignore_c0, x, y);
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
void TGL::sfx(string notes)
{
	snd.PlaySubSound(notes);
}
void TGL::music(string notes)
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
	snd.SetVolume(value * 1000);
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
