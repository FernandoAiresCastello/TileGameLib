/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include "Global.h"

namespace TBRLGPT
{
	class Map;
	class Object;
	class ObjectPosition;

	class TBRLGPT_API ObjectController
	{
	public:
		ObjectController(class Map* map, int x, int y, int layer);
		ObjectController(class Map* map, std::string objId);
		ObjectController(class Map* map, std::string objPropertyName, std::string objPropertyValue);
		virtual ~ObjectController();

		Object* GetObject();
		ObjectPosition GetPosition();
		int GetX();
		int GetY();
		int GetLayer();
		void MoveTo(int x, int y);
		void MoveTo(int x, int y, int layer);
		void MoveDist(int dx, int dy);
		void CopyTo(int x, int y);
		void CopyTo(int x, int y, int layer);
		void CopyDist(int dx, int dy);
		void RemoveSelf();
		void RemoveOther(ObjectController* other);
		ObjectPosition Above();
		ObjectPosition Under();
		ObjectPosition AtDistance(int dx, int dy);
		ObjectPosition AtDistance(int dx, int dy, int layer);
		ObjectPosition AtDistanceAbove(int dx, int dy);
		ObjectPosition AtDistanceUnder(int dx, int dy);
		int GetDistance(int x, int y);
		int GetDistance(ObjectController* other);
		bool IsAbove(ObjectController* other);
		bool IsUnder(ObjectController* other);

	private:
		class Map* Map;
		int X;
		int Y;
		int Layer;
	};
}
