/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include <vector>
#include "TGlobal.h"

namespace TileGameLib
{
	class TPixelBlock
	{
	public:
		static const int Transparent = -1;
		const int Width;
		const int Height;
		const int Size;
		std::vector<int> Colors;

		TPixelBlock(int w, int h);
		TPixelBlock(int w, int h, std::vector<int>& colors);
		~TPixelBlock();

		void SetPixel(int x, int y, int color);
		int GetPixel(int x, int y);
		void Fill(int color);
	};
}
