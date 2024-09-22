#pragma once
#include "TGL_Globals.h"
#include "TGL_String.h"

namespace TGL
{
	class TGLAPI PixelBlock
	{
	public:
		static const int Width = 8;
		static const int Height = 8;
		static const int Length = Width * Height;
		static const char Color0 = '0';
		static const char Color1 = '1';

		PixelBlock();
		PixelBlock(const PixelBlock& other);
		PixelBlock(const String& binary);
		PixelBlock(const char* binary);

		const String& GetPixels() const;

	private:
		String binary;

		void FixBinaryString();
	};
}
