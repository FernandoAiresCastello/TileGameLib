/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TProperties.h"
#include <CppUtils.h>

using namespace CppUtils;

namespace TileGameLib
{
	TProperties::TProperties()
	{
	}
	
	TProperties::TProperties(const TProperties& other)
	{
		Clear();
		for (auto& it : Properties)
			Properties[it.first] = it.second;
	}

	TProperties::~TProperties()
	{
	}

	void TProperties::Clear()
	{
		Properties.clear();
	}

	int TProperties::GetCount()
	{
		return Properties.size();
	}

	void TProperties::Set(std::string prop, std::string value)
	{
		Properties[prop] = { value, String::ToInt(value) };
	}

	void TProperties::Set(std::string prop, int value)
	{
		Properties[prop] = { String::ToString(value), value };
	}

	std::string TProperties::GetAsString(std::string prop)
	{
		if (Has(prop))
			return Properties[prop].String;

		return "";
	}

	int TProperties::GetAsNumber(std::string prop)
	{
		if (Has(prop))
			return Properties[prop].Number;

		return 0;
	}

	bool TProperties::Has(std::string prop)
	{
		return Properties.find(prop) != Properties.end();
	}

	bool TProperties::Has(std::string prop, std::string value)
	{
		if (!Has(prop))
			return false;

		return GetAsString(prop) == value;
	}

	bool TProperties::Has(std::string prop, int value)
	{
		if (!Has(prop))
			return false;

		return GetAsNumber(prop) == value;
	}

	void TProperties::SetEqual(TProperties& other)
	{
		Clear();
		for (auto& it : Properties)
			Properties[it.first] = it.second;
	}
}
