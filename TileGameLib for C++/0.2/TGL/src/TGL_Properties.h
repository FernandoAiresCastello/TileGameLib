#pragma once
#include "TGL_Global.h"
#include "TGL_Dict.h"
#include "TGL_String.h"

namespace TGL
{
	class TGLAPI Properties
	{
	public:
		Properties();
		~Properties();

		void Set(const String& name, const String& value);
		void Set(const String& name, int value);
		String Get(const String& name);
		int GetInt(const String& name);
		bool Has(const String& name);
		bool Has(const String& name, const String& value);
		bool Has(const String& name, int value);
		void Remove(const String& name);
		bool Empty() const;
		void Clear();
		int Size() const;
		Dict<String, String>& GetAll();

	private:
		Dict<String, String> prop;
	};
}
