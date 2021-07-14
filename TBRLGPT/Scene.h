/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <map>
#include <string>
#include "Global.h"
#include "ObjectAnim.h"

namespace TBRLGPT
{
	class SceneObject;

	class TBRLGPT_API Scene
	{
	public:
		Scene();
		~Scene();

		void SetId(std::string id);
		void SetName(std::string name);
		std::string GetId();
		std::string GetName();
		int GetLayerCount();
		void AddObject(SceneObject* o);
		void RemoveObject(SceneObject* o);
		void Clear();
		void ClearLayer(int layer);
		std::map<std::string, SceneObject*>& GetObjs();
		void SetBackObject(ObjectAnim& anim);
		void SetBackObject(ObjectChar chr);
		ObjectAnim& GetBackObject();
		SceneObject* GetObjectById(std::string id);
		SceneObject* GetObjectAt(int x, int y, int layer);
		std::vector<SceneObject*> GetObjectsAt(int x, int y, int layer);
		SceneObject* GetObjectByProperty(std::string prop, std::string value);
		std::vector<SceneObject*> GetObjectsByProperty(std::string prop, std::string value);
		std::vector<SceneObject*> GetObjectsInsideRegion(int x1, int y1, int x2, int y2);
		std::vector<SceneObject*> GetObjectsInsideRegion(int x1, int y1, int x2, int y2, int layer);
		std::vector<SceneObject*> GetObjectsInsideRadius(int x, int y, int radius);
		std::vector<SceneObject*> GetObjectsInsideRadius(int x, int y, int radius, int layer);

	private:
		std::string Id;
		std::string Name;
		ObjectAnim BackObject;
		std::map<std::string, SceneObject*> Objects;
		int LayerCount;

		void CalculateLayerCount();
	};
}
