/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "Scene.h"
#include "SceneObject.h"

namespace TBRLGPT
{
	Scene::Scene()
	{
		Id = "";
		Name = "";
		BackObj.SetNull();
	}

	Scene::~Scene()
	{
		for (auto it = Objs.begin(); it != Objs.end(); ++it) {
			delete it->second;
			it->second = NULL;
		}
		Objs.clear();
	}

	void Scene::SetId(std::string id)
	{
		Id = id;
	}

	void Scene::SetName(std::string name)
	{
		Name = name;
	}

	std::string Scene::GetId()
	{
		return Id;
	}

	std::string Scene::GetName()
	{
		return Name;
	}

	void Scene::AddObject(SceneObject* o)
	{
		o->SetScene(this);
		Objs[o->GetId()] = o;
	}

	std::map<std::string, SceneObject*>& Scene::GetObjs()
	{
		return Objs;
	}

	void Scene::SetBackObj(ObjectAnim& anim)
	{
		BackObj.SetEqual(anim);
	}

	ObjectAnim& Scene::GetBackObj()
	{
		return BackObj;
	}

	SceneObject* Scene::GetObjById(std::string id)
	{
		return Objs[id];
	}

	SceneObject* Scene::GetObjAt(int x, int y, int layer)
	{
		for (auto it = Objs.begin(); it != Objs.end(); ++it) {
			SceneObject* o = it->second;
			if (o->GetX() == x && o->GetY() == y && o->GetLayer() == layer) {
				return o;
			}
		}

		return NULL;
	}
}
