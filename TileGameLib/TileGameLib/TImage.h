/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <vector>
#include <string>
#include "TColor.h"

namespace TileGameLib
{
	class TImage
	{
	public:
		TImage();
		~TImage();

		void Load(std::string filename);
		int GetWidth();
		int GetHeight();
		TColor GetPixel(int i);
		TColor GetPixel(int x, int y);

	private:
		int Width;
		int Height;
		std::vector<TColor> Pixels;
	};
}
