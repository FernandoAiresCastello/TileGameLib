#pragma once
#include "TGL_global.h"

struct spritelist
{
	spritelist();
	~spritelist();

	struct sprite* newsprite();
	void deleteall();
	vector<struct sprite*>& getall();

private:
	friend class TGL;
	friend class sprite;

	vector<struct sprite*> sprites;

	spritelist(const spritelist&) = delete;
	spritelist(spritelist&&) = delete;
};
