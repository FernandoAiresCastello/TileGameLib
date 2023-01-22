/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#include "TGLSprite.h"

void TGLSprite::create(spriteid spr)
{
	TSprite* sprite = wnd->GetSprite(spr);
	if (!sprite) {
		TSprite sprite;
		sprite.Id = spr;
		sprite.Visible = false;
		wnd->AddSprite(sprite);
	}
}
void TGLSprite::select(spriteid spr)
{
	sel_sprite = wnd->GetSprite(spr);
}
void TGLSprite::destroy()
{
	wnd->RemoveSprite(sel_sprite->Id);
}
void TGLSprite::add_tile(tileid tile, colorid fg, colorid bg)
{
	sel_sprite->Tile.Add(tileset->get_index(tile), palette->get_index(fg), palette->get_index(bg));
}
void TGLSprite::show()
{
	sel_sprite->Visible = true;
}
void TGLSprite::hide()
{
	sel_sprite->Visible = false;
}
void TGLSprite::toggle()
{
	sel_sprite->Visible = !sel_sprite->Visible;
}
bool TGLSprite::visible()
{
	return sel_sprite->Visible;
}
void TGLSprite::move(int dx, int dy)
{
	sel_sprite->Move(dx, dy);
}
void TGLSprite::set_pos(int x, int y)
{
	sel_sprite->SetPos(x, y);
}
int TGLSprite::x()
{
	return sel_sprite->X;
}
int TGLSprite::y()
{
	return sel_sprite->Y;
}
void TGLSprite::tron()
{
	sel_sprite->Transparent = true;
}
void TGLSprite::troff()
{
	sel_sprite->Transparent = false;
}
void TGLSprite::enable_all()
{
	wnd->EnableSprites(true);
}
void TGLSprite::disable_all()
{
	wnd->EnableSprites(false);
}
