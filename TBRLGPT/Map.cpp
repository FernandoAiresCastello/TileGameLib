/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "Map.h"
#include "ObjectLayer.h"
#include "ObjectChar.h"
#include "Charset.h"
#include "Palette.h"
#include "Project.h"

namespace TBRLGPT
{
	Map::Map()
	{
		Init(NULL, "", 0, 0, 0);
	}

	Map::Map(class Project* project, std::string name, int width, int height, int layerCount)
	{
		Init(project, name, width, height, layerCount);
	}

	Map::~Map()
	{
		Destroy();
	}

	void Map::Init(class Project* project, std::string name, int width, int height, int layerCount)
	{
		Project = project;
		Name = name;
		Width = width;
		Height = height;
		Layers = new std::vector<ObjectLayer*>();
		OutOfBoundsObject = new Object();

		for (int i = 0; i < layerCount; i++)
			AddLayer();
	}

	void Map::Destroy()
	{
		for (unsigned i = 0; i < Layers->size(); i++)
			delete (*Layers)[i];

		delete OutOfBoundsObject;
		delete Layers;
	}

	Project* Map::GetProject()
	{
		return Project;
	}

	int Map::GetBackColor()
	{
		return BackColor;
	}

	void Map::Reset(std::string name, int width, int height, int layerCount)
	{
		Destroy();
		Init(Project, name, width, height, layerCount);
	}

	int Map::GetWidth()
	{
		return Width;
	}

	int Map::GetHeight()
	{
		return Height;
	}

	ObjectLayer* Map::AddLayer()
	{
		ObjectLayer* layer = NULL;
		if (Width > 0 && Height > 0) {
			layer = new ObjectLayer(Width, Height);
			Layers->push_back(layer);
		}

		return layer;
	}

	ObjectLayer* Map::GetLayer(int index)
	{
		if (index >= 0 && (unsigned)index < Layers->size())
			return (*Layers)[index];

		return NULL;
	}

	ObjectLayer* Map::GetTopLayer()
	{
		return Layers->at(GetLayerCount() - 1);
	}
	
	int Map::GetLayerCount()
	{
		return (int)Layers->size();
	}

	void Map::SetId(std::string id)
	{
		Id = id;
	}

	std::string Map::GetId()
	{
		return Id;
	}

	void Map::SetName(std::string name)
	{
		Name = name;
	}

	std::string Map::GetName()
	{
		return Name;
	}

	void Map::SetBackColor(int color)
	{
		BackColor = color;
	}

	void Map::ClearLayer(int index)
	{
		GetLayer(index)->Clear();
	}

	void Map::ClearAllLayers()
	{
		for (int i = 0; i < GetLayerCount(); i++)
			ClearLayer(i);
	}

	void Map::DeleteLayer(int index)
	{
		ObjectLayer* layer = GetLayer(index);
		delete layer;
		Layers->erase(Layers->begin() + index);
	}

	void Map::DeleteAllLayers()
	{
		for (int i = 0; i < GetLayerCount(); i++)
			DeleteLayer(i);
	}

	void Map::SetObject(Object& object, int x, int y, int layer)
	{
		Layers->at(layer)->SetObject(object, x, y);
	}

	void Map::DeleteObject(int x, int y, int layer)
	{
		Layers->at(layer)->DeleteObject(x, y);
	}

	Object* Map::GetObject(int x, int y, int layer)
	{
		return Layers->at(layer)->GetObject(x, y);
	}

	Object Map::GetObjectCopy(int x, int y, int layer)
	{
		Object* o = Layers->at(layer)->GetObject(x, y);
		Object copy = Object();
		copy.SetEqual(*o, false);
		return copy;
	}

	void Map::CopyObject(ObjectPosition orig, ObjectPosition dest)
	{
		Object* o = GetObject(orig.X, orig.Y, orig.Layer);
		Layers->at(dest.Layer)->SetObject(*o, dest.X, dest.Y);
	}

	void Map::Resize(int width, int height)
	{
		Width = width;
		Height = height;

		for (int layer = 0; layer < Layers->size(); layer++)
			Layers->at(layer)->Resize(width, height);
	}

	void Map::SetOutOfBoundsObject(Object& oob)
	{
		OutOfBoundsObject->SetEqual(oob, true);
	}

	Object* Map::GetOutOfBoundsObject()
	{
		return OutOfBoundsObject;
	}

	void Map::SetExtra(std::string extra)
	{
		Extra = extra;
	}

	std::string Map::GetExtra()
	{
		return Extra;
	}

	ObjectPosition Map::FindObjectById(std::string id)
	{
		for (int layer = 0; layer < Layers->size(); layer++) {
			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					Object* o = GetObject(x, y, layer);
					if (o->GetId() == id) {
						return ObjectPosition(o, x, y, layer);
					}
				}
			}
		}

		return ObjectPosition();
	}

	std::vector<ObjectPosition> Map::FindObjectsByProperty(std::string name, std::string value)
	{
		std::vector<ObjectPosition> objects;

		for (int layer = 0; layer < Layers->size(); layer++) {
			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					Object* o = GetObject(x, y, layer);
					if (o->HasPropertyValue(name, value))
						objects.push_back(ObjectPosition(o, x, y, layer));
				}
			}
		}

		return objects;
	}

	ObjectPosition Map::FindObjectByProperty(std::string name, std::string value)
	{
		auto objs = FindObjectsByProperty(name, value);
		return objs.empty() ? ObjectPosition() : objs[0];
	}

	void Map::MoveObject(ObjectPosition orig, ObjectPosition dest)
	{
		Object origCopy = Layers->at(orig.Layer)->CopyObject(orig.X, orig.Y);
		Layers->at(dest.Layer)->SetObject(origCopy, dest.X, dest.Y);
		Layers->at(orig.Layer)->DeleteObject(orig.X, orig.Y);
	}

	void Map::SwapObjects(ObjectPosition orig, ObjectPosition dest)
	{
		Object origCopy = Layers->at(orig.Layer)->CopyObject(orig.X, orig.Y);
		Object destCopy = Layers->at(dest.Layer)->CopyObject(dest.X, dest.Y);
		Layers->at(dest.Layer)->SetObject(origCopy, dest.X, dest.Y);
		Layers->at(orig.Layer)->SetObject(destCopy, orig.X, orig.Y);
	}
}
