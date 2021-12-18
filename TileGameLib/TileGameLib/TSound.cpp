#include <SDL.h>
#include <SDL_audio.h>
#include <CppUtils.h>
#include <string>
#include <vector>
#include <cmath>
#include "TSound.h"
using namespace CppUtils;

namespace TileGameLib
{
	enum class TSoundType { Sine };

	class TSoundTone
	{
	public:
		float Freq = 0;
		int Length = 0;

		TSoundTone(float freq, int length) : Freq(freq), Length(length) {}
	};

	class TSoundStream
	{
	public:
		std::vector<TSoundTone> Tones;
		int TonePtr = 0;

		void AddTone(int freq, int length) { Tones.push_back(TSoundTone(freq, length)); }
	};

	TSoundStream MainStream;
	TSoundStream SubStream;
	bool SoundThreadRunning = false;
	bool AudioOpen = false;

	TSoundType WaveType = TSoundType::Sine;
	float WaveFreq = 0;
	float SamplingIndex = 0;
	const Sint16 Amplitude = 32000;
	const int SamplingRate = 44100;
	const int BufferSize = 1024;

	void Init();
	void ParseTones(std::string&, TSoundStream*);
	float SampleSine(float);
	void GenerateSamples(short*, int);
	void FillAudioBuffer(void*, Uint8*, int);
	int StartSoundThread(void*);
	void SoundThreadLoop();

	TSound::TSound()
	{
		Init();
	}

	TSound::~TSound()
	{
		SoundThreadRunning = false;
	}

	void TSound::PlayMainSound(std::string data)
	{
		ParseTones(data, &MainStream);
	}

	void TSound::PlaySubSound(std::string data)
	{
		ParseTones(data, &SubStream);
	}

	void TSound::StopMainSound()
	{
		MainStream.Tones.clear();
	}

	void TSound::StopSubSound()
	{
		SubStream.Tones.clear();
	}

	void Init()
	{
		SDL_Init(SDL_INIT_AUDIO);

		SDL_AudioSpec desired, returned;
		SDL_AudioDeviceID idDevice;

		SDL_zero(desired);
		desired.freq = SamplingRate;
		desired.format = AUDIO_S16SYS;
		desired.channels = 1;
		desired.samples = BufferSize;
		desired.callback = &FillAudioBuffer;

		idDevice = SDL_OpenAudioDevice(nullptr, 0, &desired, &returned, 0);

		if (idDevice > 0) {
			SDL_PauseAudioDevice(idDevice, 0);
			SDL_CreateThread(StartSoundThread, "PlayThread", nullptr);
		}
		else {
			MsgBox::Error(String::Format("Sound system failed to start:\n\n%s", SDL_GetError()));
		}
	}

	void ParseTones(std::string& data, TSoundStream* stream)
	{
		stream->TonePtr = 0;
		stream->Tones.clear();

		auto values = String::Split(String::Trim(data), ' ');
		for (int i = 0; i < values.size(); i++) {
			int freq = String::ToInt(String::Trim(values[i++]));
			int length = String::ToInt(String::Trim(values[i]));
			stream->AddTone(freq, length);
		}
	}

	int StartSoundThread(void* dummy)
	{
		SoundThreadRunning = true;
		while (SoundThreadRunning)
			SoundThreadLoop();

		return 0;
	}

	void GenerateSamples(short *stream, int length)
	{
		int samplesToWrite = length / sizeof(short);
		for (int i = 0; i < samplesToWrite; i++) {
			if (AudioOpen) {
				if (WaveType == TSoundType::Sine)
					stream[i] = (short)(Amplitude * SampleSine(SamplingIndex));
			}
			else
				stream[i] = 0;

			SamplingIndex += (WaveFreq * M_PI * 2) / SamplingRate;
			if (SamplingIndex >= (M_PI * 2))
				SamplingIndex -= M_PI * 2;
		}
	}

	float SampleSine(float index)
	{
		double result = sin(index);
		return result;
	}

	void FillAudioBuffer(void* userdata, Uint8* _stream, int len)
	{
		short* stream = reinterpret_cast<short*>(_stream);
		int length = len;
		GenerateSamples(stream, length);
	}

	void SoundThreadLoop()
	{
		bool mainStreamEmpty = MainStream.Tones.empty();
		bool subStreamEmpty = SubStream.Tones.empty();

		AudioOpen = !mainStreamEmpty || !subStreamEmpty;

		if (subStreamEmpty && !mainStreamEmpty) {
			TSoundTone* mainTone = &MainStream.Tones[MainStream.TonePtr];
			WaveFreq = mainTone->Freq;
			SDL_Delay(mainTone->Length);

			MainStream.TonePtr++;
			if (MainStream.TonePtr >= MainStream.Tones.size())
				MainStream.TonePtr = 0;
		}

		if (!subStreamEmpty) {
			TSoundTone* subTone = &SubStream.Tones[SubStream.TonePtr];
			WaveFreq = subTone->Freq;
			SDL_Delay(subTone->Length);

			SubStream.TonePtr++;
			if (SubStream.TonePtr >= SubStream.Tones.size())
				SubStream.Tones.clear();
		}
	}
}
