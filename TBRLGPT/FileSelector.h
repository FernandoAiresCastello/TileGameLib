/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include <vector>
#include "Global.h"
#include "FilePath.h"

namespace TBRLGPT
{
	class UIContext;

	class TBRLGPT_API FileSelector
	{
	public:
		FileSelector(UIContext* ctx);
		~FileSelector();

		std::string Select(std::string title, std::string initialPath = "", std::string extension = "");

	private:
		UIContext* Ctx;
		std::string Title;
		FilePath Path;
		int KeyPressed;

		void PrintInfo();
		std::string ShowFileMenu(std::string extension);

		void CreateNewFile();
		void DeleteFile(std::string file);
		void DuplicateFile(std::string file);
	};
}
