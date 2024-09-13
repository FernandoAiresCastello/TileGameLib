#include <SDL.h>
#include "TGL_Image.h"

namespace TGL
{
	TGL_Image::TGL_Image() : Width(0), Height(0), Size(0), Transparent(false), Transparency()
	{
	}

	TGL_Image::~TGL_Image()
	{
	}

	bool TGL_Image::Load(TGL_String filename)
	{
		Pixels.clear();

		SDL_Surface* img = SDL_LoadBMP(filename.Cstr());
		if (!img)
			return false;

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
				Pixels.push_back(TGL_Color(Color.r, Color.g, Color.b));
			}
		}

		SDL_FreeSurface(img);

		return true;
	}

	bool TGL_Image::Load(TGL_String filename, TGL_Color transparency)
	{
		if (!Load(filename))
			return false;

		SetTransparency(transparency);
		return true;
	}

	int TGL_Image::GetWidth() const
	{
		return Width;
	}

	int TGL_Image::GetHeight() const
	{
		return Height;
	}

	int TGL_Image::GetSize() const
	{
		return Size;
	}

	bool TGL_Image::IsTransparent() const
	{
		return Transparent;
	}

	void TGL_Image::SetTransparency(TGL_Color color)
	{
		Transparent = true;
		Transparency = color;
	}

	TGL_Color& TGL_Image::GetTransparency()
	{
		return Transparency;
	}

	TGL_Color& TGL_Image::GetPixel(int i)
	{
		return Pixels[i];
	}

	TGL_Color& TGL_Image::GetPixel(int x, int y)
	{
		return Pixels[y * Width + x];
	}

	TGL_List<TGL_Color>& TGL_Image::GetPixels()
	{
		return Pixels;
	}
}
