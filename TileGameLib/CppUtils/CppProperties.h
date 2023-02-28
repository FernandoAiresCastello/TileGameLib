/*=============================================================================

	 C++ Utils
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <map>
#include <string>
#include "CppGlobal.h"

namespace CppUtils
{
	class CppProperties
	{
	public:
		std::map<std::string, std::string> Entries;

		CppProperties& operator=(const CppProperties& other);
		bool operator==(const CppProperties& other);
		bool operator!=(const CppProperties& other);

		void Set(std::string name);
		void Set(std::string name, std::string value);
		void Set(std::string name, int value);
		bool Has(std::string name);
		bool Has(std::string name, std::string value);
		bool Has(std::string name, int value);
		std::string GetString(std::string name);
		int GetNumber(std::string name);
		void Delete(std::string name);
		void DeleteAll();
	};
}
