#include <algorithm>
#include "TGBWindowLayers.h"
#include "TGBWindow.h"
#include "TGBTileLayer.h"
#include "TGBSprite.h"

namespace TileGameLib
{
	TGBWindowLayers::TGBWindowLayers(TGBWindow* window) : 
		Window(window), Cols(32), Rows(32)
	{
		Bg0 = new TGBTileLayer(Cols, Rows);
		Bg1 = new TGBTileLayer(Cols, Rows);
		Wnd = new TGBTileLayer(Cols, Rows);
	}

	TGBWindowLayers::~TGBWindowLayers()
	{
		delete Bg0;
		delete Bg1;
		delete Wnd;
		
		for (auto* spr : Spr0) { delete spr; spr = nullptr; }
		Spr0.clear();
		for (auto* spr : Spr1) { delete spr; spr = nullptr; }
		Spr1.clear();
	}

	void TGBWindowLayers::SetBg0Tile(TGBTile tile, int x, int y)
	{
		Bg0->SetTile(tile, x, y);
	}

	void TGBWindowLayers::SetBg1Tile(TGBTile tile, int x, int y)
	{
		Bg1->SetTile(tile, x, y);
	}

	void TGBWindowLayers::SetWndTile(TGBTile tile, int x, int y)
	{
		Wnd->SetTile(tile, x, y);
	}

	void TGBWindowLayers::FillBg0(TGBTile tile)
	{
		Bg0->Fill(tile);
	}

	void TGBWindowLayers::FillBg1(TGBTile tile)
	{
		Bg1->Fill(tile);
	}

	void TGBWindowLayers::FillWnd(TGBTile tile)
	{
		Wnd->Fill(tile);
	}

	TGBSprite* TGBWindowLayers::AddSprite0()
	{
		auto spr = new TGBSprite();
		Spr0.push_back(spr);
		return spr;
	}

	TGBSprite* TGBWindowLayers::AddSprite1()
	{
		auto spr = new TGBSprite();
		Spr1.push_back(spr);
		return spr;
	}

	void TGBWindowLayers::Draw()
	{
		Window->ClearBackground();
		if (EnableBg0) DrawBg(Bg0);
		if (EnableSpr0) DrawSpr(Spr0);
		if (EnableBg1) DrawBg(Bg1);
		if (EnableWnd) DrawWnd(Wnd);
		if (EnableSpr1) DrawSpr(Spr1);
	}

	void TGBWindowLayers::EnableAll()
	{
		EnableBg0 = true;
		EnableBg1 = true;
		EnableWnd = true;
		EnableSpr0 = true;
		EnableSpr1 = true;
	}

	void TGBWindowLayers::DisableAll()
	{
		EnableBg0 = false;
		EnableBg1 = false;
		EnableWnd = false;
		EnableSpr0 = false;
		EnableSpr1 = false;
	}

	void TGBWindowLayers::DrawBg(TGBTileLayer* layer)
	{
		Window->DrawTileLayer(layer, Window->LayerPos.BgX, Window->LayerPos.BgY);
		Window->DrawTileLayer(layer, Window->LayerPos.BgX - 256, Window->LayerPos.BgY);
		Window->DrawTileLayer(layer, Window->LayerPos.BgX, Window->LayerPos.BgY - 256);
		Window->DrawTileLayer(layer, Window->LayerPos.BgX - 256, Window->LayerPos.BgY - 256);
	}

	void TGBWindowLayers::DrawWnd(TGBTileLayer* layer)
	{
		Window->DrawTileLayer(layer, Window->LayerPos.WndX, Window->LayerPos.WndY);
	}

	void TGBWindowLayers::DrawSpr(std::vector<TGBSprite*>& sprites)
	{
		if (sprites.empty()) return;

		SortSpritesByPriority(sprites);

		for (auto* spr : sprites)
		{
			if (spr->Visible)
				Window->DrawTile(spr->Tile, spr->X, spr->Y);
		}
	}

	void TGBWindowLayers::SortSpritesByPriority(std::vector<TGBSprite*>& sprites)
	{
		sort(sprites.begin(), sprites.end(), [](const auto& lhs, const auto& rhs)
		{
			return lhs->Priority < rhs->Priority;
		});
	}
}
