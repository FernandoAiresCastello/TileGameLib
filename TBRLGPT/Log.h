/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include <cstdio>
#include <exception>
#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API Log
	{
	public:
		Log(std::string filename);
		~Log();

		void SetTimestamp(bool timestamp);
		void Print(const char* fmt, ...);
		void Print(std::string msg);
		void Print(std::exception ex);

	private:
		FILE* File;
		bool Timestamp;
	};
}
