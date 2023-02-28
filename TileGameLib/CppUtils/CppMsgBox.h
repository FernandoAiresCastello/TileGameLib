/*=============================================================================

	 C++ Utils
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <string>
#include <vector>
#include "CppGlobal.h"

namespace CppUtils
{
	class MsgBox
	{
	public:
		static void Info(std::string message);
		static void Info(std::string title, std::string message);
		static void Warning(std::string message);
		static void Warning(std::string title, std::string message);
		static void Error(std::string message);
		static void Error(std::string title, std::string message);
	};
}
