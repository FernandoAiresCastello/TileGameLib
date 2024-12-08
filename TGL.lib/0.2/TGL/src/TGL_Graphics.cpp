#include "TGL_Graphics.h"
#include "TGL_Image.h"
#include "TGL_BitPattern.h"
#include "TGL_Charset.h"

namespace TGL
{
	Graphics::Graphics(const Size& size, const Color& backColor)
	{
		this->size = size;
		this->backColor = backColor;
		
		bufferLength = sizeof(int) * size.GetWidth() * size.GetHeight();
		buffer = new RGB[bufferLength];

		ResetClip();
		Clear();
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

	void Graphics::SetBackColor(const Color& backColor)
	{
		this->backColor = backColor;
	}

	Color Graphics::GetBackColor()
	{
		return backColor;
	}

	void Graphics::Clear()
	{
		for (int y = 0; y < size.GetHeight(); y++)
			for (int x = 0; x < size.GetWidth(); x++)
				SetPixel(Point(x, y), backColor);
	}

	Size Graphics::GetSize() const
	{
		return size;
	}

	Rect Graphics::GetRect() const
	{
		return size.GetRect();
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
		clip = size.GetRect();
	}

	void Graphics::DrawImage(Image* img, const Point& pos)
	{
		if (!img)
			return;

		for (int py = 0; py < img->GetSize().GetHeight(); py++) {
			for (int px = 0; px < img->GetSize().GetWidth(); px++) {
				const Color& color = img->GetPixel(Point(px, py));
				if (img->IsTransparent() && img->GetTransparency() == color)
					continue;

				SetPixel(Point(pos.GetX() + px, pos.GetY() + py), color);
			}
		}
	}

	void Graphics::DrawImageTile(Image* img, const Rect& imgRect, const Point& dest)
	{
		if (!img)
			return;

		int destX = dest.GetX();
		int destY = dest.GetY();

		const int initialX = destX;
		for (int py = imgRect.GetY1(); py <= imgRect.GetY2(); py++) {
			for (int px = imgRect.GetX1(); px <= imgRect.GetX2(); px++) {
				const Color& color = img->GetPixel(Point(px, py));
				if (img->IsTransparent() && img->GetTransparency() == color) {
					destX++;
					continue;
				}
				SetPixel(Point(destX, destY), img->GetPixel(Point(px, py)));
				destX++;
			}
			destX = initialX;
			destY++;
		}
	}

	void Graphics::DrawBitPattern(const BitPattern* pattern, const Point& pos, const Color& color1, const Color& color0, bool grid, bool hideColor0)
	{
		if (!pattern)
			return;

		int x = pos.GetX();
		int y = pos.GetY();

		if (grid) {
			x *= BitPattern::Width;
			y *= BitPattern::Height;
		}

		int px = x;
		int py = y;
		const int max_x = x + BitPattern::Width;

		for (int i = 0; i < BitPattern::Length; i++) {
			if (hideColor0) {
				if (pattern->GetBits()[i] == BitPattern::BitValue1) {
					SetPixel(Point(px, py), color1);
				}
			}
			else {
				SetPixel(Point(px, py), (pattern->GetBits()[i] == BitPattern::BitValue1 ? color1 : color0));
			}
			if (++px >= max_x) {
				px = x;
				py++;
			}
		}
	}

	void Graphics::DrawChar(const Charset* chars, Index index, const Point& pos, const Color& color1, const Color& color0, bool grid, bool hideColor0)
	{
		DrawBitPattern(chars->Get(index), pos, color1, color0, grid, hideColor0);
	}

	void Graphics::DrawString(const Charset* chars, const String& str, const Point& pos, const Color& color1, const Color& color0, bool grid, bool hideColor0)
	{
		int x = pos.GetX();
		int y = pos.GetY();

		if (grid) {
			x *= BitPattern::Width;
			y *= BitPattern::Height;
		}

		for (auto& ch : str.Sstr()) {
			DrawChar(chars, ch, Point(x, y), color1, color0, false, hideColor0);
			x += BitPattern::Width;
		}
	}
}
