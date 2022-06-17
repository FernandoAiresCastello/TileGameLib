/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include "TGBWindow.h"
#include "TPalette.h"

namespace TileGameLib
{
	TGBWindow::TGBWindow(int pixelWidth, int pixelHeight) :
		TWindowBase(160 * pixelWidth, 144 * pixelHeight),
		PixelWidth(pixelWidth), PixelHeight(pixelHeight),
		Pal(TPalette::Default)
	{
		BackColor = 0xffffff;
		ClearBackground();
		Update();
	}

	TGBWindow::~TGBWindow()
	{
	}

	void TGBWindow::Update()
	{
		TWindowBase::Update();
	}

	void TGBWindow::SetPixel(int x, int y, RGB rgb)
	{
		FillRect(x, y, PixelWidth, PixelHeight, rgb);
	}

	void TGBWindow::DrawTile(TGBTileDef& tile, int x, int y,
		PaletteIndex color0, PaletteIndex color1, PaletteIndex color2, PaletteIndex color3,
		bool transparent)
	{
		int px = x;
		int py = y;
		RGB rgb = 0;
		bool skip = false;

		for (int i = 0; i < TGBTileDef::Length; i++)
		{
			skip = false;

			switch (tile.Data[i])
			{
				case TGBTileColor::Color0:
				{
					if (transparent)
						skip = true;
					else
						rgb = Pal->GetColorRGB(color0);
					break;
				}

				case TGBTileColor::Color1: rgb = Pal->GetColorRGB(color1); break;
				case TGBTileColor::Color2: rgb = Pal->GetColorRGB(color2); break;
				case TGBTileColor::Color3: rgb = Pal->GetColorRGB(color3); break;
				
				default: skip = true;
			}

			if (!skip)
				SetPixel(px, py, rgb);

			px++;
			if (px >= x + TGBTileDef::Width) {
				px = x;
				py++;
			}
		}
	}

	void TGBWindow::DrawTile(TGBTileset& tileset, int tileIndex, int x, int y, 
		PaletteIndex color0, PaletteIndex color1, PaletteIndex color2, PaletteIndex color3, 
		bool transparent)
	{
		DrawTile(tileset.Get(tileIndex), x, y, color0, color1, color2, color3, transparent);
	}

	void TGBWindow::DrawTileLayer(TGBTileLayer& layer, TGBTileset& tileset, int x, int y)
	{
		int sx = x;
		int sy = y;

		for (int ly = 0; ly < layer.Rows; ly++) {
			for (int lx = 0; lx < layer.Cols; lx++) {
				TGBTile* tile = layer.GetTile(lx, ly);
				if (!tile->IsEmpty()) {
					DrawTile(tileset.Get(tile->Index), sx, sy, 
						tile->Color0, tile->Color1, tile->Color2, tile->Color3, tile->Transparent);
				}
				sx += TGBTileDef::Width;
			}
			sx = x;
			sy += TGBTileDef::Height;
		}
	}
}
