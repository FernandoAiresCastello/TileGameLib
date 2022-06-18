/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include <vector>
#include "TGlobal.h"
#include "TWindowBase.h"
#include "TGBTileDef.h"
#include "TGBTileset.h"
#include "TGBTileLayer.h"

namespace TileGameLib
{
	class TPalette;

	class TGBWindow : public TWindowBase
	{
	public:
		struct {
			TGBTileLayer* Bg = nullptr;
			TGBTileLayer* Wnd = nullptr;
			// todo: sprites
		} Layer;

		TGBWindow(int pixelWidth, int pixelHeight);
		virtual ~TGBWindow();
		virtual void Update();
		TPalette* GetPalette();
		TGBTileset* GetTileset();
		void SetBackgroundPos(int x, int y);
		void ScrollBackground(int dx, int dy);
		void SetWindowLayerPos(int x, int y);

	private:
		const int PixelBufWidth;
		const int PixelBufHeight;
		const int PixelWidth;
		const int PixelHeight;
		TPalette* Pal = nullptr;
		TGBTileset* Chr = nullptr;

		struct {
			int BgX = 0;
			int BgY = 0;
			int WndX = 0;
			int WndY = 0;
		} LayerPos;

		virtual void SetPixel(int x, int y, RGB rgb);

		void DrawTile(int tileIndex, int x, int y,
			PaletteIndex color0, PaletteIndex color1, PaletteIndex color2, PaletteIndex color3,
			bool transparent);

		void DrawTileLayer(TGBTileLayer* layer, int x, int y);

		void DrawLayers();
		void DrawBackgroundLayer();
		void DrawWindowLayer();
		void DrawSpriteLayer();
	};
}
