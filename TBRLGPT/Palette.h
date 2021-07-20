/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include <vector>
#include "Global.h"
#include "Color.h"

namespace TBRLGPT
{
	class TBRLGPT_API Palette
	{
	public:
		Palette();
		~Palette();

		Color& Get(int index);
		int GetRGB(int index);
		int GetSize();
		void Clear();
		void Clear(int size);
		void Add(int r, int g, int b);
		void Add(int rgb);
		void Set(int index, int rgb);
		void Set(int index, int r, int g, int b);
		void InitDefaultColors();

	private:
		std::vector<Color> Colors;
	};
}
