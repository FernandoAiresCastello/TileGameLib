/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#include "TSpriteList.h"

namespace TileGameLib
{
	void TSpriteList::Add(TSprite sprite)
	{
		Sprites.push_back(sprite);
	}
	
	std::vector<TSprite>& TSpriteList::GetAll()
	{
		return Sprites;
	}

	void TSpriteList::Delete(std::string id)
	{
		for (int i = 0; i < Sprites.size(); i++)
		{
			TSprite& sprite = Sprites[i];
			
			if (sprite.Id == id)
			{
				Sprites.erase(Sprites.begin() + i);
				return;
			}
		}
	}

	void TSpriteList::DeleteAll()
	{
		Sprites.clear();
	}

	TSprite* TSpriteList::Get(int index)
	{
		return &Sprites[index];
	}
	
	TSprite* TSpriteList::Find(std::string id)
	{
		for (auto& sprite : Sprites)
		{
			if (sprite.Id == id)
				return &sprite;
		}

		return nullptr;
	}
}
