/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include <CppUtils.h>
#include "TGBTile.h"

using namespace CppUtils;

namespace TileGameLib
{
	TGBTile::TGBTile()
	{
		Clear();
	}

	TGBTile::TGBTile(const TGBTile& other)
	{
		for (int i = 0; i < Length; i++) {
			Data[i] = other.Data[i];
		}
	}

	TGBTile::TGBTile(std::string data)
	{
		Parse(data);
	}

	void TGBTile::Clear()
	{
		for (int i = 0; i < Length; i++)
		{
			Data[i] = TGBTileColor::Color0;
		}
	}

	void TGBTile::Parse(std::string data)
	{
		Clear();
		for (int i = 0; i < data.length(); i++)
		{
			if (i >= Length) break;
			
			switch (data[i])
			{
				case '0': Data[i] = TGBTileColor::Color0; break;
				case '1': Data[i] = TGBTileColor::Color1; break;
				case '2': Data[i] = TGBTileColor::Color2; break;
				case '3': Data[i] = TGBTileColor::Color3; break;

				default:  Data[i] = TGBTileColor::Color0; break;
			}
		}
	}
}
