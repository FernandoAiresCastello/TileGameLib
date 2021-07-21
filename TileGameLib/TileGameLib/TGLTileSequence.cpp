/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TGLTileSequence.h"

namespace TileGameLib
{
	TGLTileSequence::TGLTileSequence()
	{
	}
	
	TGLTileSequence::TGLTileSequence(const TGLTileSequence& other)
	{
		Tiles.clear();
		for (auto& tile : other.Tiles)
			Add(tile);
	}

	TGLTileSequence::~TGLTileSequence()
	{
	}

	std::vector<TGLTile>& TGLTileSequence::GetTiles()
	{
		return Tiles;
	}

	TGLTile& TGLTileSequence::Get(int ix)
	{
		return Tiles[ix];
	}

	void TGLTileSequence::Set(int ix, TGLTile tile)
	{
		Tiles[ix] = tile;
	}

	void TGLTileSequence::Add(TGLTile tile)
	{
		Tiles.push_back(tile);
	}

	void TGLTileSequence::AddBlank(int count)
	{
		for (int i = 0; i < count; i++)
			Add(TGLTile());
	}

	int TGLTileSequence::GetSize()
	{
		return Tiles.size();
	}

	void TGLTileSequence::Clear()
	{
		for (int i = 0; i < Tiles.size(); i++)
			Set(i, TGLTile());
	}

	void TGLTileSequence::DeleteAll()
	{
		Tiles.clear();
	}

	void TGLTileSequence::SetEqual(TGLTileSequence& other)
	{
		Tiles.clear();
		for (auto& tile : other.Tiles)
			Add(tile);
	}
}
