#pragma once
#include "common.h"

typedef int rgb;

class t_color
{
public:
	t_color();
	t_color(rgb rgb);
	t_color(int r, int g, int b);
	t_color(const t_color& other);

	bool operator==(const t_color& other) const;
	t_color& operator=(const t_color& other);

	static rgb pack_rgb(int r, int g, int b);
	static void unpack_rgb(rgb rgb, int* r, int* g, int* b);
	static t_color get_random();

	void set(int r, int g, int b);
	void set_r(int r);
	void set_g(int g);
	void set_b(int b);
	int get_r();
	int get_g();
	int get_b();
	rgb to_rgb();

private:
	int r = 0;
	int g = 0;
	int b = 0;
};
