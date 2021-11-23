/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <string>
#include <vector>
#include "TGlobal.h"
#include "TClass.h"
#include "TColor.h"

namespace TileGameLib
{
	class TPalette : TClass
	{
	public:
		static TPalette* Default;

		TPalette();
		TPalette(const TPalette& other);
		~TPalette();

		std::vector<TColor>& GetColors();
		TColor& Get(TPaletteIndex ix);
		TColorRGB GetColorRGB(TPaletteIndex ix);
		int GetSize();
		void Clear();
		void DeleteAll();
		void AddBlank(int count = 1);
		void Add(TColor color);
		void Add(int r, int g, int b);
		void Add(TColorRGB rgb);
		void Set(TPaletteIndex ix, TColorRGB rgb);
		void Set(TPaletteIndex ix, int r, int g, int b);
		void SetEqual(TPalette& other);
		void Load(std::string filename);
		void Save(std::string filename);
		void InitDefault();

	private:
		std::vector<TColor> Colors;
	};
}
