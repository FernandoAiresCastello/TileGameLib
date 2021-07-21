/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <vector>
#include "TGLGlobal.h"
#include "TGLClass.h"
#include "TGLTile.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TGLTileSequence : TGLClass
	{
	public:
		TGLTileSequence();
		TGLTileSequence(const TGLTileSequence& other);
		~TGLTileSequence();

		std::vector<TGLTile>& GetTiles();
		TGLTile& Get(int ix);
		void Set(int ix, TGLTile tile);
		void Add(TGLTile tile);
		void AddBlank(int count = 1);
		int GetSize();
		void Clear();
		void DeleteAll();
		void SetEqual(TGLTileSequence& other);

	private:
		std::vector<TGLTile> Tiles;
	};
}
