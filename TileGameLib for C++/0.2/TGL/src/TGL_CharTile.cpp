#include "TGL_CharTile.h"
#include "TGL_Graphics.h"
#include "TGL_Charset.h"
#include "TGL_Palette.h"

namespace TGL
{
	CharTile::CharTile() :
		Data(), Chars(), Transparent(false)
	{
	}

	CharTile::CharTile(const CharTile& other) : 
		Data(other.Data), Chars(other.Chars), Transparent(false)
	{
	}

	CharTile::CharTile(const CharTileFrame& singleFrame) :
		Data(), Chars(), Transparent(false)
	{
		Chars.push_back(singleFrame);
	}

	CharTile::~CharTile()
	{
		Chars.clear();
	}

	CharTile& CharTile::operator=(const CharTile& other)
	{
		if (this == &other)
			return *this;

		Data = other.Data;
		Chars = other.Chars;
		Transparent = other.Transparent;

		return *this;
	}

	int CharTile::CharCount() const
	{
		return Chars.size();
	}

	CharTileFrame& CharTile::GetChar(int index)
	{
		return Chars[index % Chars.size()];
	}

	CharTileFrame CharTile::CopyChar(int index) const
	{
		return Chars[index % Chars.size()];
	}

	CharTileFrame& CharTile::NextChar()
	{
		CharTileFrame& ch = Chars[Anim.CurrentFrame % Chars.size()];

		if (Anim.Enabled) {
			Anim.FrameCounter++;
			if (Anim.FrameCounter > Anim.MaxFrameCounter) {
				Anim.FrameCounter = 0;
				Anim.CurrentFrame++;
			}
		}

		return ch;
	}

	void CharTile::AddChar(const CharTileFrame& ch)
	{
		Chars.push_back(ch);
	}

	void CharTile::AddChar(Index ch, Index foreColor, Index backColor)
	{
		Chars.emplace_back(ch, foreColor, backColor);
	}

	void CharTile::SetChar(int index, const CharTileFrame& ch)
	{
		Chars[index] = ch;
	}

	void CharTile::SetChar(int index, Index ch, Index foreColor, Index backColor)
	{
		Chars[index].Set(ch, foreColor, backColor);
	}

	void CharTile::RemoveAllChars()
	{
		Chars.clear();
	}

	void CharTile::SetEmpty()
	{
		Data.Clear();
		RemoveAllChars();
		Transparent = false;
	}

	bool CharTile::IsEmpty() const
	{
		return HasNoData() && HasNoChars();
	}

	bool CharTile::HasAnyChar() const
	{
		return !Chars.empty();
	}

	bool CharTile::HasNoChars() const
	{
		return !HasAnyChar();
	}

	bool CharTile::HasAnyData() const
	{
		return !Data.Empty();
	}

	bool CharTile::HasNoData() const
	{
		return !HasAnyData();
	}

	void CharTile::SetCurrentAnimFrame(int index)
	{
		Anim.CurrentFrame = index;
	}

	void CharTile::SetAnimationDelay(int delay)
	{
		Anim.MaxFrameCounter = delay;
	}

	void CharTile::EnableAnimation(bool enable)
	{
		Anim.Enabled = enable;
	}

	void CharTile::Draw(Graphics* g, Charset* charset, Palette* palette, const Point& pos)
	{
		CharTileFrame& curFrame = NextChar();

		g->DrawBitPattern(charset->Get(curFrame.Char), pos, 
			palette->Get(curFrame.ForeColor), palette->Get(curFrame.BackColor), 
			false, Transparent);
	}

	void CharTile::Draw(Graphics* g, Charset* charset, Palette* palette, int x, int y)
	{
		Draw(g, charset, palette, Point(x, y));
	}
}
