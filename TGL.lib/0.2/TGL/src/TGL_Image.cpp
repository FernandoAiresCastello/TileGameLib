#include <SDL.h>
#include "TGL_Image.h"

namespace TGL
{
	Image::Image() : width(0), height(0), size(0), transparent(false), transparency()
	{
	}

	Image::~Image()
	{
	}

	bool Image::Load(const String& filename)
	{
		pixels.clear();

		SDL_Surface* img = SDL_LoadBMP(filename.Cstr());
		if (!img)
			return false;

		const Uint8 bpp = img->format->BytesPerPixel;
		width = img->w;
		height = img->h;
		size = width * height;

		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				Uint8* pPixel = (Uint8*)img->pixels + y * img->pitch + x * bpp;
				Uint32 PixelData = *(Uint32*)pPixel;
				SDL_Color color = { 0x00, 0x00, 0x00, SDL_ALPHA_OPAQUE };
				SDL_GetRGB(PixelData, img->format, &color.r, &color.g, &color.b);
				pixels.push_back(Color(color.r, color.g, color.b));
			}
		}

		SDL_FreeSurface(img);

		return true;
	}

	bool Image::Load(const String& filename, const Color& transparency)
	{
		if (!Load(filename))
			return false;

		SetTransparency(transparency);
		return true;
	}

	int Image::GetWidth() const
	{
		return width;
	}

	int Image::GetHeight() const
	{
		return height;
	}

	int Image::GetSize() const
	{
		return size;
	}

	bool Image::IsTransparent() const
	{
		return transparent;
	}

	void Image::SetTransparency(const Color& color)
	{
		transparent = true;
		transparency = color;
	}

	Color& Image::GetTransparency()
	{
		return transparency;
	}

	Color& Image::GetPixel(int i)
	{
		return pixels[i];
	}

	Color& Image::GetPixel(int x, int y)
	{
		return pixels[y * width + x];
	}

	List<Color>& Image::GetPixels()
	{
		return pixels;
	}
}
