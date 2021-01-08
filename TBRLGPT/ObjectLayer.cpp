/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "ObjectLayer.h"

namespace TBRLGPT
{
	Object NullObject;

	ObjectLayer::ObjectLayer(int width, int height) : Width(width), Height(height)
	{
		InitObjects();
	}

	ObjectLayer::~ObjectLayer()
	{
		DestroyObjects();
	}

	void ObjectLayer::InitObjects()
	{
		Objects = new Object*[Height];
		for (int i = 0; i < Height; i++)
			Objects[i] = new Object[Width];
	}

	void ObjectLayer::DestroyObjects()
	{
		for (int i = 0; i < Height; i++)
			delete[] Objects[i];

		delete Objects;
	}

	void ObjectLayer::SetObject(Object object, int x, int y)
	{
		if (y >= 0 && y < Height && x >= 0 && x < Width) {
			Objects[y][x].SetEqual(object, false);
			Objects[y][x].SetVoid(false);
		}
	}

	void ObjectLayer::DeleteObject(int x, int y)
	{
		if (y >= 0 && y < Height && x >= 0 && x < Width)
			Objects[y][x].SetVoid(true);
	}

	Object* ObjectLayer::GetObject(int x, int y)
	{
		if (y >= 0 && y < Height && x >= 0 && x < Width)
			return &(Objects[y][x]);

		return NULL;
	}

	Object ObjectLayer::CopyObject(int x, int y)
	{
		if (y >= 0 && y < Height && x >= 0 && x < Width)
			return Objects[y][x];

		return NullObject;
	}

	int ObjectLayer::GetWidth()
	{
		return Width;
	}

	int ObjectLayer::GetHeight()
	{
		return Height;
	}

	void ObjectLayer::Clear()
	{
		for (int y = 0; y < Height; y++)
			for (int x = 0; x < Width; x++)
				GetObject(x, y)->SetVoid(true);
	}

	void ObjectLayer::SetEqual(ObjectLayer& other)
	{
		for (int y = 0; y < Height; y++) {
			for (int x = 0; x < Width; x++) {
				if (x < other.GetWidth() && y < other.GetHeight()) {
					Object* ch = other.GetObject(x, y);
					Object copy(*ch);
					SetObject(copy, x, y);
				}
			}
		}
	}

	void ObjectLayer::Resize(int width, int height)
	{
		Object** resizedLayer = new Object*[height];
		for (int i = 0; i < height; i++)
			resizedLayer[i] = new Object[width];

		for (int y = 0; y < Height; y++) {
			for (int x = 0; x < Width; x++) {
				if (x < width && y < height) {
					Object* ch = GetObject(x, y);
					Object copy(*ch);
					resizedLayer[y][x].SetEqual(copy, true);
				}
			}
		}

		DestroyObjects();
		Objects = resizedLayer;
		Width = width;
		Height = height;
	}
}
