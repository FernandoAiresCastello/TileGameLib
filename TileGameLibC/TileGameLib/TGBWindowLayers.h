/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <vector>
#include "TGlobal.h"
#include "TGBTile.h"

namespace TileGameLib
{
	class TGBWindow;
	class TGBTileLayer;
	class TGBSprite;

	class TGBWindowLayers
	{
	public:
		const int Cols;
		const int Rows;

		TGBWindowLayers(TGBWindow* window);
		~TGBWindowLayers();

		bool EnableBg0 = true;
		void SetBg0Tile(TGBTile tile, int x, int y);
		void FillBg0(TGBTile tile);

		bool EnableBg1 = true;
		void SetBg1Tile(TGBTile tile, int x, int y);
		void FillBg1(TGBTile tile);

		bool EnableWnd = true;
		void SetWndTile(TGBTile tile, int x, int y);
		void FillWnd(TGBTile tile);

		bool EnableSpr0 = true;
		TGBSprite* AddSprite0();
		bool EnableSpr1 = true;
		TGBSprite* AddSprite1();

		void Draw();
		void EnableAll();
		void DisableAll();
	
	private:
		TGBWindow* Window = nullptr;
		TGBTileLayer* Bg0 = nullptr;
		TGBTileLayer* Bg1 = nullptr;
		TGBTileLayer* Wnd = nullptr;
		std::vector<TGBSprite*> Spr0;
		std::vector<TGBSprite*> Spr1;

		void DrawBg(TGBTileLayer* layer);
		void DrawWnd(TGBTileLayer* layer);
		void DrawSpr(std::vector<TGBSprite*>& sprites);
		void SortSpritesByPriority(std::vector<TGBSprite*>& sprites);
	};
}
