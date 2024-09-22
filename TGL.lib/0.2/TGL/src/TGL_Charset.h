#pragma once
#include "TGL_Globals.h"
#include "TGL_PixelBlock.h"
#include "TGL_List.h"
#include "TGL_Index.h"

namespace TGL
{
	class TGLAPI Charset
	{
	public:
		Charset();
		Charset(const Charset& other);

		void Add(const PixelBlock& block);
		const PixelBlock* Get(Index index) const;
		void RemoveAll();

	private:
		List<PixelBlock> chars;

		void InitDefault();
	};
}
