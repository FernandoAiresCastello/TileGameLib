/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include <map>
#include "Global.h"
#include "ObjectChar.h"
#include "ObjectAnim.h"
#include "ObjectPosition.h"

namespace TBRLGPT
{
	class TBRLGPT_API Object
	{
	public:
		Object();
		Object(ObjectChar gfx);
		Object(const Object& other);
		~Object();

		void SetVoid(bool isVoid);
		bool IsVoid();
		void SetVisible(bool visible);
		bool IsVisible();
		void SetEqual(Object other);
		void SetAnimation(ObjectAnim& anim);
		ObjectAnim& GetAnimation();
		bool HasAnimation();
		void SetProperty(std::string name, std::string value);
		void SetProperty(std::string name, int value);
		bool HasProperty(std::string name);
		bool HasPropertyValue(std::string name, std::string value);
		bool HasPropertyValue(std::string name, int value);
		std::string GetPropertyAsString(std::string name);
		int GetPropertyAsNumber(std::string name);
		void AddToNumericProperty(std::string name, int value);
		
	private:
		bool Void;
		bool Visible;
		ObjectAnim Animation;
		std::map<std::string, std::string> Properties;

		void CopyProperties(const Object& other);
	};
}
