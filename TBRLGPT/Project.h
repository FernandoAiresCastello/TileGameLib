/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include <vector>
#include "Global.h"

namespace TBRLGPT
{
	class Map;
	class Palette;
	class Charset;

	class TBRLGPT_API Project
	{
	public:
		Project();
		~Project();

		bool Load(std::string filename);
		std::vector<Map*>& GetMaps();
		Map* FindMapById(std::string id);
		Map* FindMapByName(std::string name);
		class Palette* GetPalette();
		class Charset* GetCharset();

	private:
		std::string Path;
		std::string Name;
		std::string CreationDate;
		class Palette* Palette;
		class Charset* Charset;
		std::vector<Map*> Maps;

		void DeleteContents();
	};
}
