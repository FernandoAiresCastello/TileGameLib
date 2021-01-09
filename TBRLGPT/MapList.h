/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <vector>
#include "Global.h"

namespace TBRLGPT
{
	class Map;

	class TBRLGPT_API MapList
	{
	public:
		MapList();
		~MapList();

		void AddMap(Map* map);
		Map* GetMap(std::string name);
		Map* GetMap(int index);
		int GetMapIndex(std::string name);
		std::vector<Map*>* GetMaps();
		void DeleteAll();
		void Delete(std::string name);
		void Delete(int index);

	private:
		std::vector<Map*>* Maps;
	};
}
