#include "TGL_Char.h"

namespace TGL
{
	Char::Char() : 
		charIndex(0), foreColor(0), backColor(0)
	{
	}

	Char::Char(const Char& other) : 
		charIndex(other.charIndex), foreColor(other.foreColor), backColor(other.backColor)
	{
	}

	Char::Char(Index ch, Index foreColor, Index backColor) :
		charIndex(ch), foreColor(foreColor), backColor(backColor)
	{
	}

	bool Char::operator==(const Char& other) const
	{
		return
			charIndex == other.charIndex &&
			foreColor == other.foreColor &&
			backColor == other.backColor;
	}

	Char& Char::operator=(const Char& other)
	{
		if (this == &other)
			return *this;

		charIndex = other.charIndex;
		foreColor = other.foreColor;
		backColor = other.backColor;

		return *this;
	}

	void Char::Set(Index ch, Index foreColor, Index backColor)
	{
		this->charIndex = ch;
		this->foreColor = foreColor;
		this->backColor = backColor;
	}
}
