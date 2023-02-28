#pragma once
#include <string>
#include <vector>
#include "TSprite.h"

namespace TGL_Internal
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
