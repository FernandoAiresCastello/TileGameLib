#pragma once
#include "TGL_Global.h"
#include "TGL_Color.h"
#include "TGL_List.h"
#include "TGL_Index.h"

namespace TGL
{
	class TGLAPI Palette
	{
	public:
		Palette();
		Palette(const Palette& other);

		void Add(const Color& color);
		void Set(Index index, const Color& color);
		Color& Get(Index index);
		void RemoveAll();

	private:
		List<Color> colors;

		void InitDefault();
	};
}
