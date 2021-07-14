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
	SceneObject::SceneObject() : SceneObject(NULL)
	{
	}

	SceneObject::SceneObject(class Scene* scene)
	{
		Id = Util::GenerateId();
		Scene = scene;
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

	void SceneObject::Move(int dx, int dy)
	{
		X += dx;
		Y += dy;
	}
}
