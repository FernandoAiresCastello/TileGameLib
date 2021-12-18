/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include "TGlobal.h"

namespace TileGameLib
{
	enum class TSoundType { Square, Sine };

	class TSound
	{
	public:
		TSound();
		~TSound();

		void SetType(TSoundType type);
		void Beep(float freq, int length);
		void PlayMainSound(std::string data);
		void PlaySubSound(std::string data);
		void StopMainSound();
		void StopSubSound();
	};
}
