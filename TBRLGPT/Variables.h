/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2019 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <map>
#include <string>
#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API Variables
	{
	public:
		Variables();
		~Variables();

		void Clear();
		void SetStr(std::string var, std::string str);
		void SetInt(std::string var, int val);
		std::string GetStr(std::string var);
		int GetInt(std::string var);
		bool Contains(std::string var);
		bool IsEmpty();

	private:
		std::map<std::string, std::string> Vars;
	};
}
