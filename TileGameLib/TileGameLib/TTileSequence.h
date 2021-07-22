/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <vector>
#include "TGlobal.h"
#include "TClass.h"
#include "TTile.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TTileSequence : TClass
	{
	public:
		TTileSequence();
		TTileSequence(TTile tile);
		TTileSequence(std::vector<TTile>& tiles);
		TTileSequence(const TTileSequence& other);
		~TTileSequence();

		std::vector<TTile>& GetTiles();
		TTile& Get(int ix);
		void Set(int ix, TTile tile);
		void Add(TTile tile);
		void AddBlank(int count = 1);
		int GetSize();
		bool IsEmpty();
		void Clear();
		void DeleteAll();
		void SetEqual(TTileSequence& other);

	private:
		std::vector<TTile> Tiles;
	};
}
