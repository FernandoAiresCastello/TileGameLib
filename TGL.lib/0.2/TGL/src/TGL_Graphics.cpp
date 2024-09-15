#include "TGL_Graphics.h"
#include "TGL_Image.h"

namespace TGL
{
	Graphics::Graphics(const Size& size)
	{
		this->size = size;
		bufferLength = sizeof(int) * size.GetWidth() * size.GetHeight();
		buffer = new RGB[bufferLength];
		ResetClip();
	}

	Graphics::~Graphics()
	{
		delete buffer;
	}

	RGB* Graphics::GetBuffer()
	{
		return buffer;
	}

	int Graphics::GetBufferLength() const
	{
		return bufferLength;
	}

	void Graphics::ClearToColor(const Color& color)
	{
		for (int y = 0; y < size.GetHeight(); y++)
			for (int x = 0; x < size.GetWidth(); x++)
				SetPixel(Point(x, y), color);
	}

	void Graphics::SaveScreenshot(const String& file) const
	{
		SDL_Surface* surface = SDL_CreateRGBSurfaceWithFormat(0, size.GetWidth(), size.GetHeight(), 32, SDL_PIXELFORMAT_ARGB8888);
		SDL_memcpy(surface->pixels, buffer, bufferLength);
		SDL_SaveBMP(surface, file.Cstr());
		SDL_FreeSurface(surface);
	}

	Size Graphics::GetSize() const
	{
		return size;
	}

	Rect Graphics::GetRect() const
	{
		return Rect(0, 0, size.GetWidth() - 1, size.GetHeight() - 1);
	}

	void Graphics::SetPixel(const Point& pos, const Color& color)
	{
		if (clip.Contains(pos))
			buffer[pos.GetY() * size.GetWidth() + pos.GetX()] = color.ToRGB();
	}

	void Graphics::FillRect(const Rect& rect, const Color& color)
	{
		for (int iy = rect.GetY1(); iy <= rect.GetY2(); iy++) {
			for (int ix = rect.GetX1(); ix <= rect.GetX2(); ix++) {
				if (ix >= 0 && iy >= 0 && ix < size.GetWidth() && iy < size.GetHeight()) {
					SetPixel(Point(ix, iy), color);
				}
			}
		}
	}

	Color Graphics::GetPixel(int x, int y)
	{
		return Color(buffer[y * size.GetWidth() + x]);
	}

	void Graphics::SetClip(const Rect& rect)
	{
		clip = rect;
	}

	void Graphics::ResetClip()
	{
		clip = { 0, 0, size.GetWidth() - 1, size.GetHeight() - 1 };
	}

	void Graphics::DrawPixelBlock(const PixelBlock& block, const Point& pos, const Color& color1, const Color& color0, bool grid, bool hideColor0)
	{
		int x = pos.GetX();
		int y = pos.GetY();

		if (grid) { 
			x *= PixelBlock::Width;
			y *= PixelBlock::Height;
		}

		int px = x;
		int py = y;
		const int max_x = x + PixelBlock::Width;

		for (int i = 0; i < PixelBlock::Length; i++) {
			if (hideColor0) {
				if (block.GetPixels()[i] == PixelBlock::Color1) {
					SetPixel(Point(px, py), color1);
				}
			}
			else {
				SetPixel(Point(px, py), (block.GetPixels()[i] == PixelBlock::Color1 ? color1 : color0));
			}
			if (++px >= max_x) {
				px = x;
				py++;
			}
		}
	}

	void Graphics::DrawImage(const Image& img, const Point& pos)
	{
		for (int py = 0; py < img.GetSize().GetHeight(); py++) {
			for (int px = 0; px < img.GetSize().GetWidth(); px++) {
				SetPixel(Point(pos.GetX() + px, pos.GetY() + py), img.GetPixel(Point(px, py)));
			}
		}
	}

	void Graphics::DrawImageTile(const Image& img, const Rect& imgRect, const Point& dest)
	{
		int destX = dest.GetX();
		int destY = dest.GetY();

		const int initialX = destX;
		for (int py = imgRect.GetY1(); py <= imgRect.GetY2(); py++) {
			for (int px = imgRect.GetX1(); px <= imgRect.GetX2(); px++) {
				SetPixel(Point(destX, destY), img.GetPixel(Point(px, py)));
				destX++;
			}
			destX = initialX;
			destY++;
		}
	}
}
