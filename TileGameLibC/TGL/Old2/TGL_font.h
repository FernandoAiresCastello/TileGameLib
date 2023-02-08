#pragma once
#include "TGL_global.h"
#include "TGL_tile.h"

struct font
{
	font();
	~font();

	void set(byte ch, string pixels);

private:
	friend struct TGL;

	font(const font&) = delete;
	font(font&&) = delete;

	vector<tile*> chars;

	void add_blank();
	void set_blank(byte ch);
	void init_default();
};
