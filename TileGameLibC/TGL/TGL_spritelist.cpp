#include "TGL_spritelist.h"
#include "TGL_sprite.h"

spritelist::spritelist()
{
}
spritelist::~spritelist()
{
	deleteall();
}
sprite* spritelist::newsprite()
{
	sprite* newsprite = new sprite();
	sprites.push_back(newsprite);
	return newsprite;
}
void spritelist::deleteall()
{
	for (int i = 0; i < sprites.size(); i++) {
		delete sprites[i];
		sprites[i] = nullptr;
	}
	sprites.clear();
}
vector<struct sprite*>& spritelist::getall()
{
	return sprites;
}
