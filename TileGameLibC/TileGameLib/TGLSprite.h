/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include "TGLGlobal.h"
#include "TGLPalette.h"
#include "TGLTileset.h"

struct TGLSprite
{
	void create(spriteid spr);
	void select(spriteid spr);
	void destroy();
	void add_tile(tileid tile, colorid fg, colorid bg);
	void show();
	void hide();
	void toggle();
	bool visible();
	void move(int dx, int dy);
	void set_pos(int x, int y);
	int x();
	int y();
	void tron();
	void troff();
	void enable_all();
	void disable_all();

private:
	friend struct TGL;
	TTileSeq cur_tile;
	TBufferedWindow* wnd = nullptr;
	TGLTileset* tileset = nullptr;
	TGLPalette* palette = nullptr;
	TSprite* sel_sprite = nullptr;
};
