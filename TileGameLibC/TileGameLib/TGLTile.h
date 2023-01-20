/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include <string>
#include "TileGameLib.h"
using namespace std;
using namespace TileGameLib;

struct TGLTile
{
	void newf(int ch, int fg, int bg);
	void add(int ch, int fg, int bg);
	int getc(int ix);
	int getf(int ix);
	int getb(int ix);
	void color(int ix, int fg, int bg);
	void setc(int ix, int ch);
	void setf(int ix, int fg);
	void setb(int ix, int bg);
	void parse(string str);
	void prop(string prop, string value);
	string prop_s(string prop);
	int prop_n(string prop);

private:
	friend struct TGL;
	TTileSeq cur_tile;
};
