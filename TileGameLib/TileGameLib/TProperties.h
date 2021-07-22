/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <map>
#include <string>
#include "TGlobal.h"
#include "TClass.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TProperties : TClass
	{
	public:
		TProperties();
		TProperties(const TProperties& other);
		~TProperties();

		void Clear();
		int GetCount();
		void Set(std::string prop, std::string value);
		void Set(std::string prop, int value);
		std::string GetAsString(std::string prop);
		int GetAsNumber(std::string prop);
		bool Has(std::string prop);
		bool Has(std::string prop, std::string value);
		bool Has(std::string prop, int value);
		void SetEqual(TProperties& other);

	private:
		struct TPropertyValue {
			std::string String;
			int Number;
		};
		std::map<std::string, TPropertyValue> Properties;
	};
}
