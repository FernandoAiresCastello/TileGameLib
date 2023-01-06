/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <map>
#include <string>
#include <SDL.h>
#include "TGlobal.h"

namespace TileGameLib
{
	enum class TSoundType { Square, Sine, Noise };

	class TSoundStream;

	class TSound
	{
	public:
		static const int MinVolume = 0;
		static const int MaxVolume = 32000;

		TSound();
		~TSound();

		void SetType(TSoundType type);
		void SetVolume(int volume);
		void Beep(float freq, int length);
		void PlayMainSound(std::string data);
		void PlaySubSound(std::string data);
		void StopMainSound();
		void StopSubSound();

	private:
		std::map<std::string, float> TbFreq;

		void InitToneFreqTable();
		void ParseTones(std::string& data, TSoundStream* stream);
		std::vector<std::string> SplitTones(std::string& data);
	};
}
