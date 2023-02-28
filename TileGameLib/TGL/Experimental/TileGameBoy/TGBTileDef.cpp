#include <CppUtils.h>
#include "TGBTileDef.h"

using namespace CppUtils;

namespace TGL_Internal
{
	TGBTileDef::TGBTileDef()
	{
		Clear();
	}

	TGBTileDef::TGBTileDef(const TGBTileDef& other)
	{
		for (int i = 0; i < Length; i++) {
			Data[i] = other.Data[i];
		}
	}

	TGBTileDef::TGBTileDef(std::string data)
	{
		Parse(data);
	}

	void TGBTileDef::Clear()
	{
		for (int i = 0; i < Length; i++)
		{
			Data[i] = TGBTileColor::Color0;
		}
	}

	void TGBTileDef::Parse(std::string data)
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
