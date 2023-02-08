#include "TGL_spritelist.h"
#include "TGL_sprite.h"

spritelist::spritelist()
{
}
spritelist::~spritelist()
{
	delete_all();
}
sprite* spritelist::add_new()
{
	sprite* newsprite = new sprite();
	sprites.push_back(newsprite);
	return newsprite;
}
void spritelist::delete_all()
{
	for (int i = 0; i < sprites.size(); i++) {
		delete sprites[i];
		sprites[i] = nullptr;
	}
	sprites.clear();
}
vector<struct sprite*>& spritelist::get_all()
{
	return sprites;
}
