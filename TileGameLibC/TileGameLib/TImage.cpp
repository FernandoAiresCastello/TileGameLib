/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#include <SDL.h>
#include <CppUtils.h>
#include "TImage.h"

using namespace CppUtils;

namespace TileGameLib
{
	TImage::TImage() : Width(0), Height(0), Size(0), Transparent(false), Transparency()
	{
	}

	TImage::~TImage()
	{
	}

	bool TImage::Load(std::string filename)
	{
		if (!File::Exists(filename)) {
			MsgBox::Error("File not found: " + filename);
			return false;
		}

		Pixels.clear();

		SDL_Surface* img = SDL_LoadBMP(filename.c_str());
		const Uint8 bpp = img->format->BytesPerPixel;
		Width = img->w;
		Height = img->h;
		Size = Width * Height;

		for (int y = 0; y < Height; y++) {
			for (int x = 0; x < Width; x++) {
				Uint8* pPixel = (Uint8*)img->pixels + y * img->pitch + x * bpp;
				Uint32 PixelData = *(Uint32*)pPixel;
				SDL_Color Color = { 0x00, 0x00, 0x00, SDL_ALPHA_OPAQUE };
				SDL_GetRGB(PixelData, img->format, &Color.r, &Color.g, &Color.b);
				Pixels.push_back(TColor(Color.r, Color.g, Color.b));
			}
		}

		return true;
	}

	bool TImage::Load(std::string filename, TColor transparency)
	{
		if (!Load(filename))
			return false;

		SetTransparency(transparency);
		return true;
	}

	int TImage::GetWidth()
	{
		return Width;
	}

	int TImage::GetHeight()
	{
		return Height;
	}

	int TImage::GetSize()
	{
		return Size;
	}

	bool TImage::IsTransparent()
	{
		return Transparent;
	}

	void TImage::SetTransparency(TColor color)
	{
		Transparent = true;
		Transparency = color;
	}

	TColor& TImage::GetTransparency()
	{
		return Transparency;
	}

	TColor& TImage::GetPixel(int i)
	{
		return Pixels[i];
	}

	TColor& TImage::GetPixel(int x, int y)
	{
		return Pixels[y * Width + x];
	}
}
