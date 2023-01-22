/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <string>
#include <vector>
#include "TSprite.h"

namespace TileGameLib
{
	class TSpriteList
	{
	public:
		void Add(TSprite sprite);
		std::vector<TSprite>& GetAll();
		void Delete(std::string id);
		void DeleteAll();
		TSprite* Get(int index);
		TSprite* Find(std::string id);

	private:
		std::vector<TSprite> Sprites;
	};
}
