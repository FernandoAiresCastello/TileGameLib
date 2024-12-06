#pragma once
#include "TGL_Global.h"
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
		Image* GetTile(int index);
		int GetTileCount() const;
		const Size& GetTileSize() const;

	private:
		Size tileSize;
		List<Image> tiles;
	};
}
