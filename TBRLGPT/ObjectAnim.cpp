/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "ObjectAnim.h"

namespace TBRLGPT
{
	ObjectAnim::ObjectAnim()
	{
		SetNull();
	}

	ObjectAnim::~ObjectAnim()
	{
	}

	ObjectChar& ObjectAnim::GetFrame(int index)
	{
		int i = index % Frames.size();
		return Frames[i];
	}

	ObjectChar* ObjectAnim::GetFramePtr(int index)
	{
		if (index >= 0 && index < Frames.size())
			return &(Frames[index]);

		return NULL;
	}

	void ObjectAnim::AddFrame(ObjectChar frame)
	{
		Frames.push_back(frame);
	}

	void ObjectAnim::AddNullFrame()
	{
		Frames.push_back(ObjectChar());
	}

	void ObjectAnim::SetFrame(int index, ObjectChar frame)
	{
		if (index >= 0 && index < Frames.size())
			Frames[index] = frame;
	}

	void ObjectAnim::RemoveFrame(int index)
	{
		if (GetSize() > 1 && index >= 0 && index < Frames.size())
			Frames.erase(Frames.begin() + index);
	}

	bool ObjectAnim::IsEmpty()
	{
		return Frames.empty();
	}

	int ObjectAnim::GetSize()
	{
		return Frames.size();
	}

	void ObjectAnim::SetEqual(ObjectAnim& other)
	{
		Frames.clear();
		for (unsigned i = 0; i < other.GetSize(); i++)
			AddFrame(other.GetFrame(i));
	}

	bool ObjectAnim::Equals(ObjectAnim& other)
	{
		if (GetSize() != other.GetSize())
			return false;

		for (unsigned i = 0; i < Frames.size(); i++)
			if (!other.Frames[i].Equals(Frames[i]))
				return false;

		return true;
	}

	void ObjectAnim::SetNull()
	{
		Frames.clear();
		AddNullFrame();
	}

	bool ObjectAnim::IsNull()
	{
		return IsEmpty() || Frames[0].IsNull();
	}

	void ObjectAnim::Clear()
	{
		Frames.clear();
	}
}
