/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <map>
#include <string>
#include "TGlobal.h"
#include "TClass.h"
#include "TTile.h"
#include "TTileSequence.h"

namespace TileGameLib
{
	class TTileSequence;
	class TBoard;

	class TILEGAMELIB_API TObject : TClass
	{
	public:
		TObject(TTile tile);
		TObject(TTileSequence tiles);
		TObject(const TObject& other);
		TObject(TCharsetIndex ch, TPaletteIndex fgc, TPaletteIndex bgc);
		~TObject();

		std::string GetId();
		int GetX();
		int GetY();
		int GetLayer();
		void SetSingleTile(TTile tile);
		void SetSingleTile(TCharsetIndex ch, TPaletteIndex fgc, TPaletteIndex bgc);
		TTile* GetTile(int ix);
		TTile* GetSingleTile();
		void SetTilesEqual(TObject& other);
		void SetPropertiesEqual(TObject& other);
		bool IsVisible();
		void SetVisible(bool visible);
		void SetProperty(std::string prop, std::string value);
		void SetProperty(std::string prop, int value);
		std::string GetPropertyAsString(std::string prop);
		int GetPropertyAsNumber(std::string prop);
		bool HasProperty(std::string prop);
		bool HasProperty(std::string prop, std::string value);
		bool HasProperty(std::string prop, int value);
		void Move(int dx, int dy);
		void MoveTo(int x, int y);
		void MoveTo(int x, int y, int layer);

	private:
		std::string Id;
		int X;
		int Y;
		int Layer;
		TTileSequence* Tiles;
		TBoard* Board;
		bool Visible;

		struct PropertyValue {
			std::string String;
			int Number;
		};
		std::map<std::string, PropertyValue> Properties;

		friend TBoard;
	};
}
