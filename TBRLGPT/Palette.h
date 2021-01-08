/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include "Global.h"
#include "Color.h"

namespace TBRLGPT
{
	class TBRLGPT_API Palette
	{
	public:
		static const int Size;

		Palette();
		~Palette();

		Color* Get(int index);
		void Set(int index, int rgb);
		void Set(int index, int r, int g, int b);
		void Clear();
		void Save(std::string filename);
		void Load(std::string filename);
		void InitDefaultColors();

	private:
		Color* Colors;
	};
}
