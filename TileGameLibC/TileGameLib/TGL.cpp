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
void TGL::exit()
{
	delete wnd;
	SDL_Quit();
	::exit(0);
}
void TGL::halt()
{
	while (true) {
		if (wnd) wnd->Update();
		global_proc();
	}
}
bool TGL::global_proc()
{
	SDL_Event e;
	return global_proc(&e);
}
void TGL::screen(int cols, int rows, int layers, int hstr, int vstr)
{
	wnd = new TBufferedWindow(layers, cols, rows, hstr, vstr);

	pal.palette = wnd->GetPalette();
	pal.init_default();
	chr.charset = wnd->GetCharset();
	chr.init_default();

	buf.init(wnd);

	tile.palette = &pal;
	tile.tileset = &chr;

	wnd->Show();
}
void TGL::title(string title)
{
	wnd->SetTitle(title);
}
void TGL::wcol(colorid id)
{
	wnd->SetBackColor(pal.get_rgb(id));
}
void TGL::cls()
{
	for (auto buf : wnd->GetAllBuffers()) {
		buf->ClearAllLayers();
	}
}
void TGL::cll()
{
	buf.sel_buf->ClearLayer(csr.layer);
}
void TGL::clr(int x, int y, int w, int h)
{
	for (int py = 0; py < h; py++) {
		for (int px = 0; px < w; px++) {
			buf.sel_buf->EraseTile(csr.layer, x + px, y + py);
		}
	}
}
void TGL::vsync()
{
	wnd->Update();
}
void TGL::layer(int layer)
{
	csr.layer = layer;
}
void TGL::locate(int x, int y)
{
	csr.px = x;
	csr.py = y;
}
void TGL::tron()
{
	transparency = true;
}
void TGL::troff()
{
	transparency = false;
}
void TGL::color(colorid fgc, colorid bgc)
{
	fcolor(fgc);
	bcolor(bgc);
}
void TGL::fcolor(colorid id)
{
	text_color.fg = pal.get_index(id);
}
void TGL::bcolor(colorid id)
{
	text_color.bg = pal.get_index(id);
}
void TGL::print(const char* fmt, ...)
{
	char str[1000] = { 0 };
	va_list arg;
	va_start(arg, fmt);
	vsprintf(str, fmt, arg);
	va_end(arg);

	print_tile_string(str, false, false, text_color.fg, text_color.bg);
}
void TGL::println(const char* fmt, ...)
{
	char str[1000] = { 0 };
	va_list arg;
	va_start(arg, fmt);
	vsprintf(str, fmt, arg);
	va_end(arg);

	string text = str;
	text += "\n";
	print_tile_string(text, false, false, text_color.fg, text_color.bg);
}
void TGL::print_raw(string text)
{
	print_tile_string(text, true, false, text_color.fg, text_color.bg);
}
void TGL::print_add(string text)
{
	print_tile_string(text, false, true, text_color.fg, text_color.bg);
}
void TGL::putc(char ch)
{
	string text = "";
	text += ch;
	print_tile_string(text, true, false, text_color.fg, text_color.bg);
}
void TGL::pause(int ms)
{
	for (int i = 0; i < ms; i++) {
		if (wnd) wnd->Update();
		global_proc();
		SDL_Delay(1);
	}
}
void TGL::put()
{
	buf.sel_buf->SetTile(tile.cur_tile, csr.layer, csr.px, csr.py, transparency);
}
void TGL::put_r(int count)
{
	for (int i = 0; i < count; i++) {
		put(); csr.px++;
	}
}
void TGL::put_d(int count)
{
	for (int i = 0; i < count; i++) {
		put(); csr.py++;
	}
}
void TGL::put_l(int count)
{
	for (int i = 0; i < count; i++) {
		put(); csr.px--;
	}
}
void TGL::put_u(int count)
{
	for (int i = 0; i < count; i++) {
		put(); csr.py--;
	}
}
void TGL::get()
{
	tile.cur_tile = buf.sel_buf->GetTile(csr.layer, csr.px, csr.py);
}
void TGL::del()
{
	buf.sel_buf->EraseTile(csr.layer, csr.px, csr.py);
}
void TGL::rect(int x, int y, int w, int h)
{
	for (int py = 0; py < h; py++) {
		for (int px = 0; px < w; px++) {
			buf.sel_buf->SetTile(tile.cur_tile, csr.layer, x + px, y + py, transparency);
		}
	}
}
void TGL::fill()
{
	buf.sel_buf->FillLayer(csr.layer, tile.cur_tile, transparency);
}
void TGL::mov(int dx, int dy)
{
	TTileSeq tile = buf.sel_buf->GetTile(csr.layer, csr.px, csr.py);
	buf.sel_buf->EraseTile(csr.layer, csr.px, csr.py);
	buf.sel_buf->SetTile(tile, csr.layer, csr.px + dx, csr.py + dy, transparency);
}
void TGL::movb(int x, int y, int w, int h, int dx, int dy)
{
	vector<TTileSeq> tiles;
	for (int cy = y; cy < y + h; cy++) {
		for (int cx = x; cx < x + w; cx++) {
			if (cx >= 0 && cy >= 0 && cx < buf.sel_buf->Cols && cy < buf.sel_buf->Rows) {
				tiles.push_back(buf.sel_buf->GetTile(csr.layer, cx, cy));
				buf.sel_buf->EraseTile(csr.layer, cx, cy);
			}
			else {
				tiles.push_back(TTileSeq());
			}
		}
	}
	const int new_x = x + dx;
	const int new_y = y + dy;
	int i = 0;
	for (int cy = new_y; cy < new_y + h; cy++) {
		for (int cx = new_x; cx < new_x + w; cx++) {
			buf.sel_buf->SetTile(tiles[i++], csr.layer, cx, cy, transparency);
		}
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
void TGL::lplay(string notes)
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
	string str = "";
	string empty_str = string(maxlen + 1, ' ');
	const int initial_x = csr.px;
	const int y = 0;
	int ix = 0;
	bool running = true;

	TTileSeq input_csr;
	input_csr.Add(0x00, text_color.bg, text_color.fg);
	input_csr.Add(0x00, text_color.fg, text_color.bg);

	while (running) {
		buf.sel_buf->Print(empty_str, csr.layer, initial_x, csr.py, text_color.fg, text_color.bg, transparency);
		buf.sel_buf->Print(str, csr.layer, initial_x, csr.py, text_color.fg, text_color.bg, transparency);
		buf.sel_buf->SetTile(input_csr, csr.layer, csr.px, csr.py, false);

		wnd->Update();

		SDL_Event e = { 0 };
		if (global_proc(&e)) continue;

		if (e.type == SDL_KEYDOWN) {
			auto key = e.key.keysym.sym;
			if (key == SDLK_RETURN) {
				running = false;
			}
			else if (key == SDLK_ESCAPE) {
				str = "";
				running = false;
			}
			else if (key == SDLK_BACKSPACE && str.length() > 0) {
				str.pop_back();
				ix--;
				csr.px--;
			}
			else if (str.length() < maxlen) {
				if (key >= 0x20 && key < 0x7f) {
					if (TKey::CapsLock()) {
						key = String::ToUpper(key);
					}
					if (TKey::Shift()) {
						key = String::ToUpper(String::ShiftChar(key));
					}
					str.push_back((char)key);
					ix++;
					csr.px++;
				}
			}
		}
	}

	buf.sel_buf->PutChar(0x00, csr.layer, csr.px, csr.py, text_color.fg, text_color.bg, transparency);
	return str;
}

//=============================================================================
//								PRIVATE
//=============================================================================

bool TGL::global_proc(SDL_Event* e)
{
	SDL_PollEvent(e);

	if (e->type == SDL_QUIT) {
		exit();
		return true;
	}
	else if (e->type == SDL_KEYDOWN) {
		auto key = e->key.keysym.sym;
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
void TGL::print_tile_string(string text, bool raw, bool add_frames, int fgc, int bgc)
{
	const int initial_x = csr.px;
	bool escape = false;
	string escape_seq = "";
	for (int i = 0; i < text.length(); i++) {
		int ch = text[i];
		if (ch == '\n') {
			csr.py++;
			csr.px = initial_x;
		}
		else if (!raw && ch == '{') {
			escape = true;
			continue;
		}
		else if (!raw && ch == '}') {
			escape = false;
			const string upper_escape_seq = String::ToUpper(escape_seq);
			if (String::StartsWith(upper_escape_seq, 'C')) {
				ch = String::ToInt(String::Skip(upper_escape_seq, 1));
				auto tile = TTileSeq(ch, fgc, bgc);
				if (add_frames) {
					TTileSeq* existing_tile = &buf.sel_buf->GetTile(csr.layer, csr.px, csr.py);
					if (existing_tile->IsEmpty()) {
						buf.sel_buf->SetTile(tile, csr.layer, csr.px, csr.py, transparency);
					}
					else {
						existing_tile->Add(tile.First());
					}
				}
				else {
					buf.sel_buf->SetTile(tile, csr.layer, csr.px, csr.py, transparency);
				}
				csr.px++;
				escape_seq = "";
				continue;
			}
			else if (String::StartsWith(upper_escape_seq, 'F')) {
				fgc = String::ToInt(String::Skip(upper_escape_seq, 1));
				escape_seq = "";
				continue;
			}
			else if (String::StartsWith(upper_escape_seq, "/F")) {
				fgc = text_color.fg;
				escape_seq = "";
				continue;
			}
			else if (String::StartsWith(upper_escape_seq, 'B')) {
				bgc = String::ToInt(String::Skip(upper_escape_seq, 1));
				escape_seq = "";
				continue;
			}
			else if (String::StartsWith(upper_escape_seq, "/B")) {
				bgc = text_color.bg;
				escape_seq = "";
				continue;
			}
			else {
				continue;
			}
		}
		else if (escape) {
			escape_seq += ch;
			continue;
		}
		else {
			auto tile = TTileSeq(ch, fgc, bgc);
			if (add_frames) {
				TTileSeq* existing_tile = &buf.sel_buf->GetTile(csr.layer, csr.px, csr.py);
				if (existing_tile->IsEmpty()) {
					buf.sel_buf->SetTile(tile, csr.layer, csr.px, csr.py, transparency);
				}
				else {
					existing_tile->Add(tile.First());
				}
			}
			else {
				buf.sel_buf->SetTile(tile, csr.layer, csr.px, csr.py, transparency);
			}
			csr.px++;
			escape_seq = "";
		}
	}
}
