#pragma once
#include "TGL_Globals.h"
#include "TGL_BitPattern.h"
#include "TGL_List.h"
#include "TGL_Index.h"

namespace TGL
{
	class TGLAPI Charset
	{
	public:
		static const BitPattern EmptyBlock;

		Charset();
		Charset(const Charset& other);

		void Add(const BitPattern& block);
		void Set(Index index, const BitPattern& block);
		const BitPattern* Get(Index index) const;
		void RemoveAll();

	private:
		List<BitPattern> chars;

		void InitDefault();
	};
}
