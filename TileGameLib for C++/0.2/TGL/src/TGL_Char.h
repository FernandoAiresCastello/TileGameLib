#pragma once
#include "TGL_Global.h"
#include "TGL_Index.h"

namespace TGL
{
	class TGLAPI Char
	{
	public:
		Index charIndex;
		Index foreColor;
		Index backColor;

		Char();
		Char(const Char& other);
		Char(Index ch, Index foreColor, Index backColor);

		bool operator==(const Char& other) const;
		Char& operator=(const Char& other);

		void Set(Index ch, Index foreColor, Index backColor);
	};
}
