#pragma once
#include "TGL_Global.h"
#include "TGL_CharTileFrame.h"
#include "TGL_Properties.h"
#include "TGL_List.h"
#include "TGL_Point.h"

namespace TGL
{
	class Graphics;
	class Charset;
	class Palette;

	class TGLAPI CharTile
	{
	public:
		Properties Data;
		bool Transparent;

		CharTile();
		CharTile(const CharTile& other);
		CharTile(const CharTileFrame& singleChar);
		~CharTile();

		CharTile& operator=(const CharTile& other);

		int CharCount() const;
		CharTileFrame& GetChar(int index);
		CharTileFrame CopyChar(int index) const;
		void AddChar(const CharTileFrame& ch);
		void AddChar(Index ch, Index foreColor, Index backColor);
		void SetChar(int index, const CharTileFrame& ch);
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
		List<CharTileFrame> Chars;

		struct {
			bool Enabled = true;
			int CurrentFrame = 0;
			int FrameCounter = 0;
			int MaxFrameCounter = 70;
		} Anim;

		CharTileFrame& NextChar();
	};
}
