#pragma once
#include "TGL_Global.h"
#include "TGL_BitPattern.h"
#include "TGL_List.h"
#include "TGL_Index.h"

namespace TGL
{
	class TGLAPI Charset
	{
	public:
		Charset();
		Charset(const Charset& other);

		void Add(const BitPattern& block);
		void Set(Index index, const BitPattern& block);
		BitPattern& Get(Index index);
		void RemoveAll();

	private:
		List<BitPattern> chars;

		void InitDefault();
	};
}
