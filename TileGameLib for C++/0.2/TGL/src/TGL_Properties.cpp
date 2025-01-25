#include "TGL_Properties.h"

namespace TGL
{
	Properties::Properties()
	{
	}

	Properties::~Properties()
	{
	}

	void Properties::Set(const String& name, const String& value)
	{
		prop[name] = value;
	}

	void Properties::Set(const String& name, int value)
	{
		prop[name] = value;
	}

	String Properties::Get(const String& name)
	{
		if (Has(name))
			return prop[name];

		return "";
	}

	int Properties::GetInt(const String& name)
	{
		if (Has(name))
			return prop[name].ToInt();

		return 0;
	}

	bool Properties::Has(const String& name)
	{
		return prop.contains(name);
	}

	bool Properties::Has(const String& name, const String& value)
	{
		return Has(name) && Get(name) == value;
	}

	bool Properties::Has(const String& name, int value)
	{
		return Has(name) && GetInt(name) == value;
	}

	void Properties::Remove(const String& name)
	{
		if (Has(name))
			prop.erase(name);
	}

	bool Properties::Empty() const
	{
		return prop.empty();
	}

	void Properties::Clear()
	{
		prop.clear();
	}

	int Properties::Size() const
	{
		return prop.size();
	}

	Dict<String, String>& Properties::GetAll()
	{
		return prop;
	}
}
