/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API MenuItem
	{
	public:
		MenuItem(std::string text, void* object = NULL);
		MenuItem(std::string text, byte id = 0);
		~MenuItem();

		std::string GetText();
		void* GetObject();
		int GetId();
		void SetId(int id);

	private:
		std::string Text;
		void* Object;
		byte Id;
	};
}
