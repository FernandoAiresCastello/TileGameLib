#pragma once
#include "TGL_Globals.h"
#include "TGL_Image.h"
#include "TGL_Size.h"
#include "TGL_List.h"

namespace TGL
{
	class TGLAPI TiledImage : public Image
	{
	public:
		TiledImage();
		~TiledImage();

		void GenerateTiles(const Size& tileSize);
		const Image& GetTile(int index) const;
		int GetTileCount() const;

	private:
		Size tileSize;
		List<Image> tiles;
	};
}
