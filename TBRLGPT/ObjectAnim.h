/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <vector>
#include "Global.h"
#include "ObjectChar.h"

namespace TBRLGPT
{
	class TBRLGPT_API ObjectAnim
	{
	public:
		ObjectAnim();
		~ObjectAnim();

		ObjectChar& GetFrame(int index);
		ObjectChar* GetFramePtr(int index);
		void AddFrame(ObjectChar frame);
		void AddNullFrame();
		void SetFrame(int index, ObjectChar frame);
		void RemoveFrame(int index);
		bool IsEmpty();
		int GetSize();
		void SetEqual(ObjectAnim& other);
		bool Equals(ObjectAnim& other);
		void SetNull();
		bool IsNull();
		void Clear();

	private:
		std::vector<ObjectChar> Frames;
	};
}
