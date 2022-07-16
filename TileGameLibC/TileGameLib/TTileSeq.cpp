/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include <CppUtils.h>
#include "TTileSeq.h"
using namespace CppUtils;

namespace TileGameLib
{
	TTileSeq::TTileSeq()
	{
	}

	TTileSeq::TTileSeq(const TTileSeq& other)
	{
		*this = other;
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

	TTileSeq::TTileSeq(std::string tileString)
	{
		Parse(tileString);
	}

	TTileSeq& TTileSeq::operator=(const TTileSeq& other)
	{
		Ext = nullptr;

		Tiles.clear();
		for (auto& tile : other.Tiles)
			Add(tile);

		return *this;
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

	bool TTileSeq::IsEmpty()
	{
		return Tiles.empty();
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

	void TTileSeq::Add(TTile tile, int count)
	{
		for (int i = 0; i < count; i++)
			Add(tile);
	}

	void TTileSeq::Add(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg)
	{
		Tiles.push_back(TTile(ch, fg, bg));
	}

	void TTileSeq::Add(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg, int count)
	{
		for (int i = 0; i < count; i++)
			Add(ch, fg, bg);
	}

	void TTileSeq::Add(std::vector<TTile>& tiles)
	{
		for (auto& tile : tiles)
			Tiles.push_back(tile);
	}

	void TTileSeq::Pop()
	{
		if (!Tiles.empty())
			Tiles.pop_back();
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

	void TTileSeq::Parse(std::string tileString)
	{
		Clear();
		for (auto& ts : String::Split(tileString, ';', true)) {
			auto t = String::Split(ts, ',', true);
			Add(String::ToInt(t[0]), String::ToInt(t[1]), String::ToInt(t[2]));
		}
	}

	std::string TTileSeq::ToString()
	{
		std::string tileString;
		for (int i = 0; i < Tiles.size(); i++) {
			auto& tile = Tiles[i];
			tileString += String::Format("%i,%i,%i", tile.Char, tile.ForeColor, tile.BackColor);
			if (i < Tiles.size() - 1)
				tileString += ";";
		}
		return tileString;
	}
}
