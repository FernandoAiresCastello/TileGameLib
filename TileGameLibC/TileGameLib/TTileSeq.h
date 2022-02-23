/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <vector>
#include "TGlobal.h"
#include "TTile.h"

namespace TileGameLib
{
	class TTileSeq
	{
	public:
		TTileSeq();
		TTileSeq(const TTileSeq& other);
		TTileSeq(TTile tile);
		TTileSeq(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg);
		TTileSeq(std::vector<TTile>& tiles);

		bool operator==(const TTileSeq& other);
		bool operator!=(const TTileSeq& other);

		bool IsEmpty();
		int GetSize();
		bool HasIndex(int ix);
		void Clear();
		void Add(TTile tile);
		void Add(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg);
		void Add(std::vector<TTile>& tiles);
		void Set(int ix, TTile tile);
		void Set(int ix, CharsetIndex ch, PaletteIndex fg, PaletteIndex bg);
		void Set(std::vector<TTile>& tiles);
		void SetChar(int ix, CharsetIndex ch);
		void SetForeColor(int ix, PaletteIndex fg);
		void SetBackColor(int ix, PaletteIndex bg);
		TTile& Get(int ix);
		TTile& First();
		CharsetIndex GetChar(int ix);
		PaletteIndex GetForeColor(int ix);
		PaletteIndex GetBackColor(int ix);

	private:
		std::vector<TTile> Tiles;
	};
}
