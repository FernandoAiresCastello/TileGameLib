#include "TGL_Image.h"

namespace TGL
{
	Image::Image() : size(0, 0), pixelCount(0), transparent(false), transparency()
	{
	}

	Image::Image(const Size& size) : size(size), pixelCount(size.GetWidth() * size.GetHeight()), transparent(false), transparency()
	{
		for (int i = 0; i < pixelCount; i++)
			pixels.emplace_back(0xffffff);
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
		size = { img->w, img->h };
		pixelCount = size.GetWidth() * size.GetHeight();

		for (int y = 0; y < size.GetHeight(); y++) {
			for (int x = 0; x < size.GetWidth(); x++) {
				Uint8* pPixel = (Uint8*)img->pixels + y * img->pitch + x * bpp;
				Uint32 PixelData = *(Uint32*)pPixel;
				SDL_Color color = { 0x00, 0x00, 0x00, SDL_ALPHA_OPAQUE };
				SDL_GetRGB(PixelData, img->format, &color.r, &color.g, &color.b);
				pixels.emplace_back(Color(color.r, color.g, color.b));
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

	Size Image::GetSize() const
	{
		return size;
	}

	int Image::GetPixelCount() const
	{
		return pixelCount;
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

	const Color& Image::GetTransparency() const
	{
		return transparency;
	}

	const Color& Image::GetPixel(int i) const
	{
		return pixels[i];
	}

	const Color& Image::GetPixel(const Point& point) const
	{
		return pixels[point.GetY() * size.GetWidth() + point.GetX()];
	}

	List<Color>& Image::GetPixels()
	{
		return pixels;
	}

	void Image::SetPixel(const Color& color, int i)
	{
		pixels[i] = color;
	}

	void Image::SetPixel(const Color& color, const Point& point)
	{
		pixels[point.GetY() * size.GetWidth() + point.GetX()] = color;
	}
}
