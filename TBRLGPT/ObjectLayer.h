/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"
#include "Object.h"

namespace TBRLGPT
{
	class TBRLGPT_API ObjectLayer
	{
	public:
		ObjectLayer(int width, int height);
		~ObjectLayer();

		void SetObject(Object object, int x, int y);
		void DeleteObject(int x, int y);
		Object* GetObject(int x, int y);
		Object CopyObject(int x, int y);
		int GetWidth();
		int GetHeight();
		void Clear();
		void SetEqual(ObjectLayer& other);
		void Resize(int width, int height);

	private:
		int Width;
		int Height;

		Object** Objects;

		void InitObjects();
		void DestroyObjects();
	};
}
