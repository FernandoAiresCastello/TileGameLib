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

	PixelBlock::PixelBlock(const char* binary) : binary(binary)
	{
		FixBinaryString();
	}

	const String& PixelBlock::GetPixels() const
	{
		return binary;
	}

	void PixelBlock::FixBinaryString()
	{
		if (!binary.HasLength(Length)) {
			binary = binary.Truncate(Length);
		}
	}
}
