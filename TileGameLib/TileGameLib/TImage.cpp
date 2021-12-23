/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include <SDL.h>
#include <CppUtils.h>
#include "TImage.h"

using namespace CppUtils;

namespace TileGameLib
{
	TImage::TImage()
	{
	}

	TImage::~TImage()
	{
	}

	void TImage::Load(std::string filename)
	{
		if (!File::Exists(filename)) {
			MsgBox::Error("File not found: " + filename);
			return;
		}

		Pixels.clear();

		SDL_Surface* img = SDL_LoadBMP(filename.c_str());
		const Uint8 bpp = img->format->BytesPerPixel;
		Width = img->w;
		Height = img->h;

		for (int y = 0; y < Height; y++) {
			for (int x = 0; x < Width; x++) {
				Uint8* pPixel = (Uint8*)img->pixels + y * img->pitch + x * bpp;
				Uint32 PixelData = *(Uint32*)pPixel;
				SDL_Color Color = { 0x00, 0x00, 0x00, SDL_ALPHA_OPAQUE };
				SDL_GetRGB(PixelData, img->format, &Color.r, &Color.g, &Color.b);
				Pixels.push_back(TColor(Color.r, Color.g, Color.b));
			}
		}
	}

	int TImage::GetWidth()
	{
		return Width;
	}

	int TImage::GetHeight()
	{
		return Height;
	}

	TColor TImage::GetPixel(int i)
	{
		return Pixels[i];
	}

	TColor TImage::GetPixel(int x, int y)
	{
		return Pixels[y * Width + x];
	}
}
