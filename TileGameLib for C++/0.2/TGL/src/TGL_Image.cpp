#include <SDL_image.h>
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

	Image::Image(const String& filename)
	{
		Load(filename);
	}

	Image::~Image()
	{
	}

	bool Image::Load(const String& filename)
	{
		pixels.clear();

		SDL_Surface* temp = IMG_Load(filename.Cstr());
		if (!temp) return false;
		SDL_Surface* img = SDL_ConvertSurface(temp, SDL_PIXELFORMAT_ARGB8888);
		if (!img) return false;
		SDL_DestroySurface(temp);
		temp = nullptr;

		size = { img->w, img->h };

		if (SDL_MUSTLOCK(img)) {
			if (!SDL_LockSurface(img))
				return false;
		}

		uint8_t* surface_pixels = static_cast<uint8_t*>(img->pixels);
		const SDL_PixelFormatDetails* format = SDL_GetPixelFormatDetails(img->format);

		for (int y = 0; y < img->h; ++y) {
			for (int x = 0; x < img->w; ++x) {
				uint32_t* pixelAddr = reinterpret_cast<uint32_t*>(
					surface_pixels + y * img->pitch + x * format->bytes_per_pixel);

				uint8_t r, g, b, a;
				SDL_GetRGBA(*pixelAddr, format, nullptr, &r, &g, &b, &a);
				pixels.emplace_back(r, g, b);
			}
		}

		if (SDL_MUSTLOCK(img))
			SDL_UnlockSurface(img);

		SDL_DestroySurface(img);

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
