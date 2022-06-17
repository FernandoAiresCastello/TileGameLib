/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
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
		const int PixelWidth;
		const int PixelHeight;

		TGBWindow(int pixelWidth, int pixelHeight);
		virtual ~TGBWindow();
		virtual void Update();

		void DrawTile(TGBTileDef& tile, int x, int y,
			PaletteIndex color0, PaletteIndex color1, PaletteIndex color2, PaletteIndex color3,
			bool transparent);

		void DrawTile(TGBTileset& tileset, int tileIndex, int x, int y,
			PaletteIndex color0, PaletteIndex color1, PaletteIndex color2, PaletteIndex color3,
			bool transparent);

		void DrawTileLayer(TGBTileLayer& layer, TGBTileset& tileset, int x, int y);

	private:
		TPalette* Pal;
		virtual void SetPixel(int x, int y, RGB rgb);
	};
}
