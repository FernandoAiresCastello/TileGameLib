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
#include "TProperties.h"

namespace TileGameLib
{
	class TTileSequence;
	class TBoard;

	class TILEGAMELIB_API TObject : TClass
	{
	public:
		TObject();
		TObject(TTile tile);
		TObject(TTileSequence tiles);
		TObject(const TObject& other);
		TObject(TCharsetIndex ch, TPaletteIndex fgc, TPaletteIndex bgc);
		~TObject();

		std::string GetId();
		int GetX();
		int GetY();
		int GetLayer();
		void AddTile(TTile tile);
		void AddTile(TCharsetIndex ch, TPaletteIndex fgc, TPaletteIndex bgc);
		void SetSingleTile(TTile tile);
		void SetSingleTile(TCharsetIndex ch, TPaletteIndex fgc, TPaletteIndex bgc);
		TTile* GetTile(int ix);
		TTile* GetSingleTile();
		bool HasTiles();
		void SetTilesEqual(TObject& other);
		void DeleteTiles();
		bool IsVisible();
		void SetVisible(bool visible);
		void Move(int dx, int dy);
		void MoveTo(int x, int y);
		void MoveTo(int x, int y, int layer);
		TProperties& GetProperties();
		void ClearProperties();
		void SetProperty(std::string prop, std::string value);
		void SetProperty(std::string prop, int value);
		std::string GetPropertyAsString(std::string prop);
		int GetPropertyAsNumber(std::string prop);
		bool HasProperty(std::string prop);
		bool HasProperty(std::string prop, std::string value);
		bool HasProperty(std::string prop, int value);
		void SetPropertiesEqual(TObject& other);
		TObject* GetObjectUnder();
		TObject* GetObjectAbove();
		TObject* GetObjectAtDistance(int dx, int dy);
		TObject* GetObjectAtDistance(int dx, int dy, int layer);

	private:
		std::string Id;
		int X;
		int Y;
		int Layer;
		bool Visible;
		TBoard* Board;
		TTileSequence* Tiles;
		TProperties Properties;

		friend TBoard;
	};
}
