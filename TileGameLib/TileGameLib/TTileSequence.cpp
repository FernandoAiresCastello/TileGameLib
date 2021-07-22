/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TTileSequence.h"

namespace TileGameLib
{
	TTileSequence::TTileSequence()
	{
	}

	TTileSequence::TTileSequence(TTile tile)
	{
		Add(tile);
	}

	TTileSequence::TTileSequence(std::vector<TTile>& tiles)
	{
		for (auto& tile : tiles)
			Add(tile);
	}
	
	TTileSequence::TTileSequence(const TTileSequence& other)
	{
		Tiles.clear();
		for (auto& tile : other.Tiles)
			Add(tile);
	}

	TTileSequence::~TTileSequence()
	{
	}

	std::vector<TTile>& TTileSequence::GetTiles()
	{
		return Tiles;
	}

	TTile* TTileSequence::Get(int ix)
	{
		if (!IsEmpty())
			return &(Tiles[ix % Tiles.size()]);

		return nullptr;
	}

	void TTileSequence::Set(int ix, TTile tile)
	{
		Tiles[ix] = tile;
	}

	void TTileSequence::Add(TTile tile)
	{
		Tiles.push_back(tile);
	}

	void TTileSequence::AddBlank(int count)
	{
		for (int i = 0; i < count; i++)
			Add(TTile());
	}

	int TTileSequence::GetSize()
	{
		return Tiles.size();
	}

	bool TTileSequence::IsEmpty()
	{
		return GetSize() == 0;
	}

	void TTileSequence::Clear()
	{
		for (int i = 0; i < Tiles.size(); i++)
			Set(i, TTile());
	}

	void TTileSequence::DeleteAll()
	{
		Tiles.clear();
	}

	void TTileSequence::SetEqual(TTileSequence& other)
	{
		Tiles.clear();
		for (auto& tile : other.Tiles)
			Add(tile);
	}
}
