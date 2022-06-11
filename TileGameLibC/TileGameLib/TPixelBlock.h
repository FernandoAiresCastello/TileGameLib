/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <vector>
#include "TGlobal.h"

namespace TileGameLib
{
	class TPixelBlock
	{
	public:
		TPixelBlock();
		TPixelBlock(const TPixelBlock& other);

		bool operator==(const TPixelBlock& other);
		bool operator!=(const TPixelBlock& other);

		void SetSize(int width, int height);
		int GetWidth();
		int GetHeight();
		void SetColors(std::vector<RGB> colors);
		std::vector<RGB>& GetColors();
		RGB GetColor(int index);
		RGB GetColor(int x, int y);
		void SetColor(int index, RGB rgb);
		void SetColor(int x, int y, RGB rgb);

	private:
		int Width;
		int Height;
		std::vector<RGB> Colors;
	};
}
