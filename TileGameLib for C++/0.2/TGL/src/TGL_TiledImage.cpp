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
        if (tileSize.GetWidth() <= 0 || tileSize.GetHeight() <= 0)
            return;

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
                if (transparent)
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

    Image* TiledImage::GetTile(Index index)
    {
        if (index >= 0 && index < tiles.size())
            return &tiles[index];

        return nullptr;
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
