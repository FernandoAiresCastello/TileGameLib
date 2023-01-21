/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#include "TGLPalette.h"

void TGLPalette::add(colorid id, int rgb)
{
	int next_index = palette->GetSize();
	palette->Add(rgb);
	colorids[id] = next_index;
}
int TGLPalette::get_index(colorid id)
{
	if (colorids.find(id) == colorids.end()) {
		MsgBox::Error("Color not found with id: " + id);
		return 0;
	}
	return colorids[id];
}
int TGLPalette::get_rgb(colorid id)
{
	if (colorids.find(id) == colorids.end()) {
		MsgBox::Error("Color not found with id: " + id);
		return 0;
	}
	return palette->GetColorRGB(colorids[id]);
}
void TGLPalette::init_default()
{
	palette->DeleteAll();

	add("black", 0x000000);
	add("white", 0xffffff);
}
