#pragma once
#include "TGL_Global.h"
#include "TGL_Image.h"
#include "TGL_Size.h"
#include "TGL_List.h"
#include "TGL_Index.h"

namespace TGL
{
	class TGLAPI ImageTileset : public Image
	{
	public:
		ImageTileset();
		~ImageTileset();

		void GenerateTiles(const Size& tileSize);
		Image* GetTile(Index index);
		int GetTileCount() const;
		const Size& GetTileSize() const;

	private:
		Size tileSize;
		List<Image> tiles;
	};
}
