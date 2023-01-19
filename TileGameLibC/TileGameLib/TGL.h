/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include <vector>
#include <map>
#include "TileGameLib.h"
using namespace std;
using namespace TileGameLib;

extern struct TGL tgl;

struct TGL
{
	//============================================================================
	//									TGLAPI
	//============================================================================

	void init();
	void exit();
	void halt();
	void global_proc();
	void screen(int cols, int rows, int layers, int hstr, int vstr);
	void title(string title);
	void pal(int ix, int rgb);
	int get_pal(int ix);
	void chr(int ix, string pixels);
	string get_chr(int ix);
	void wcol(int ix);
	void cls();
	void vsync();
	void layer(int layer);
	void locate(int x, int y);
	void tron();
	void troff();
	void color(int fgc, int bgc);
	void fcol(int ix);
	void bcol(int ix);
	void print(string text);
	void pause(int ms);
	void tile_new(int ch, int fg, int bg);
	void tile_add(int ch, int fg, int bg);
	void tile_parse(string str);
	void put();

	//============================================================================

private:
	TBufferedWindow* wnd = nullptr;
	TPalette* palette = nullptr;
	TCharset* charset = nullptr;
	map<string, TTileBuffer*> buffers;
	TTileBuffer* sel_buf = nullptr;
	TTileSeq work_tile;
	bool transparency = false;

	struct {
		int layer = 0;
		int x = 0;
		int y = 0;
	} csr;

	struct {
		int fg = 1;
		int bg = 0;
	} txt_color;

	void init_default_pal();
	void init_default_chr();
};
