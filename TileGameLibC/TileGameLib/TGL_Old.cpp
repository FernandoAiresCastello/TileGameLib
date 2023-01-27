/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#include <cstdarg>
#include "TGL_Old.h"

TGL_Old tgl;

struct {
	int x = 0;
	int y = 0;
} csr;

void TGL_Old::init()
{
	SDL_Init(SDL_INIT_EVERYTHING);
}
int TGL_Old::exit()
{
	delete wnd;
	SDL_Quit();
	::exit(0);
	return 0;
}
int TGL_Old::halt()
{
	while (true) {
		sysproc();
	}
	return 0;
}
bool TGL_Old::sysproc()
{
	if (wnd) {
		wnd->Update();
	}
	SDL_Event e;
	return process_default_events(&e);
}
void TGL_Old::screen(int cols, int rows, int hstr, int vstr)
{
	wnd = new TRGBWindow(cols, rows, hstr, vstr);
	wnd->Show();
}
void TGL_Old::title(string title)
{
	wnd->SetTitle(title);
}
void TGL_Old::bgcol(rgb color)
{
	wnd->SetBackColor(color);
}
void TGL_Old::cls()
{
	wnd->ClearBackground();
	wnd->ClearBackgroundInsideClip();
	
	csr.x = 0;
	csr.y = 0;
}
void TGL_Old::vsync()
{
	wnd->Update();
}
void TGL_Old::view(struct view& view)
{
	wnd->SetClip(view.x1, view.y1, view.x2, view.y2, view.back_color);
	wnd->ClearBackgroundInsideClip();
}
void TGL_Old::rview()
{
	wnd->RemoveClip();
	wnd->ClearBackground();
}
void TGL_Old::coord(int x, int y)
{
	csr.x = x;
	csr.y = y;
}
void TGL_Old::cell(int col, int row)
{
	csr.x = col * tile::width;
	csr.y = row * tile::height;
}
void TGL_Old::draw(tile& tile)
{
	if (!tile.visible) return;

	tile_f& frame = tile.frames[wnd->GetFrame() % tile.frames.size()];

	int x = wnd->HasClip() ? csr.x + wnd->GetClip().X1 : csr.x;
	int y = wnd->HasClip() ? csr.y + wnd->GetClip().Y1 : csr.y;

	wnd->DrawPixels(frame.pixels, frame.c0, frame.c1, frame.c2, frame.c3, tile.ignore_c0, x, y);
}
void TGL_Old::pause(int ms)
{
	for (int i = 0; i < ms; i++) {
		sysproc();
	}
}
int TGL_Old::rnd(int min, int max)
{
	return Util::Random(min, max);
}
void TGL_Old::sfx(string notes)
{
	snd.PlaySubSound(notes);
}
void TGL_Old::music(string notes)
{
	snd.PlayMainSound(notes);
}
void TGL_Old::sound(float freq, int len)
{
	snd.Beep(freq, len);
}
void TGL_Old::quiet()
{
	snd.StopMainSound();
	snd.StopSubSound();
}
void TGL_Old::vol(int value)
{
	snd.SetVolume(value * 100);
}
void TGL_Old::error(string msg)
{
	MsgBox::Error(msg);
}
void TGL_Old::abort(string msg)
{
	MsgBox::Error(msg);
	exit();
}

//=============================================================================
//								PRIVATE
//=============================================================================

bool TGL_Old::process_default_events(SDL_Event* e)
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
