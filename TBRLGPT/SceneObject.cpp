/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "SceneObject.h"
#include "Scene.h"
#include "Util.h"

namespace TBRLGPT
{
	SceneObject::SceneObject()
	{
		Id = Util::RandomString(6);
		Scene = NULL;
		Obj = new Object();
		X = 0;
		Y = 0;
		Layer = 0;
	}

	SceneObject::~SceneObject()
	{
		delete Obj;
	}

	void SceneObject::SetScene(class Scene* scene)
	{
		Scene = scene;
		Scene->AddObject(this);
		Scene->CalculateLayerCount();
	}

	void SceneObject::SetId(std::string id)
	{
		Id = id;
	}

	void SceneObject::SetPosition(int x, int y, int layer)
	{
		X = x;
		Y = y;
		Layer = layer;
	}

	void SceneObject::SetPosition(int x, int y)
	{
		X = x;
		Y = y;
	}

	void SceneObject::SetX(int x)
	{
		X = x;
	}

	void SceneObject::SetY(int y)
	{
		Y = y;
	}

	void SceneObject::SetLayer(int layer)
	{
		Layer = layer;
		if (Scene != NULL)
			Scene->CalculateLayerCount();
	}

	std::string SceneObject::GetId()
	{
		return Id;
	}

	Object* SceneObject::GetObj()
	{
		return Obj;
	}

	int SceneObject::GetX()
	{
		return X;
	}

	int SceneObject::GetY()
	{
		return Y;
	}

	int SceneObject::GetLayer()
	{
		return Layer;
	}

	void SceneObject::SetEqual(SceneObject* o)
	{
		Id = Util::GenerateId();
		Obj->SetEqual(*o->Obj);
		Scene = o->Scene;
		X = o->X;
		Y = o->Y;
		Layer = o->Layer;
	}

	void SceneObject::Move(int dx, int dy)
	{
		X += dx;
		Y += dy;
	}

	bool SceneObject::CollidesInSameLayer(SceneObject* o)
	{
		return X == o->X && Y == o->Y && Layer == o->Layer;
	}

	bool SceneObject::CollidesInAnyLayer(SceneObject* o)
	{
		return X == o->X && Y == o->Y;
	}

	bool SceneObject::AlignsHorizontally(SceneObject* o)
	{
		return X == o->X;
	}

	bool SceneObject::AlignsVertically(SceneObject* o)
	{
		return Y == o->Y;
	}

	bool SceneObject::AlignsDiagonally(SceneObject* o)
	{
		return abs(X - o->X) == abs(Y - o->Y);
	}

	int SceneObject::GetDistance(SceneObject* o)
	{
		return sqrt(pow(o->X - X, 2) + pow(o->Y - Y, 2));
	}

	bool SceneObject::IsWithinDistance(SceneObject* o, int dist)
	{
		return GetDistance(o) <= dist;
	}

	bool SceneObject::IsAbove(SceneObject* o)
	{
		return X == o->X && Y == o->Y && Layer > o->Layer;
	}

	bool SceneObject::IsUnder(SceneObject* o)
	{
		return X == o->X && Y == o->Y && Layer < o->Layer;
	}

	SceneObject* SceneObject::Above()
	{
		return Scene->GetObjectAt(X, Y, Layer + 1);
	}

	SceneObject* SceneObject::Under()
	{
		return Scene->GetObjectAt(X, Y, Layer - 1);
	}

	SceneObject* SceneObject::AtDistance(int dx, int dy)
	{
		return AtDistance(dx, dy, Layer);
	}

	SceneObject* SceneObject::AtDistance(int dx, int dy, int layer)
	{
		return Scene->GetObjectAt(X + dx, Y + dy, layer);
	}

	SceneObject* SceneObject::AtDistanceAbove(int dx, int dy)
	{
		return AtDistance(dx, dy, Layer + 1);
	}

	SceneObject* SceneObject::AtDistanceUnder(int dx, int dy)
	{
		return AtDistance(dx, dy, Layer - 1);
	}
}
