/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "MapList.h"
#include "Map.h"

namespace TBRLGPT
{
	MapList::MapList()
	{
		Maps = new std::vector<Map*>();
	}

	MapList::~MapList()
	{
		DeleteAll();
		delete Maps;
	}

	void MapList::AddMap(Map* map)
	{
		Maps->push_back(map);
	}

	Map* MapList::GetMap(std::string name)
	{
		for (unsigned i = 0; i < Maps->size(); i++) {
			Map* map = (*Maps)[i];
			if (map->GetName() == name)
				return map;
		}

		return NULL;
	}

	Map* MapList::GetMap(int index)
	{
		if (index >= 0 && index < (int)Maps->size())
			return (*Maps)[index];

		return NULL;
	}

	int MapList::GetMapIndex(std::string name)
	{
		for (unsigned i = 0; i < Maps->size(); i++) {
			Map* map = (*Maps)[i];
			if (map->GetName() == name)
				return i;
		}

		return -1;
	}

	std::vector<Map*>* MapList::GetMaps()
	{
		return Maps;
	}

	void MapList::DeleteAll()
	{
		for (unsigned i = 0; i < Maps->size(); i++)
			delete (*Maps)[i];

		Maps->clear();
	}

	void MapList::Delete(std::string name)
	{
		Delete(GetMapIndex(name));
	}

	void MapList::Delete(int index)
	{
		if (index >= 0 && index < (int)Maps->size()) {
			delete (*Maps)[index];
			Maps->erase(Maps->begin() + index);
		}
	}
}
