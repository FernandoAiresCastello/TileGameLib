/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once

#include <string>
#include <vector>
#include "TGLGlobal.h"
#include "TGLClass.h"
#include "TGLColor.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TGLPalette : TGLClass
	{
	public:
		TGLPalette();
		TGLPalette(const TGLPalette& other);
		~TGLPalette();

		std::vector<TGLColor>& GetColors();
		TGLColor& Get(TGLPaletteIndex ix);
		TGLColorRGB GetColorRGB(TGLPaletteIndex ix);
		int GetSize();
		void Clear();
		void DeleteAll();
		void AddBlank(int count = 1);
		void Add(TGLColor color);
		void Add(int r, int g, int b);
		void Add(TGLColorRGB rgb);
		void Set(TGLPaletteIndex ix, TGLColorRGB rgb);
		void Set(TGLPaletteIndex ix, int r, int g, int b);
		void SetEqual(TGLPalette& other);
		void InitDefault();

	private:
		std::vector<TGLColor> Colors;
	};
}
