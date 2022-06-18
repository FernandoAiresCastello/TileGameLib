/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include <CppUtils.h>
#include "TGBWindow.h"
#include "TPalette.h"

namespace TileGameLib
{
	using namespace CppUtils;

	TGBWindow::TGBWindow(int pixelWidth, int pixelHeight) :
		TWindowBase(160 * pixelWidth, 144 * pixelHeight),
		PixelBufWidth(160), PixelBufHeight(144),
		PixelWidth(pixelWidth), PixelHeight(pixelHeight),
		Pal(TPalette::Default)
	{
		Chr = new TGBTileset();
		BackColor = 0xffffff;
		Layer.Bg = new TGBTileLayer(32, 32);
		Layer.Wnd = new TGBTileLayer(32, 32);

		Update();
	}

	TGBWindow::~TGBWindow()
	{
		delete Chr;
		delete Layer.Bg;
		delete Layer.Wnd;
		// todo: delete sprites
	}

	void TGBWindow::Update()
	{
		DrawLayers();
		TWindowBase::Update();
	}

	TPalette* TGBWindow::GetPalette()
	{
		return Pal;
	}

	TGBTileset* TGBWindow::GetTileset()
	{
		return Chr;
	}

	void TGBWindow::SetPixel(int x, int y, RGB rgb)
	{
		FillRect(x, y, PixelWidth, PixelHeight, rgb);
	}

	void TGBWindow::DrawTile(int tileIndex, int x, int y,
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

			switch (Chr->Get(tileIndex).Data[i])
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

	void TGBWindow::DrawTileLayer(TGBTileLayer* layer, int x, int y)
	{
		int sx = x;
		int sy = y;

		for (int ly = 0; ly < layer->Rows; ly++) {
			for (int lx = 0; lx < layer->Cols; lx++) {
				if (sx > -8 && sy > -8 && sx < PixelBufWidth && sy < PixelBufHeight) {
					TGBTile* tile = layer->GetTile(lx, ly);
					if (!tile->IsEmpty()) {
						DrawTile(tile->Index, sx, sy,
							tile->Color0, tile->Color1, tile->Color2, tile->Color3, tile->Transparent);
					}
				}
				sx += TGBTileDef::Width;
			}
			sx = x;
			sy += TGBTileDef::Height;
		}
	}

	void TGBWindow::SetBackgroundPos(int x, int y)
	{
		LayerPos.BgX = x;
		LayerPos.BgY = y;

		if (LayerPos.BgX > 256) LayerPos.BgX = 0;
		else if (LayerPos.BgX < 0) LayerPos.BgX = 256;
		if (LayerPos.BgY > 256) LayerPos.BgY = 0;
		else if (LayerPos.BgY < 0) LayerPos.BgY = 256;
	}

	void TGBWindow::ScrollBackground(int dx, int dy)
	{
		SetBackgroundPos(LayerPos.BgX + dx, LayerPos.BgY + dy);
	}

	void TGBWindow::SetWindowLayerPos(int x, int y)
	{
		LayerPos.WndX = x;
		LayerPos.WndY = y;
	}

	void TGBWindow::DrawLayers()
	{
		ClearBackground();
		DrawBackgroundLayer();
		DrawWindowLayer();
		DrawSpriteLayer();
	}

	void TGBWindow::DrawBackgroundLayer()
	{
		DrawTileLayer(Layer.Bg, LayerPos.BgX, LayerPos.BgY);
		DrawTileLayer(Layer.Bg, LayerPos.BgX - 256, LayerPos.BgY);
		DrawTileLayer(Layer.Bg, LayerPos.BgX, LayerPos.BgY - 256);
		DrawTileLayer(Layer.Bg, LayerPos.BgX - 256, LayerPos.BgY - 256);
	}

	void TGBWindow::DrawWindowLayer()
	{
		DrawTileLayer(Layer.Wnd, LayerPos.WndX, LayerPos.WndY);
	}
	
	void TGBWindow::DrawSpriteLayer()
	{
		// todo
	}
}
