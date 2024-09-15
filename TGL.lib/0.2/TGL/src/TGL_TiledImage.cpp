#include "TGL_TiledImage.h"

namespace TGL
{
	TiledImage::TiledImage()
	{
	}

	TiledImage::~TiledImage()
	{
	}

	void TiledImage::GenerateTiles(const Size& tileSize)
	{
        this->tileSize = tileSize;
		tiles.clear();

        const int width = size.GetWidth();
        const int height = size.GetHeight();
        const int tileWidth = tileSize.GetWidth();
        const int tileHeight = tileSize.GetHeight();

        for (int y = 0; y < height; y += tileHeight) {
            for (int x = 0; x < width; x += tileWidth) {

                int currentTileWidth = std::min(tileWidth, width - x);
                int currentTileHeight = std::min(tileHeight, height - y);

                Image tile(Size(currentTileWidth, currentTileHeight));
                tile.SetTransparency(transparency);

                for (int ty = 0; ty < currentTileHeight; ++ty) {
                    for (int tx = 0; tx < currentTileWidth; ++tx) {
                        tile.SetPixel(GetPixel(Point(x + tx, y + ty)), Point(tx, ty));
                    }
                }

                tiles.push_back(std::move(tile));
            }
        }
	}

    Image* TiledImage::GetTile(int index)
    {
        return &tiles[index];
    }

    int TiledImage::GetTileCount() const
    {
        return tiles.size();
    }

    const Size& TiledImage::GetTileSize() const
    {
        return tileSize;
    }
}
