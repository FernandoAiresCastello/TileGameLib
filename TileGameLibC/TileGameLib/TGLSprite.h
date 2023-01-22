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
	void destroy(spriteid spr);
	void add_tile(spriteid spr, tileid tile, colorid fg, colorid bg);
	void show(spriteid spr);
	void hide(spriteid spr);
	void toggle(spriteid spr);
	void move(spriteid spr, int dx, int dy);
	void set_pos(spriteid spr, int x, int y);
	void tron(spriteid spr);
	void troff(spriteid spr);
	void enable();
	void disable();

private:
	friend struct TGL;
	TTileSeq cur_tile;
	TBufferedWindow* wnd = nullptr;
	TGLTileset* tileset = nullptr;
	TGLPalette* palette = nullptr;
};
