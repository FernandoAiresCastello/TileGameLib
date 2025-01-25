#include "TGL_Color.h"
#include "TGL_Util.h"

namespace TGL
{
    Color::Color() : r(0), g(0), b(0) {}
    Color::Color(int r, int g, int b) : r(r), g(g), b(b) {}

    Color::Color(RGB rgb)
    {
        UnpackRGB(rgb, &r, &g, &b);
    }

    Color::Color(const Color& other)
    {
        r = other.r;
        g = other.g;
        b = other.b;
    }

    bool Color::operator==(const Color& other) const
    {
        return r == other.r && g == other.g && b == other.b;
    }

    Color& Color::operator=(const Color& other)
    {
        if (this == &other)
            return *this;

        r = other.r;
        g = other.g;
        b = other.b;

        return *this;
    }

    inline RGB Color::ToRGB() const
    {
        return PackRGB(r, g, b);
    }

    inline RGB Color::PackRGB(int r, int g, int b)
    {
        return (r << 16) | (g << 8) | b;
    }

    inline void Color::UnpackRGB(RGB rgb, int* r, int* g, int* b)
    {
        *r = (rgb >> 16) & 0xFF;
        *g = (rgb >> 8) & 0xFF;
        *b = rgb & 0xFF;
    }

    Color Color::GetRandom()
    {
        return Color(Util::Rnd(0, 255), Util::Rnd(0, 255), Util::Rnd(0, 255));
    }

    void Color::Set(RGB rgb)
    {
        UnpackRGB(rgb, &r, &g, &b);
    }

    void Color::Set(int r, int g, int b)
    {
        this->r = r;
        this->g = g;
        this->b = b;
    }

    void Color::SetR(int r) { this->r = r; }
    void Color::SetG(int g) { this->g = g; }
    void Color::SetB(int b) { this->b = b; }
    int Color::GetR() const { return r; }
    int Color::GetG() const { return g; }
    int Color::GetB() const { return b; }
}
