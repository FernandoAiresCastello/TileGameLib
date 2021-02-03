/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "ObjectController.h"
#include "ObjectPosition.h"
#include "Object.h"
#include "Map.h"

namespace TBRLGPT
{
	ObjectController::ObjectController(class Map* map, int x, int y, int layer) : Map(map), X(x), Y(y), Layer(layer)
	{
	}

	ObjectController::ObjectController(class Map* map, std::string objId) : Map(map)
	{
		ObjectPosition op = map->FindObjectById(objId);
		X = op.X;
		Y = op.Y;
		Layer = op.Layer;
	}

	ObjectController::ObjectController(class Map* map, std::string objPropertyName, std::string objPropertyValue) : Map(map)
	{
		ObjectPosition op = map->FindObjectByProperty(objPropertyName, objPropertyValue);
		X = op.X;
		Y = op.Y;
		Layer = op.Layer;
	}

	ObjectController::~ObjectController()
	{
	}

	Object* ObjectController::GetObject()
	{
		return Map->GetObject(X, Y, Layer);
	}

	ObjectPosition ObjectController::GetPosition()
	{
		return ObjectPosition(Map->GetObject(X, Y, Layer), X, Y, Layer);
	}

	int ObjectController::GetX()
	{
		return X;
	}

	int ObjectController::GetY()
	{
		return Y;
	}

	int ObjectController::GetLayer()
	{
		return Layer;
	}

	void ObjectController::MoveTo(int x, int y)
	{
		MoveTo(x, y, Layer);
	}

	void ObjectController::MoveTo(int x, int y, int layer)
	{
		Map->MoveObject(GetPosition(), ObjectPosition(x, y, layer));

		X = x;
		Y = y;
		Layer = layer;
	}

	void ObjectController::MoveDist(int dx, int dy)
	{
		Map->MoveObject(GetPosition(), GetPosition().Move(dx, dy));

		X += dx;
		Y += dy;
	}

	void ObjectController::CopyTo(int x, int y)
	{
		CopyTo(x, y, Layer);
	}

	void ObjectController::CopyTo(int x, int y, int layer)
	{
		Map->CopyObject(GetPosition(), ObjectPosition(x, y, layer));
	}

	void ObjectController::CopyDist(int dx, int dy)
	{
		Map->CopyObject(GetPosition(), GetPosition().Move(dx, dy));
	}

	void ObjectController::RemoveSelf()
	{
		Map->DeleteObject(X, Y, Layer);
	}

	void ObjectController::RemoveOther(ObjectController* other)
	{
		Map->DeleteObject(other->X, other->Y, other->Layer);
	}

	ObjectPosition ObjectController::Above()
	{
		return ObjectPosition(Map->GetObject(X, Y, Layer + 1), X, Y, Layer + 1);
	}

	ObjectPosition ObjectController::Under()
	{
		return ObjectPosition(Map->GetObject(X, Y, Layer - 1), X, Y, Layer - 1);
	}

	ObjectPosition ObjectController::AtDistance(int dx, int dy)
	{
		return AtDistance(dx, dy, Layer);
	}

	ObjectPosition ObjectController::AtDistance(int dx, int dy, int layer)
	{
		return ObjectPosition(Map->GetObject(X + dx, Y + dy, layer), X + dx, Y + dy, layer);
	}

	ObjectPosition ObjectController::AtDistanceAbove(int dx, int dy)
	{
		return ObjectPosition(Map->GetObject(X + dx, Y + dy, Layer + 1), X + dx, Y + dy, Layer + 1);
	}

	ObjectPosition ObjectController::AtDistanceUnder(int dx, int dy)
	{
		return ObjectPosition(Map->GetObject(X + dx, Y + dy, Layer - 1), X + dx, Y + dy, Layer - 1);
	}

	int ObjectController::GetDistance(int x, int y)
	{
		return sqrt(pow(x - X, 2) + pow(y - Y, 2));
	}

	int ObjectController::GetDistance(ObjectController* other)
	{
		return GetDistance(other->X, other->Y);
	}

	bool ObjectController::IsAbove(ObjectController* other)
	{
		return X == other->X && Y == other->Y && Layer > other->Layer;
	}

	bool ObjectController::IsUnder(ObjectController* other)
	{
		return X == other->X && Y == other->Y && Layer < other->Layer;
	}
}
