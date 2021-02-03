/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include <vector>
#include "Global.h"
#include "Object.h"
#include "Position.h"

namespace TBRLGPT
{
	class Project;
	class ObjectLayer;

	class TBRLGPT_API Map
	{
	public:
		Map();
		Map(class Project* project, std::string name, int width, int height, int layerCount);
		~Map();

		void Init(class Project* project, std::string name, int width, int height, int layerCount);
		void Reset(std::string name, int width, int height, int layerCount);
		void Destroy();
		Project* GetProject();
		int GetBackColor();
		int GetWidth();
		int GetHeight();
		ObjectLayer* AddLayer();
		ObjectLayer* GetLayer(int index);
		ObjectLayer* GetTopLayer();
		int GetLayerCount();
		void SetId(std::string id);
		std::string GetId();
		void SetName(std::string name);
		std::string GetName();
		void SetBackColor(int color);
		void ClearLayer(int index);
		void ClearAllLayers();
		void DeleteLayer(int index);
		void DeleteAllLayers();
		void SetObject(Object& object, int x, int y, int layer);
		void DeleteObject(int x, int y, int layer);
		Object* GetObject(int x, int y, int layer);
		Object GetObjectCopy(int x, int y, int layer);
		void CopyObject(ObjectPosition orig, ObjectPosition dest);
		void Resize(int width, int height);
		void SetOutOfBoundsObject(Object& oob);
		Object* GetOutOfBoundsObject();
		void SetExtra(std::string extra);
		std::string GetExtra();
		std::vector<ObjectPosition> FindObjectsByProperty(std::string name, std::string value);
		ObjectPosition FindObjectByProperty(std::string name, std::string value);
		void MoveObject(ObjectPosition orig, ObjectPosition dest);
		void SwapObjects(ObjectPosition orig, ObjectPosition dest);

	private:
		class Project* Project;
		std::string Id;
		std::string Name;
		std::vector<ObjectLayer*>* Layers;
		int BackColor;
		int Width;
		int Height;
		Object* OutOfBoundsObject;
		std::string Extra;
	};
}
