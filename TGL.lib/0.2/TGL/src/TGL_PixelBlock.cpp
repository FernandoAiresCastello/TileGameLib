#include "TGL_PixelBlock.h"

namespace TGL
{
	PixelBlock::PixelBlock() : binary()
	{
	}

	PixelBlock::PixelBlock(const PixelBlock& other) : binary(other.binary)
	{
		FixBinaryString();
	}
	
	PixelBlock::PixelBlock(const String& binary) : binary(binary)
	{
		FixBinaryString();
	}

	String& PixelBlock::GetPixels() const
	{
		return (String&)binary;
	}

	void PixelBlock::FixBinaryString()
	{
		if (!binary.HasLength(Length)) {
			binary = binary.Truncate(Length);
		}
	}
}
