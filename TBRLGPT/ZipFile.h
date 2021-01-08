/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include <vector>
#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API ZipFile
	{
	public:
		ZipFile();
		~ZipFile();

		void Add(std::string file);
		void Save(std::string zipfile);
		char* Load(std::string zipfile, std::string filename, int* size);

	private:
		std::vector<std::string> Files;
	};
}
