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
	class TBRLGPT_API FilePath
	{
	public:
		FilePath();
		~FilePath();

		bool IsEmpty();
		std::string GetPath();
		std::string GetFullPath(std::string file);
		std::string GetCurrentDirectory();
		void SetPath(std::string path);
		void EnterDirectory(std::string dir);
		void ExitDirectory();

	private:
		std::vector<std::string> Path;
	};
}
