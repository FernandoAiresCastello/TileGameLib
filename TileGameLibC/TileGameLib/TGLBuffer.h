/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include "TGLGlobal.h"

struct TGLBuffer
{
	void newb(string id, int cols, int rows, int layers);
	void sel(string id);
	void show();
	void hide();
	void view(int x, int y, int cols, int rows);
	void scrl(int dx, int dy);
	int cols();
	int rows();

private:
	friend struct TGL;
	map<string, TTileBuffer*> buffers;
	TTileBuffer* sel_buf = nullptr;
	TBufferedWindow* wnd = nullptr;

	void init(TBufferedWindow* pwnd);
};
