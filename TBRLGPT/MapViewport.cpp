/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "MapViewport.h"
#include "Graphics.h"
#include "Map.h"
#include "Palette.h"
#include "ObjectLayer.h"
#include "Window.h"
#include "UIContext.h"
#include "Timer.h"
#include "Project.h"

namespace TBRLGPT
{
	int AnimationFrame = 0;
	void AdvanceAnimation()
	{
		AnimationFrame++;
	}

	MapViewport::MapViewport(UIContext* ctx, class Map* map, 
		int x, int y, int width, int height, int viewx, int viewy, int animDelay)
	{
		Ctx = ctx;
		Map = map;
		X = x;
		Y = y;
		Width = width;
		Height = height;
		ViewX = viewx;
		ViewY = viewy;
		Win = new Window(Ctx, x - 1, y - 1, width, height);
		AnimationTimer.AddTimer("Animation", 10, AdvanceAnimation);
		AnimationTimer.SetDelay(animDelay);
		AnimationTimer.Start();
	}

	MapViewport::~MapViewport()
	{
	}

	void MapViewport::SetMap(class Map* map)
	{
		Map = map;
	}

	void MapViewport::SetAnimationDelay(int ms)
	{
		AnimationTimer.SetDelay(ms);
	}

	void MapViewport::Draw()
	{
		for (int i = 0; i < Map->GetLayerCount(); i++)
			DrawLayer(i);
	}

	void MapViewport::SetX(int x)
	{
		X = x;
	}

	void MapViewport::SetY(int y)
	{
		Y = y;
	}

	void MapViewport::SetWidth(int w)
	{
		Width = w;
	}

	void MapViewport::SetHeight(int h)
	{
		Height = h;
	}

	void MapViewport::DrawLayer(int index)
	{
		ObjectLayer* layer = Map->GetLayer(index);
		Palette* pal = Map->GetProject()->GetPalette();
		Charset* chars = Map->GetProject()->GetCharset();
		bool isTopLayer = layer == Map->GetTopLayer();
		bool invertColorArea = isTopLayer && InvertedColorArea.IsValid();

		int vx = ViewX;
		int vy = ViewY;
		for (int y = Y; y < Y + Height; y++) {
			for (int x = X; x < X + Width; x++) {
				Object* o = layer->GetObject(vx, vy);
				if (o) {
					if (index == 0 && o->IsVoid()) {
						Ctx->Gr->PutChar(chars, 0, x, y,
							pal->Get(Map->GetBackColor())->ToInteger(),
							pal->Get(Map->GetBackColor())->ToInteger());
					}
					else if (index == 0 || !o->IsVoid()) {
						ObjectChar& ch = o->GetAnimation().GetFrame(AnimationFrame);
						int fgc = pal->Get(ch.ForeColorIx)->ToInteger();
						int bgc = pal->Get(ch.BackColorIx)->ToInteger();
						if (!invertColorArea) {
							Ctx->Gr->PutChar(chars, ch.Index, x, y, fgc, bgc);
						}
						else if (vx >= InvertedColorArea.X && vy >= InvertedColorArea.Y &&
							vx <= InvertedColorArea.Width && vy <= InvertedColorArea.Height) {
							Ctx->Gr->PutChar(chars, ch.Index, x, y, bgc, fgc);
						}
					}
				}
				else {
					ObjectAnim& anim = Map->GetOutOfBoundsObject()->GetAnimation();
					if (anim.GetSize() > 0) {
						ObjectChar& oob = anim.GetFrame(AnimationFrame);
						Ctx->Gr->PutChar(chars, oob.Index, x, y,
							pal->Get(oob.ForeColorIx)->ToInteger(),
							pal->Get(oob.BackColorIx)->ToInteger());
					}
					else {
						Ctx->Gr->PutChar(chars, 0, x, y,
							pal->Get(Map->GetBackColor())->ToInteger(),
							pal->Get(Map->GetBackColor())->ToInteger());
					}
				}
				vx++;
			}
			vx = ViewX;
			vy++;
		}
	}

	int MapViewport::GetMapWidth()
	{
		return Map->GetWidth();
	}

	int MapViewport::GetMapHeight()
	{
		return Map->GetHeight();
	}

	int MapViewport::GetX()
	{
		return X;
	}

	int MapViewport::GetY()
	{
		return Y;
	}

	int MapViewport::GetWidth()
	{
		return Width;
	}

	int MapViewport::GetHeight()
	{
		return Height;
	}

	void MapViewport::SetScroll(int x, int y)
	{
		ViewX = x;
		ViewY = y;
	}

	void MapViewport::ScrollView(int dx, int dy)
	{
		ViewX += dx;
		ViewY += dy;
	}

	void MapViewport::ClearBorder()
	{
		Ctx->Clear();
	}

	void MapViewport::DrawBorder()
	{
		Win->DrawBorder();
	}

	void MapViewport::SetInvertedColorArea(Rect area)
	{
		InvertedColorArea = area;
	}
}
