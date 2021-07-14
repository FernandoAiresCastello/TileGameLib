/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include "Global.h"
#include "Object.h"

namespace TBRLGPT
{
	class Scene;

	class TBRLGPT_API SceneObject
	{
	public:
		SceneObject();
		SceneObject(class Scene* scene);
		~SceneObject();

		void SetScene(class Scene* scene);
		void SetId(std::string id);
		void SetPosition(int x, int y, int layer);
		void SetPosition(int x, int y);
		void SetX(int x);
		void SetY(int y);
		void SetLayer(int layer);
		std::string GetId();
		Object* GetObj();
		int GetX();
		int GetY();
		int GetLayer();
		void SetEqual(SceneObject* o);
		void Move(int dx, int dy);
		bool CollidesInSameLayer(SceneObject* o);
		bool CollidesInAnyLayer(SceneObject* o);
		bool AlignsHorizontally(SceneObject* o);
		bool AlignsVertically(SceneObject* o);
		bool AlignsDiagonally(SceneObject* o);
		int GetDistance(SceneObject* o);
		bool IsWithinDistance(SceneObject* o, int dist);
		bool IsAbove(SceneObject* o);
		bool IsUnder(SceneObject* o);
		SceneObject* Above();
		SceneObject* Under();
		SceneObject* AtDistance(int dx, int dy);
		SceneObject* AtDistance(int dx, int dy, int layer);
		SceneObject* AtDistanceAbove(int dx, int dy);
		SceneObject* AtDistanceUnder(int dx, int dy);

	private:
		std::string Id;
		class Scene* Scene;
		Object* Obj;
		int X;
		int Y;
		int Layer;
	};
}
