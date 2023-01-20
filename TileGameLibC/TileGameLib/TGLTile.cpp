/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#include "TGLTile.h"

void TGLTile::newf(int ch, int fg, int bg)
{
	cur_tile = TTileSeq(ch, fg, bg);
}
void TGLTile::add(int ch, int fg, int bg)
{
	cur_tile.Add(ch, fg, bg);
}
int TGLTile::getc(int ix)
{
	return cur_tile.GetChar(ix);
}
int TGLTile::getf(int ix)
{
	return cur_tile.GetForeColor(ix);
}
int TGLTile::getb(int ix)
{
	return cur_tile.GetBackColor(ix);
}
void TGLTile::color(int ix, int fg, int bg)
{
	setf(ix, fg);
	setb(ix, bg);
}
void TGLTile::setc(int ix, int ch)
{
	cur_tile.SetChar(ix, ch);
}
void TGLTile::setf(int ix, int fg)
{
	cur_tile.SetForeColor(ix, fg);
}
void TGLTile::setb(int ix, int bg)
{
	cur_tile.SetBackColor(ix, bg);
}
void TGLTile::parse(string str)
{
	cur_tile.Parse(str);
}
void TGLTile::prop(string prop, string value)
{
	cur_tile.Prop.Set(prop, value);
}
string TGLTile::prop_s(string prop)
{
	return cur_tile.Prop.GetString(prop);
}
int TGLTile::prop_n(string prop)
{
	return cur_tile.Prop.GetNumber(prop);
}
