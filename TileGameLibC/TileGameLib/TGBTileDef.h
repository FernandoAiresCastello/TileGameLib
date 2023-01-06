/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include "TGlobal.h"

namespace TileGameLib
{
	enum class TGBTileColor { Color0, Color1, Color2, Color3 };

	class TGBTileDef
	{
	public:
		static const int Width = 8;
		static const int Height = 8;
		static const int Length = Width * Height;

		TGBTileColor Data[Length] = { TGBTileColor::Color0 };
		
		TGBTileDef();
		TGBTileDef(const TGBTileDef& other);
		TGBTileDef(std::string data);

		void Clear();
		void Parse(std::string data);
	};
}
