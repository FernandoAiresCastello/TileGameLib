#include "TGL_BitPattern.h"

namespace TGL
{
	BitPattern::BitPattern() : bitString(String::Repeat(BitValue0, Length))
	{
	}

	BitPattern::BitPattern(const BitPattern& other) : bitString(other.bitString)
	{
		FixBitString();
	}
	
	BitPattern::BitPattern(const String& binary) : bitString(binary)
	{
		FixBitString();
	}

	BitPattern::BitPattern(const char* binary) : bitString(binary)
	{
		FixBitString();
	}

	const String& BitPattern::GetBits() const
	{
		return bitString;
	}

	void BitPattern::FixBitString()
	{
		if (!bitString.HasLength(Length))
			bitString = bitString.Truncate(Length);
		
		for (int i = 0; i < bitString.Length(); i++) {
			if (bitString[i] != BitValue1 && bitString[i] != BitValue0) {
				bitString[i] = BitValue0;
			}
		}
	}
}
