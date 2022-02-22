/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include "TTileSeq.h"

namespace TileGameLib
{
	TTileSeq::TTileSeq()
	{
	}

	TTileSeq::TTileSeq(const TTileSeq& other)
	{
		for (auto& tile : other.Tiles)
			Add(tile);
	}

	TTileSeq::TTileSeq(TTile tile)
	{
		Add(tile);
	}

	TTileSeq::TTileSeq(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg)
	{
		Add(ch, fg, bg);
	}

	TTileSeq::TTileSeq(std::vector<TTile>& tiles)
	{
		Set(tiles);
	}

	bool TTileSeq::operator==(const TTileSeq& other)
	{
		if (Tiles.size() != other.Tiles.size())
			return false;

		for (int i = 0; i < Tiles.size(); i++) {
			if (Tiles[i] != other.Tiles[i])
				return false;
		}

		return true;
	}

	bool TTileSeq::operator!=(const TTileSeq& other)
	{
		return !operator==(other);
	}

	int TTileSeq::GetSize()
	{
		return Tiles.size();
	}

	bool TTileSeq::HasIndex(int ix)
	{
		return ix >= 0 && ix < Tiles.size();
	}

	void TTileSeq::Clear()
	{
		Tiles.clear();
	}

	void TTileSeq::Add(TTile tile)
	{
		Tiles.push_back(tile);
	}

	void TTileSeq::Add(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg)
	{
		Tiles.push_back(TTile(ch, fg, bg));
	}

	void TTileSeq::Add(std::vector<TTile>& tiles)
	{
		for (auto& tile : tiles)
			Tiles.push_back(tile);
	}

	void TTileSeq::Set(int ix, TTile tile)
	{
		Tiles[ix] = tile;
	}

	void TTileSeq::Set(int ix, CharsetIndex ch, PaletteIndex fg, PaletteIndex bg)
	{
		Tiles[ix] = TTile(ch, fg, bg);
	}

	void TTileSeq::Set(std::vector<TTile>& tiles)
	{
		Tiles = tiles;
	}

	void TTileSeq::SetChar(int ix, CharsetIndex ch)
	{
		Tiles[ix].Char = ch;
	}

	void TTileSeq::SetForeColor(int ix, PaletteIndex fg)
	{
		Tiles[ix].ForeColor = fg;
	}

	void TTileSeq::SetBackColor(int ix, PaletteIndex bg)
	{
		Tiles[ix].BackColor = bg;
	}
	
	TTile& TTileSeq::Get(int ix)
	{
		return Tiles[ix];
	}

	TTile& TTileSeq::First()
	{
		return Tiles[0];
	}

	CharsetIndex TTileSeq::GetChar(int ix)
	{
		return Tiles[ix].Char;
	}

	PaletteIndex TTileSeq::GetForeColor(int ix)
	{
		return Tiles[ix].ForeColor;
	}

	PaletteIndex TTileSeq::GetBackColor(int ix)
	{
		return Tiles[ix].BackColor;
	}
}
