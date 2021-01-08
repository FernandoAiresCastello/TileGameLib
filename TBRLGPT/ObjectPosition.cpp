/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "ObjectPosition.h"
#include "Object.h"

namespace TBRLGPT
{
	ObjectPosition::ObjectPosition() : ObjectPosition(NULL)
	{
	}

	ObjectPosition::ObjectPosition(class Object* o) : Object(o)
	{
		Invalidate();
	}

	ObjectPosition::ObjectPosition(class Object* o, int x, int y, int layer) : Object(o), X(x), Y(y), Layer(layer)
	{
	}

	ObjectPosition::ObjectPosition(int x, int y, int layer) : Object(NULL), X(x), Y(y), Layer(layer)
	{
	}

	ObjectPosition::ObjectPosition(const ObjectPosition& other) : ObjectPosition(other.Object, other.X, other.Y, other.Layer)
	{
	}

	bool ObjectPosition::IsValid()
	{
		return Object != NULL && X >= 0 && Y >= 0 && Layer >= 0;
	}

	void ObjectPosition::Invalidate()
	{
		X = -1;
		Y = -1;
		Layer = -1;
	}

	ObjectPosition ObjectPosition::Move(int dx, int dy)
	{
		return ObjectPosition(Object, X + dx, Y + dy, Layer);
	}
}
