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
void TGLSprite::destroy(spriteid spr)
{
	wnd->RemoveSprite(spr);
}
void TGLSprite::add_tile(spriteid spr, tileid tile, colorid fg, colorid bg)
{
	TSprite* sprite = wnd->GetSprite(spr);
	if (sprite) {
		sprite->Tile.Add(tileset->get_index(tile), palette->get_index(fg), palette->get_index(bg));
	}
}
void TGLSprite::show(spriteid spr)
{
	TSprite* sprite = wnd->GetSprite(spr);
	if (sprite) {
		sprite->Visible = true;
	}
}
void TGLSprite::hide(spriteid spr)
{
	TSprite* sprite = wnd->GetSprite(spr);
	if (sprite) {
		sprite->Visible = false;
	}
}
void TGLSprite::toggle(spriteid spr)
{
	TSprite* sprite = wnd->GetSprite(spr);
	if (sprite) {
		sprite->Visible = !sprite->Visible;
	}
}
void TGLSprite::move(spriteid spr, int dx, int dy)
{
	TSprite* sprite = wnd->GetSprite(spr);
	if (sprite) {
		sprite->Move(dx, dy);
	}
}
void TGLSprite::set_pos(spriteid spr, int x, int y)
{
	TSprite* sprite = wnd->GetSprite(spr);
	if (sprite) {
		sprite->SetPos(x, y);
	}
}
void TGLSprite::tron(spriteid spr)
{
	TSprite* sprite = wnd->GetSprite(spr);
	if (sprite) {
		sprite->Transparent = true;
	}
}
void TGLSprite::troff(spriteid spr)
{
	TSprite* sprite = wnd->GetSprite(spr);
	if (sprite) {
		sprite->Transparent = false;
	}
}
void TGLSprite::enable()
{
	wnd->EnableSprites(true);
}
void TGLSprite::disable()
{
	wnd->EnableSprites(false);
}
