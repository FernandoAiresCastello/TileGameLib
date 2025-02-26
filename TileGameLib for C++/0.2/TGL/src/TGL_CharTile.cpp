#include "TGL_CharTile.h"
#include "TGL_Graphics.h"
#include "TGL_Charset.h"
#include "TGL_Palette.h"

namespace TGL
{
	CharTile::CharTile() :
		data(), chars(), anim(), transparent(false)
	{
	}

	CharTile::CharTile(const CharTile& other) : 
		data(other.data), chars(other.chars), anim(other.anim), transparent(false)
	{
	}

	CharTile::CharTile(const Char& singleFrame) :
		data(), chars(), anim(), transparent(false)
	{
		chars.push_back(singleFrame);
	}

	CharTile::~CharTile()
	{
		chars.clear();
	}

	CharTile& CharTile::operator=(const CharTile& other)
	{
		if (this == &other)
			return *this;

		data = other.data;
		chars = other.chars;
		transparent = other.transparent;
		anim = other.anim;

		return *this;
	}

	int CharTile::CharCount() const
	{
		return chars.size();
	}

	Char& CharTile::GetChar(int index)
	{
		return chars[index % chars.size()];
	}

	Char CharTile::CopyChar(int index) const
	{
		return chars[index % chars.size()];
	}

	Char& CharTile::NextChar()
	{
		Char& ch = chars[anim.currentFrame % chars.size()];

		if (anim.enabled) {
			anim.frameCounter++;
			if (anim.frameCounter > anim.maxFrameCounter) {
				anim.frameCounter = 0;
				anim.currentFrame++;
			}
		}

		return ch;
	}

	void CharTile::AddChar(const Char& ch)
	{
		chars.push_back(ch);
	}

	void CharTile::AddChar(Index ch, Index foreColor, Index backColor)
	{
		chars.emplace_back(ch, foreColor, backColor);
	}

	void CharTile::SetChar(int index, const Char& ch)
	{
		chars[index] = ch;
	}

	void CharTile::SetChar(int index, Index ch, Index foreColor, Index backColor)
	{
		chars[index].Set(ch, foreColor, backColor);
	}

	void CharTile::RemoveAllChars()
	{
		chars.clear();
	}

	void CharTile::SetEmpty()
	{
		data.Clear();
		RemoveAllChars();
		transparent = false;
	}

	bool CharTile::IsEmpty() const
	{
		return HasNoData() && HasNoChars();
	}

	bool CharTile::HasAnyChar() const
	{
		return !chars.empty();
	}

	bool CharTile::HasNoChars() const
	{
		return !HasAnyChar();
	}

	bool CharTile::HasAnyData() const
	{
		return !data.Empty();
	}

	bool CharTile::HasNoData() const
	{
		return !HasAnyData();
	}

	void CharTile::SetCurrentAnimFrame(int index)
	{
		anim.currentFrame = index;
	}

	void CharTile::SetAnimationDelay(int delay)
	{
		anim.maxFrameCounter = delay;
	}

	void CharTile::EnableAnimation(bool enable)
	{
		anim.enabled = enable;
	}

	void CharTile::Draw(Graphics* g, Charset* charset, Palette* palette, const Point& pos)
	{
		Char& curFrame = NextChar();

		g->DrawBitPattern(charset->Get(curFrame.charIndex), pos, 
			palette->Get(curFrame.foreColor), palette->Get(curFrame.backColor), 
			false, transparent);
	}

	void CharTile::Draw(Graphics* g, Charset* charset, Palette* palette, int x, int y)
	{
		Draw(g, charset, palette, Point(x, y));
	}
}
