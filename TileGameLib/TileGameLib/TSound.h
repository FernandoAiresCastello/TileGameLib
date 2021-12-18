/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include "TGlobal.h"

namespace TileGameLib
{
	class TSound
	{
	public:
		TSound();
		~TSound();

		void PlayMainSound(std::string data);
		void PlaySubSound(std::string data);
		void StopMainSound();
		void StopSubSound();
	};
}
