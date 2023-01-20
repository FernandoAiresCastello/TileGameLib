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
void TGL::global_proc()
{
	SDL_Event e;
	SDL_PollEvent(&e);
	if (e.type == SDL_QUIT) {
		exit();
	}
	else if (e.type == SDL_KEYDOWN) {
		auto key = e.key.keysym.sym;
		if (key == SDLK_ESCAPE) {
			exit();
		}
		else if (TKey::Alt() && key == SDLK_RETURN && wnd) {
			wnd->ToggleFullscreen();
		}
	}
}
void TGL::screen(int cols, int rows, int layers, int hstr, int vstr)
{
	wnd = new TBufferedWindow(layers, cols, rows, hstr, vstr);

	pal.palette = wnd->GetPalette();
	pal.init_default();
	chr.charset = wnd->GetCharset();
	chr.init_default();

	buf.init(wnd);

	wnd->Show();
}
void TGL::title(string title)
{
	wnd->SetTitle(title);
}
void TGL::wcol(int ix)
{
	wnd->SetBackColor(pal.get(ix));
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
	csr.x = x;
	csr.y = y;
}
void TGL::tron()
{
	transparency = true;
}
void TGL::troff()
{
	transparency = false;
}
void TGL::color(int fgc, int bgc)
{
	fcolor(fgc);
	bcolor(bgc);
}
void TGL::fcolor(int ix)
{
	text_color.fg = ix;
}
void TGL::bcolor(int ix)
{
	text_color.bg = ix;
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
	buf.sel_buf->SetTile(tile.cur_tile, csr.layer, csr.x, csr.y, transparency);
}
void TGL::get()
{
	tile.cur_tile = buf.sel_buf->GetTile(csr.layer, csr.x, csr.y);
}
void TGL::del()
{
	buf.sel_buf->EraseTile(csr.layer, csr.x, csr.y);
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
	TTileSeq tile = buf.sel_buf->GetTile(csr.layer, csr.x, csr.y);
	buf.sel_buf->EraseTile(csr.layer, csr.x, csr.y);
	buf.sel_buf->SetTile(tile, csr.layer, csr.x + dx, csr.y + dy, transparency);
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

//=============================================================================
//								PRIVATE
//=============================================================================

void TGL::print_tile_string(string text, bool raw, bool add_frames, int fgc, int bgc)
{
	const int initial_x = csr.x;
	bool escape = false;
	string escape_seq = "";
	for (int i = 0; i < text.length(); i++) {
		int ch = text[i];
		if (ch == '\n') {
			csr.y++;
			csr.x = initial_x;
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
					TTileSeq* existing_tile = &buf.sel_buf->GetTile(csr.layer, csr.x, csr.y);
					if (existing_tile->IsEmpty()) {
						buf.sel_buf->SetTile(tile, csr.layer, csr.x, csr.y, transparency);
					}
					else {
						existing_tile->Add(tile.First());
					}
				}
				else {
					buf.sel_buf->SetTile(tile, csr.layer, csr.x, csr.y, transparency);
				}
				csr.x++;
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
				TTileSeq* existing_tile = &buf.sel_buf->GetTile(csr.layer, csr.x, csr.y);
				if (existing_tile->IsEmpty()) {
					buf.sel_buf->SetTile(tile, csr.layer, csr.x, csr.y, transparency);
				}
				else {
					existing_tile->Add(tile.First());
				}
			}
			else {
				buf.sel_buf->SetTile(tile, csr.layer, csr.x, csr.y, transparency);
			}
			csr.x++;
			escape_seq = "";
		}
	}
}
