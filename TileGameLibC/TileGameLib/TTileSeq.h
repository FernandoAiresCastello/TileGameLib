/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <vector>
#include <string>
#include <CppUtils.h>
#include "TGlobal.h"
#include "TTile.h"

using namespace CppUtils;

namespace TileGameLib
{
	class TTileSeq
	{
	public:
		CppProperties Prop;

		TTileSeq();
		TTileSeq(const TTileSeq& other);
		TTileSeq(TTile tile);
		TTileSeq(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg);
		TTileSeq(std::vector<TTile>& tiles);
		TTileSeq(std::string tileString);

		TTileSeq& operator=(const TTileSeq& other);
		bool operator==(const TTileSeq& other);
		bool operator!=(const TTileSeq& other);

		bool IsEmpty();
		int GetSize();
		bool HasIndex(int ix);
		void Clear();
		void Add(TTile tile);
		void Add(TTile tile, int count);
		void Add(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg);
		void Add(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg, int count);
		void Add(std::vector<TTile>& tiles);
		void AddBlank(int count = 1);
		void Pop();
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
		bool Parse(std::string tileString);
		std::string ToString();

	private:
		std::vector<TTile> Tiles;
	};
}
