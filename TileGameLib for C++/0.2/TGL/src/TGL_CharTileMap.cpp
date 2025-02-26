#include "TGL_CharTileMap.h"
#include "TGL_Charset.h"
#include "TGL_Palette.h"

namespace TGL
{
	CharTileMap::CharTileMap()
	{
	}

	CharTileMap::~CharTileMap()
	{
	}

	void CharTileMap::SetCharset(Charset* charset)
	{
		this->charset = charset;
	}

	void CharTileMap::SetPalette(Palette* palette)
	{
		this->palette = palette;
	}

	void CharTileMap::SetCharsetAndPalette(Charset* charset, Palette* palette)
	{
		SetCharset(charset);
		SetPalette(palette);
	}

	void CharTileMap::SetCellCount(const Size& size)
	{
		cells.clear();
		cols = size.GetWidth();
		rows = size.GetHeight();
		cellCount = cols * rows;

		for (int i = 0; i < cellCount; i++)
			cells.push_back(CharTile());
	}

	void CharTileMap::SetTile(const Point& pos, const CharTile& tile)
	{
		if (pos.GetX() >= 0 && pos.GetY() >= 0 && pos.GetX() < cols && pos.GetY() < rows)
			cells[pos.GetY() * cols + pos.GetX()] = tile;
	}

	CharTile& CharTileMap::GetTile(const Point& pos)
	{
		return cells[pos.GetY() * cols + pos.GetX()];
	}

	void CharTileMap::Fill(const CharTile& tile)
	{
		for (int i = 0; i < cellCount; i++)
			cells[i] = tile;
	}

	void CharTileMap::Draw(Graphics* gr, const Point& pos)
	{
		if (!visible || !charset || !palette)
			return;

		Point currentPos = pos;

		for (int y = 0; y < rows; y++) {
			for (int x = 0; x < cols; x++) {
				CharTile& tile = GetTile(Point(x, y));
				if (tile.HasAnyChar())
					tile.Draw(gr, charset, palette, pos);

				currentPos = currentPos.Move(BitPattern::Width, 0);
			}
			currentPos = Point(pos.GetX(), currentPos.GetY() + BitPattern::Height);
		}
	}
}
