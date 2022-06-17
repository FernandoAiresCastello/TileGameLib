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
	}

	TGBWindow::~TGBWindow()
	{
	}

	void TGBWindow::Update()
	{
		TWindowBase::Update();
	}

	void TGBWindow::DrawTile(TGBTile& tile, int x, int y, 
		PaletteIndex color0, PaletteIndex color1, PaletteIndex color2, PaletteIndex color3,
		bool transparent)
	{
		int px = x;
		int py = y;
		RGB rgb = 0;
		bool skip = false;

		for (int i = 0; i < TGBTile::Length; i++)
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
			if (px >= x + TGBTile::Width) {
				px = x;
				py++;
			}
		}
	}

	void TGBWindow::SetPixel(int x, int y, RGB rgb)
	{
		FillRect(x, y, PixelWidth, PixelHeight, rgb);
	}
}
