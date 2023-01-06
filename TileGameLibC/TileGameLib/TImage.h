/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <vector>
#include <string>
#include "TColor.h"

namespace TileGameLib
{
	class TImage
	{
	public:
		TImage();
		~TImage();

		bool Load(std::string filename);
		bool Load(std::string filename, TColor transparency);
		int GetWidth();
		int GetHeight();
		int GetSize();
		bool IsTransparent();
		void SetTransparency(TColor color);
		TColor& GetTransparency();
		TColor& GetPixel(int i);
		TColor& GetPixel(int x, int y);

	private:
		friend class TTiledImage;

		int Width;
		int Height;
		int Size;
		bool Transparent;
		TColor Transparency;
		std::vector<TColor> Pixels;
	};
}
