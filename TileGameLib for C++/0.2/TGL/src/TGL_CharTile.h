#pragma once
#include "TGL_Global.h"
#include "TGL_Char.h"
#include "TGL_Properties.h"
#include "TGL_List.h"
#include "TGL_Point.h"
#include "TGL_TileAnimation.h"

namespace TGL
{
	class Graphics;
	class Charset;
	class Palette;

	class TGLAPI CharTile
	{
	public:
		Properties data;
		bool transparent;

		CharTile();
		CharTile(const CharTile& other);
		CharTile(const Char& singleChar);
		~CharTile();

		CharTile& operator=(const CharTile& other);

		int CharCount() const;
		Char& GetChar(int index);
		Char CopyChar(int index) const;
		void AddChar(const Char& ch);
		void AddChar(Index ch, Index foreColor, Index backColor);
		void SetChar(int index, const Char& ch);
		void SetChar(int index, Index ch, Index foreColor, Index backColor);
		void RemoveAllChars();
		void SetEmpty();
		bool IsEmpty() const;
		bool HasAnyChar() const;
		bool HasNoChars() const;
		bool HasAnyData() const;
		bool HasNoData() const;
		void SetCurrentAnimFrame(int index);
		void SetAnimationDelay(int delay);
		void EnableAnimation(bool enable);
		void Draw(Graphics* g, Charset* charset, Palette* palette, const Point& pos);
		void Draw(Graphics* g, Charset* charset, Palette* palette, int x, int y);

	private:
		List<Char> chars;
		TileAnimation anim;

		Char& NextChar();
	};
}
