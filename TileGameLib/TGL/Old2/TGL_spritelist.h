#pragma once
#include "TGL_global.h"

struct spritelist
{
	spritelist();
	~spritelist();

	struct sprite* add_new();
	void delete_all();
	vector<struct sprite*>& get_all();

private:
	friend class TGL;
	friend class sprite;

	vector<struct sprite*> sprites;

	spritelist(const spritelist&) = delete;
	spritelist(spritelist&&) = delete;
};
