/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "Scene.h"
#include "SceneObject.h"
#include "Util.h"

namespace TBRLGPT
{
	Scene::Scene()
	{
		Id = Util::RandomString(6);
		Name = "New Scene";
		BackObject.SetNull();
		LayerCount = 0;
	}

	Scene::~Scene()
	{
		Clear();
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

	int Scene::GetLayerCount()
	{
		return LayerCount;
	}

	void Scene::CalculateLayerCount()
	{
		int topmostLayer = 0;
		for (auto it = Objects.begin(); it != Objects.end(); ++it) {
			SceneObject* o = it->second;
			if (o->GetLayer() > topmostLayer) {
				topmostLayer = o->GetLayer();
			}
		}

		LayerCount = topmostLayer + 1;
	}

	void Scene::AddObject(SceneObject* o)
	{
		o->SetScene(this);
		Objects[o->GetId()] = o;
		CalculateLayerCount();
	}

	void Scene::RemoveObject(SceneObject* o)
	{
		for (auto it = Objects.begin(); it != Objects.end(); ++it) {
			SceneObject* currentObj = it->second;
			if (currentObj == o) {
				delete currentObj;
				currentObj = NULL;
				Objects.erase(it);
				return;
			}
		}
		CalculateLayerCount();
	}

	void Scene::Clear()
	{
		for (auto it = Objects.begin(); it != Objects.end(); ++it) {
			delete it->second;
			it->second = NULL;
		}
		Objects.clear();
		CalculateLayerCount();
	}

	void Scene::ClearLayer(int layer)
	{
		for (auto it = Objects.cbegin(); it != Objects.cend(); ) {
			if (it->second->GetLayer() == layer) {
				delete it->second;
				Objects.erase(it++);
			}
			else {
				++it;
			}
		}
		CalculateLayerCount();
	}

	std::map<std::string, SceneObject*>& Scene::GetObjs()
	{
		return Objects;
	}

	void Scene::SetBackObject(ObjectAnim& anim)
	{
		BackObject.SetEqual(anim);
	}

	void Scene::SetBackObject(ObjectChar chr)
	{
		BackObject.Clear();
		BackObject.AddFrame(chr);
	}

	ObjectAnim& Scene::GetBackObject()
	{
		return BackObject;
	}

	SceneObject* Scene::GetObjectById(std::string id)
	{
		return Objects[id];
	}

	SceneObject* Scene::GetObjectAt(int x, int y, int layer)
	{
		for (auto it = Objects.begin(); it != Objects.end(); ++it) {
			SceneObject* o = it->second;
			if (o->GetX() == x && o->GetY() == y && o->GetLayer() == layer) {
				return o;
			}
		}

		return NULL;
	}

	std::vector<SceneObject*> Scene::GetObjectsAt(int x, int y, int layer)
	{
		std::vector<SceneObject*> objs;

		for (auto it = Objects.begin(); it != Objects.end(); ++it) {
			SceneObject* o = it->second;
			if (o->GetX() == x && o->GetY() == y && o->GetLayer() == layer) {
				objs.push_back(o);
			}
		}

		return objs;
	}

	SceneObject* Scene::GetObjectByProperty(std::string prop, std::string value)
	{
		for (auto it = Objects.begin(); it != Objects.end(); ++it) {
			Object* o = it->second->GetObj();
			if (o->HasPropertyValue(prop, value)) {
				return it->second;
			}
		}

		return NULL;
	}

	std::vector<SceneObject*> Scene::GetObjectsByProperty(std::string prop, std::string value)
	{
		std::vector<SceneObject*> objs;

		for (auto it = Objects.begin(); it != Objects.end(); ++it) {
			Object* o = it->second->GetObj();
			if (o->HasPropertyValue(prop, value)) {
				objs.push_back(it->second);
			}
		}

		return objs;
	}

	std::vector<SceneObject*> Scene::GetObjectsInsideRegion(int x1, int y1, int x2, int y2)
	{
		std::vector<SceneObject*> objs;

		for (auto it = Objects.begin(); it != Objects.end(); ++it) {
			SceneObject* o = it->second;
			if (o->GetX() >= x1 && o->GetY() >= y1 && o->GetX() <= x2 && o->GetY() <= y2) {
				objs.push_back(it->second);
			}
		}

		return objs;
	}

	std::vector<SceneObject*> Scene::GetObjectsInsideRegion(int x1, int y1, int x2, int y2, int layer)
	{
		std::vector<SceneObject*> objs;

		for (auto it = Objects.begin(); it != Objects.end(); ++it) {
			SceneObject* o = it->second;
			if (o->GetLayer() == layer && o->GetX() >= x1 && o->GetY() >= y1 && o->GetX() <= x2 && o->GetY() <= y2) {
				objs.push_back(it->second);
			}
		}

		return objs;
	}

	std::vector<SceneObject*> Scene::GetObjectsInsideRadius(int x, int y, int radius)
	{
		int x1 = x - radius;
		int y1 = y - radius;
		int x2 = x + radius;
		int y2 = y + radius;

		return GetObjectsInsideRegion(x1, y1, x2, y2);
	}

	std::vector<SceneObject*> Scene::GetObjectsInsideRadius(int x, int y, int radius, int layer)
	{
		int x1 = x - radius;
		int y1 = y - radius;
		int x2 = x + radius;
		int y2 = y + radius;

		return GetObjectsInsideRegion(x1, y1, x2, y2, layer);
	}
}
