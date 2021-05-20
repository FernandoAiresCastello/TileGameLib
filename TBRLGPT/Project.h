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

		void AddMap(Map* map);
		bool Load(std::string filename);
		std::vector<Map*>& GetMaps();
		Map* FindMapById(std::string id);
		Map* FindMapByName(std::string name);
		class Palette* GetPalette();
		class Charset* GetCharset();
		void SetPalette(class Palette* palette);
		void SetCharset(class Charset* charset);

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
