/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#include "TGLTile.h"

void TGLTile::set(tileid ch, colorid fg, colorid bg)
{
	cur_tile = TTileSeq(tileset->get_index(ch), palette->get_index(fg), palette->get_index(bg));
}
void TGLTile::add(tileid ch, colorid fg, colorid bg)
{
	cur_tile.Add(tileset->get_index(ch), palette->get_index(fg), palette->get_index(bg));
}
void TGLTile::prop(string prop, string value)
{
	cur_tile.Prop.Set(prop, value);
}
void TGLTile::prop(string prop, int value)
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
void TGLTile::store(string id)
{
	presets[id] = cur_tile;
}
void TGLTile::load(string id)
{
	cur_tile = presets[id];
}
