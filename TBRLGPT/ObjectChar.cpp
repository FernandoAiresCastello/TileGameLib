/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "ObjectChar.h"

namespace TBRLGPT
{
	const int ObjectChar::NullIndex = 0;
	const int ObjectChar::NullForeColorIx = 1;
	const int ObjectChar::NullBackColorIx = 0;

	ObjectChar::ObjectChar()
	{
		SetNull();
	}

	ObjectChar::ObjectChar(ushort ix, byte fgc, byte bgc)
	{
		Index = ix;
		ForeColorIx = fgc;
		BackColorIx = bgc;
	}

	ObjectChar::ObjectChar(const ObjectChar & other) :
		ObjectChar(other.Index, other.ForeColorIx, other.BackColorIx)
	{
	}

	void ObjectChar::SetNull()
	{
		Index = NullIndex;
		ForeColorIx = NullForeColorIx;
		BackColorIx = NullBackColorIx;
	}

	bool ObjectChar::IsNull()
	{
		return
			Index == NullIndex &&
			ForeColorIx == NullForeColorIx &&
			BackColorIx == NullBackColorIx;
	}

	bool ObjectChar::Equals(ObjectChar & other)
	{
		return
			Index == other.Index &&
			ForeColorIx == other.ForeColorIx &&
			BackColorIx == other.BackColorIx;
	}

	void ObjectChar::InvertColors()
	{
		int origForeColorIx = ForeColorIx;
		ForeColorIx = BackColorIx;
		BackColorIx = origForeColorIx;
	}
}
