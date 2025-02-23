#include "TGL_CharTileFrame.h"

namespace TGL
{
	CharTileFrame::CharTileFrame() : 
		Char(0), ForeColor(0), BackColor(0)
	{
	}

	CharTileFrame::CharTileFrame(const CharTileFrame& other) : 
		Char(other.Char), ForeColor(other.ForeColor), BackColor(other.BackColor)
	{
	}

	CharTileFrame::CharTileFrame(Index ch, Index foreColor, Index backColor) :
		Char(ch), ForeColor(foreColor), BackColor(backColor)
	{
	}

	bool CharTileFrame::operator==(const CharTileFrame& other) const
	{
		return
			Char == other.Char &&
			ForeColor == other.ForeColor &&
			BackColor == other.BackColor;
	}

	CharTileFrame& CharTileFrame::operator=(const CharTileFrame& other)
	{
		if (this == &other)
			return *this;

		Char = other.Char;
		ForeColor = other.ForeColor;
		BackColor = other.BackColor;

		return *this;
	}

	void CharTileFrame::Set(Index ch, Index foreColor, Index backColor)
	{
		Char = ch;
		ForeColor = foreColor;
		BackColor = backColor;
	}
}
