#include "TGL_Color.h"
#include "TGL_Util.h"

namespace TGL
{
    TGL_Color::TGL_Color() : r(0), g(0), b(0) {}
    TGL_Color::TGL_Color(int r, int g, int b) : r(r), g(g), b(b) {}

    TGL_Color::TGL_Color(TGL_Rgb rgb)
    {
        UnpackRgb(rgb, &r, &g, &b);
    }

    TGL_Color::TGL_Color(const TGL_Color& other)
    {
        r = other.r;
        g = other.g;
        b = other.b;
    }

    bool TGL_Color::operator==(const TGL_Color& other) const
    {
        return r == other.r && g == other.g && b == other.b;
    }

    TGL_Color& TGL_Color::operator=(const TGL_Color& other)
    {
        if (this == &other)
            return *this;

        r = other.r;
        g = other.g;
        b = other.b;

        return *this;
    }

    TGL_Rgb TGL_Color::PackRgb(int r, int g, int b)
    {
        return (r << 16) | (g << 8) | b;
    }

    void TGL_Color::UnpackRgb(TGL_Rgb rgb, int* r, int* g, int* b)
    {
        *r = (rgb >> 16) & 0xFF;
        *g = (rgb >> 8) & 0xFF;
        *b = rgb & 0xFF;
    }

    TGL_Color TGL_Color::GetRandom()
    {
        return TGL_Color(TGL_Util::Rnd(0, 255), TGL_Util::Rnd(0, 255), TGL_Util::Rnd(0, 255));
    }

    void TGL_Color::Set(TGL_Rgb rgb)
    {
        UnpackRgb(rgb, &r, &g, &b);
    }

    void TGL_Color::Set(int r, int g, int b)
    {
        this->r = r;
        this->g = g;
        this->b = b;
    }

    void TGL_Color::SetR(int r) { this->r = r; }
    void TGL_Color::SetG(int g) { this->g = g; }
    void TGL_Color::SetB(int b) { this->b = b; }
    int TGL_Color::GetR() const { return r; }
    int TGL_Color::GetG() const { return g; }
    int TGL_Color::GetB() const { return b; }

    TGL_Rgb TGL_Color::ToRgb() const
    {
        return PackRgb(r, g, b);
    }
}
