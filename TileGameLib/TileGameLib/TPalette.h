/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <string>
#include <vector>
#include "TGlobal.h"
#include "TColor.h"

namespace TileGameLib
{
	class TPalette
	{
	public:
		static TPalette* Default;

		TPalette();
		TPalette(const TPalette& other);
		~TPalette();

		std::vector<TColor>& GetColors();
		TColor& Get(int ix);
		int GetColorRGB(int ix);
		int GetSize();
		void Clear();
		void DeleteAll();
		void AddBlank(int count = 1);
		void Add(TColor color);
		void Add(int r, int g, int b);
		void Add(int rgb);
		void Set(int ix, int rgb);
		void Set(int ix, int r, int g, int b);
		void SetEqual(TPalette& other);
		void Load(std::string filename);
		void Save(std::string filename);
		void LoadFromImage(std::string filename, int wSwatch, int hSwatch);
		void InitDefault();

	private:
		std::vector<TColor> Colors;
	};
}
