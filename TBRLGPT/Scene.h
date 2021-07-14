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
		void AddObject(SceneObject* o);
		std::map<std::string, SceneObject*>& GetObjs();
		void SetBackObj(ObjectAnim& anim);
		ObjectAnim& GetBackObj();
		SceneObject* GetObjById(std::string id);
		SceneObject* GetObjAt(int x, int y, int layer);

	private:
		std::string Id;
		std::string Name;
		ObjectAnim BackObj;
		std::map<std::string, SceneObject*> Objs;
	};
}
