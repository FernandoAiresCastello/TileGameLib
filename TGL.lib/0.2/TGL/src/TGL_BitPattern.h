#pragma once
#include "TGL_Globals.h"
#include "TGL_String.h"

namespace TGL
{
	class TGLAPI BitPattern
	{
	public:
		static const int Width = 8;
		static const int Height = 8;
		static const int Length = Width * Height;
		static const char BitValue0 = '0';
		static const char BitValue1 = '1';

		BitPattern();
		BitPattern(const BitPattern& other);
		BitPattern(const String& bitString);
		BitPattern(const char* bitString);

		const String& GetBits() const;

	private:
		String bitString;

		void FixBitString();
	};
}
