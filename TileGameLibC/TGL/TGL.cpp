#include "TGL.h"
using namespace TGL_Internal;

struct TGL tgl;

void TGL::init()
{
	SDL_Init(SDL_INIT_EVERYTHING);
	
	Util::Randomize();

	has_gpad = false;
	if (gpad.CountAvailable()) {
		gpad.Open();
		has_gpad = true;
	}

	wnd = nullptr;
	default_font = new font();
	kb_last = 0;
}
int TGL::exit()
{
	delete wnd;
	delete default_font;

	SDL_Quit();
	::exit(0);
	return 0;
}
int TGL::halt()
{
	while (sysproc());

	return exit();
}
bool TGL::sysproc()
{
	wnd->Update();
	SDL_Event e;
	return process_default_events(&e);
}
bool TGL::process_default_events(SDL_Event* e)
{
	SDL_PollEvent(e);

	if (e->type == SDL_QUIT) {
		exit();
		return false;
	}
	else if (e->type == SDL_KEYDOWN) {
		auto key = e->key.keysym.sym;
		kb_last = key;

		if (TKey::Alt() && key == SDLK_RETURN && wnd) {
			wnd->ToggleFullscreen();
		}
	}
	return true;
}
void TGL::title(string title)
{
	wnd_title = title;
	if (wnd) {
		wnd->SetTitle(title);
	}
}
void TGL::screen(int width, int height, int hstr, int vstr, rgb back_color)
{
	wnd = new TRGBWindow(width / tile::width, height / tile::height, hstr, vstr, back_color);
	wnd->SetTitle(wnd_title);
	wnd->Show();
}
void TGL::bgcolor(rgb color)
{
	wnd->SetBackColor(color);
}
void TGL::clip(int x1, int y1, int x2, int y2)
{
	wnd->SetClip(x1, y1, x2, y2);
}
void TGL::unclip()
{
	wnd->RemoveClip();
}
void TGL::cls()
{
	wnd->ClearBackground();
}
void TGL::draw_tile(tile* tile, int x, int y)
{
	drawtile_internal(tile, x, y, false);
}
void TGL::drawtile_internal(tile* tile, int x, int y, bool ignore_c0)
{
	if (wnd->HasClip()) {
		x += wnd->GetClip().X1;
		y += wnd->GetClip().Y1;
	}
	tile_f& frame = tile->frames[wnd->GetFrame() % tile->frames.size()];
	wnd->DrawPixelBlock8x8(frame.pixels, frame.c0, frame.c1, frame.c2, frame.c3, ignore_c0, x, y);
}
void TGL::draw_tilemap(tilemap* tilemap)
{
	drawtilemap_internal(tilemap, false);
}
void TGL::drawtilemap_internal(tilemap* tilemap, bool ignore_c0)
{
	const int initial_x = tilemap->x;
	const int initial_y = tilemap->y;
	int current_x = tilemap->x;
	int current_y = tilemap->y;

	for (int y = 0; y < tilemap->rows; y++) {
		for (int x = 0; x < tilemap->cols; x++) {
			tile* tile = tilemap->get(x, y);
			if (tile) {
				drawtile_internal(tile, current_x, current_y, ignore_c0);
			}
			current_x += tile::width;
		}
		current_x = initial_x;
		current_y += tile::height;
	}
}
void TGL::draw_sprite(sprite* sprite)
{
	if (!sprite->is_visible) return;

	drawtilemap_internal(&sprite->tiles, true);
}
void TGL::draw_spritelist(spritelist* sprlist)
{
	for (auto* sprite : sprlist->sprites) {
		if (!sprite->is_visible) continue;
		drawtilemap_internal(&sprite->tiles, true);
	}
}
void TGL::print(string str, int x, int y)
{
	for (int i = 0; i < str.length(); i++) {
		const char& ch = str[i];
		tile* char_tile = default_font->chars[ch];
		drawtile_internal(char_tile, x, y, true);
		x += tile::width;
	}
}
bool TGL::kb_right()
{
	return TKey::IsPressed(SDL_SCANCODE_RIGHT);
}
bool TGL::kb_left()
{
	return TKey::IsPressed(SDL_SCANCODE_LEFT);
}
bool TGL::kb_down()
{
	return TKey::IsPressed(SDL_SCANCODE_DOWN);
}
bool TGL::kb_up()
{
	return TKey::IsPressed(SDL_SCANCODE_UP);
}
bool TGL::kb_space()
{
	return TKey::IsPressed(SDL_SCANCODE_SPACE);
}
bool TGL::kb_enter()
{
	return TKey::IsPressed(SDL_SCANCODE_RETURN);
}
bool TGL::kb_bs()
{
	return TKey::IsPressed(SDL_SCANCODE_BACKSPACE);
}
bool TGL::kb_tab()
{
	return TKey::IsPressed(SDL_SCANCODE_TAB);
}
bool TGL::kb_shift()
{
	return TKey::Shift();
}
bool TGL::kb_ctrl()
{
	return TKey::Ctrl();
}
bool TGL::kb_alt()
{
	return TKey::Alt();
}
bool TGL::kb_caps()
{
	return TKey::CapsLock();
}
bool TGL::kb_ins()
{
	return TKey::IsPressed(SDL_SCANCODE_INSERT);
}
bool TGL::kb_del()
{
	return TKey::IsPressed(SDL_SCANCODE_DELETE);
}
bool TGL::kb_home()
{
	return TKey::IsPressed(SDL_SCANCODE_HOME);
}
bool TGL::kb_end()
{
	return TKey::IsPressed(SDL_SCANCODE_END);
}
bool TGL::kb_pgup()
{
	return TKey::IsPressed(SDL_SCANCODE_PAGEUP);
}
bool TGL::kb_pgdn()
{
	return TKey::IsPressed(SDL_SCANCODE_PAGEDOWN);
}
bool TGL::kb_esc()
{
	return TKey::IsPressed(SDL_SCANCODE_ESCAPE);
}
bool TGL::kb_char(char ch)
{
	ch = String::ToUpper(ch);
	
	switch (ch) {

		case 'A': return TKey::IsPressed(SDL_SCANCODE_A);
		case 'B': return TKey::IsPressed(SDL_SCANCODE_B);
		case 'C': return TKey::IsPressed(SDL_SCANCODE_C);
		case 'D': return TKey::IsPressed(SDL_SCANCODE_D);
		case 'E': return TKey::IsPressed(SDL_SCANCODE_E);
		case 'F': return TKey::IsPressed(SDL_SCANCODE_F);
		case 'G': return TKey::IsPressed(SDL_SCANCODE_G);
		case 'H': return TKey::IsPressed(SDL_SCANCODE_H);
		case 'I': return TKey::IsPressed(SDL_SCANCODE_I);
		case 'J': return TKey::IsPressed(SDL_SCANCODE_J);
		case 'K': return TKey::IsPressed(SDL_SCANCODE_K);
		case 'L': return TKey::IsPressed(SDL_SCANCODE_L);
		case 'M': return TKey::IsPressed(SDL_SCANCODE_M);
		case 'N': return TKey::IsPressed(SDL_SCANCODE_N);
		case 'O': return TKey::IsPressed(SDL_SCANCODE_O);
		case 'P': return TKey::IsPressed(SDL_SCANCODE_P);
		case 'Q': return TKey::IsPressed(SDL_SCANCODE_Q);
		case 'R': return TKey::IsPressed(SDL_SCANCODE_R);
		case 'S': return TKey::IsPressed(SDL_SCANCODE_S);
		case 'T': return TKey::IsPressed(SDL_SCANCODE_T);
		case 'U': return TKey::IsPressed(SDL_SCANCODE_U);
		case 'V': return TKey::IsPressed(SDL_SCANCODE_V);
		case 'W': return TKey::IsPressed(SDL_SCANCODE_W);
		case 'X': return TKey::IsPressed(SDL_SCANCODE_X);
		case 'Y': return TKey::IsPressed(SDL_SCANCODE_Y);
		case 'Z': return TKey::IsPressed(SDL_SCANCODE_Z);

		case '0': return TKey::IsPressed(SDL_SCANCODE_0);
		case '1': return TKey::IsPressed(SDL_SCANCODE_1);
		case '2': return TKey::IsPressed(SDL_SCANCODE_2);
		case '3': return TKey::IsPressed(SDL_SCANCODE_3);
		case '4': return TKey::IsPressed(SDL_SCANCODE_4);
		case '5': return TKey::IsPressed(SDL_SCANCODE_5);
		case '6': return TKey::IsPressed(SDL_SCANCODE_6);
		case '7': return TKey::IsPressed(SDL_SCANCODE_7);
		case '8': return TKey::IsPressed(SDL_SCANCODE_8);
		case '9': return TKey::IsPressed(SDL_SCANCODE_9);
	}
	
	return false;
}
bool TGL::kb_code(int code)
{
	return TKey::IsPressed((SDL_Scancode)code);
}
void TGL::mouse_hide()
{
	SDL_ShowCursor(false);
}
void TGL::mouse_show()
{
	SDL_ShowCursor(true);
}
int TGL::mouse_x()
{
	int x = 0;
	SDL_GetMouseState(&x, nullptr);
	return x / wnd->PixelWidth;
}
int TGL::mouse_y()
{
	int y = 0;
	SDL_GetMouseState(nullptr, &y);
	return y / wnd->PixelHeight;
}
int TGL::mouse_x_clip()
{
	if (wnd->HasClip()) {
		return mouse_x() - wnd->GetClip().X1;
	} else {
		return mouse_x();
	}
}
int TGL::mouse_y_clip()
{
	if (wnd->HasClip()) {
		return mouse_y() - wnd->GetClip().Y1;
	} else {
		return mouse_y();
	}
}
bool TGL::mouse_left()
{
	return SDL_GetMouseState(nullptr, nullptr) & SDL_BUTTON_LMASK;
}
bool TGL::mouse_right()
{
	return SDL_GetMouseState(nullptr, nullptr) & SDL_BUTTON_RMASK;
}
void TGL::play(string notes)
{
	snd.PlaySubSound(notes);
}
void TGL::play_loop(string notes)
{
	snd.PlayMainSound(notes);
}
void TGL::sound(float freq, int length)
{
	snd.Beep(freq, length);
}
void TGL::vol(int vol)
{
	snd.SetVolume(vol * 100);
}
void TGL::quiet()
{
	snd.StopMainSound();
	snd.StopSubSound();
}
int TGL::rnd(int min, int max)
{
	return Util::Random(min, max);
}
string TGL::cload(string path)
{
	return File::ReadText(path);
}
void TGL::csave(string path, string text)
{
	File::WriteText(path, text);
}
vector<string> TGL::cload_ls(string path)
{
	return File::ReadLines(path, "\r\n");
}
void TGL::csave_ls(string path, vector<string>& lines)
{
	File::WriteLines(path, lines);
}
vector<byte> TGL::bload(string path)
{
	return File::ReadBytes(path);
}
void TGL::bsave(string path, vector<byte>& bytes)
{
	File::WriteBytes(path, bytes);
}