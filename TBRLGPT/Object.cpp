/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "Object.h"
#include "StringUtils.h"

namespace TBRLGPT
{
	Object::Object()
	{
		SetVoid(true);
	}

	Object::Object(ObjectChar gfx)
	{
		Id = "";
		Void = false;
		Visible = true;
		Animation.SetFrame(0, gfx);
	}

	Object::Object(const Object& other)
	{
		Id = other.Id;
		Void = other.Void;
		Visible = other.Visible;
		ObjectAnim anim = other.Animation;
		Animation.SetEqual(anim);
		CopyProperties(other);
	}

	Object::~Object()
	{
	}

	void Object::SetId(std::string id)
	{
		Id = id;
	}

	std::string Object::GetId()
	{
		return Id;
	}

	void Object::SetVisible(bool visible)
	{
		Visible = visible;
	}

	void Object::SetAnimation(ObjectAnim& anim)
	{
		Animation.SetEqual(anim);
	}

	void Object::SetProperty(std::string name, std::string value)
	{
		Properties[name] = value;
	}

	void Object::SetProperty(std::string name, int value)
	{
		Properties[name] = String::ToString(value);
	}

	std::string Object::GetPropertyAsString(std::string name)
	{
		return Properties[name];
	}

	int Object::GetPropertyAsNumber(std::string name)
	{
		std::string value = GetPropertyAsString(name);
		return String::IsNumber(value) ? String::ToInt(value) : 0;
	}

	void Object::AddToNumericProperty(std::string name, int value)
	{
		std::string currentStringValue = GetPropertyAsString(name);
		if (String::IsNumber(currentStringValue)) {
			int currentNumber = String::ToInt(currentStringValue);
			int updatedNumber = currentNumber + value;
			SetProperty(name, String::ToString(updatedNumber));
		}
	}

	ObjectAnim& Object::GetAnimation()
	{
		return Animation;
	}

	bool Object::HasProperty(std::string name)
	{
		return Properties.find(name) != Properties.end();
	}

	bool Object::HasPropertyValue(std::string name, std::string value)
	{
		return HasProperty(name) && Properties[name] == value;
	}

	bool Object::HasPropertyValue(std::string name, int value)
	{
		return HasProperty(name) && Properties[name] == String::ToString(value);
	}

	bool Object::IsVisible()
	{
		return Visible;
	}

	void Object::SetVoid(bool void_)
	{
		Void = void_;
		if (void_) {
			Id = "";
			Void = true;
			Visible = true;
			Animation.Clear();
			Properties.clear();
		}
	}

	bool Object::IsVoid()
	{
		return Void;
	}

	void Object::SetEqual(Object other, bool copyId)
	{
		Void = other.Void;
		Visible = other.Visible;
		Animation.SetEqual(other.Animation);
		CopyProperties(other);

		if (copyId)
			Id = other.Id;
	}

	void Object::CopyProperties(const Object& other)
	{
		Properties.clear();
		auto it = other.Properties.begin();
		while (it != other.Properties.end()) {
			std::string key = it->first;
			std::string value = it->second;
			Properties[key] = value;
			it++;
		}
	}

	bool Object::HasAnimation()
	{
		return !Animation.IsEmpty();
	}
}
