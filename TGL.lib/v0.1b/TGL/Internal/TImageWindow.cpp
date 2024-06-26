#include "TImageWindow.h"
#include "TTiledImage.h"
#include "TImage.h"

namespace TGL_Internal
{
	TImageWindow::TImageWindow(int width, int height) : 
		TWindowBase(width, height)
	{
	}

	TImageWindow::~TImageWindow()
	{
	}

	void TImageWindow::DrawImageTile(TTiledImage* timg, int tix, int x, int y)
	{
		TImage* img = timg->GetTile(tix);
		int ix = x;
		int iy = y;

		for (int px = 0; px < timg->TileWidth; px++) {
			for (int py = 0; py < timg->TileHeight; py++) {
				TColor& color = img->GetPixel(px, py);
				if (!(img->IsTransparent() && img->GetTransparency().Equals(color))) {
					SetPixel(ix, iy, color.ToColorRGB());
				}
				ix++;
			}
			iy++;
		}
	}
}
