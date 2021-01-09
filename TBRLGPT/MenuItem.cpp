/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "MenuItem.h"

namespace TBRLGPT
{
	MenuItem::MenuItem(std::string text, void* object)
	{
		Text = text;
		Object = object;
		Id = 0;
	}

	MenuItem::MenuItem(std::string text, byte id)
	{
		Text = text;
		Object = NULL;
		Id = id;
	}

	MenuItem::~MenuItem()
	{
	}

	std::string MenuItem::GetText()
	{
		return Text;
	}

	void* MenuItem::GetObject()
	{
		return Object;
	}

	int MenuItem::GetId()
	{
		return Id;
	}

	void MenuItem::SetId(int id)
	{
		Id = id;
	}
}
