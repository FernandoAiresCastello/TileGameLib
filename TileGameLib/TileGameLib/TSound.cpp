#include <SDL.h>
#include <SDL_audio.h>
#include <CppUtils.h>
#include <map>
#include <string>
#include <vector>
#include <cmath>
#include "TSound.h"
using namespace CppUtils;

namespace TileGameLib
{
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

		void AddTone(float freq, int length) { Tones.push_back(TSoundTone(freq, length)); }
	};

	TSoundStream MainStream;
	TSoundStream SubStream;
	bool SoundThreadRunning = false;
	bool AudioOpen = false;

	std::map<std::string, float> TbFreq;

	TSoundType WaveType = TSoundType::Square;
	float WaveFreq = 0;
	float SamplingIndex = 0;
	int SquareWavePeak = 1;
	const Sint16 Amplitude = 32000;
	const int SamplingRate = 44100;
	const int BufferSize = 8;
	
	void Init();
	void InitToneFreqTable();
	void ParseTones(std::string&, TSoundStream*);
	void GenerateSamples(short*, int);
	void GenerateSilenceSamples(short*, int);
	void GenerateSineSamples(short*, int);
	void GenerateSquareSamples(short*, int);
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

	void TSound::SetType(TSoundType type)
	{
		WaveType = type;
	}

	void TSound::Beep(float freq, int length)
	{
		SubStream.TonePtr = 0;
		SubStream.Tones.clear();
		SubStream.AddTone(freq, length);
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

	void InitToneFreqTable()
	{
		TbFreq["C0"] = 16.35;
		TbFreq["C#0"] = 17.32;
		TbFreq["D0"] = 18.35;
		TbFreq["D#0"] = 19.45;
		TbFreq["E0"] = 20.6;
		TbFreq["F0"] = 21.83;
		TbFreq["F#0"] = 23.12;
		TbFreq["G0"] = 24.5;
		TbFreq["G#0"] = 25.96;
		TbFreq["A0"] = 27.5;
		TbFreq["A#0"] = 29.14;
		TbFreq["B0"] = 30.87;
		TbFreq["C1"] = 32.7;
		TbFreq["C#1"] = 34.65;
		TbFreq["D1"] = 36.71;
		TbFreq["D#1"] = 38.89;
		TbFreq["E1"] = 41.2;
		TbFreq["F1"] = 43.65;
		TbFreq["F#1"] = 46.25;
		TbFreq["G1"] = 49;
		TbFreq["G#1"] = 51.91;
		TbFreq["A1"] = 55;
		TbFreq["A#1"] = 58.27;
		TbFreq["B1"] = 61.74;
		TbFreq["C2"] = 65.41;
		TbFreq["C#2"] = 69.3;
		TbFreq["D2"] = 73.42;
		TbFreq["D#2"] = 77.78;
		TbFreq["E2"] = 82.41;
		TbFreq["F2"] = 87.31;
		TbFreq["F#2"] = 92.5;
		TbFreq["G2"] = 98;
		TbFreq["G#2"] = 103.83;
		TbFreq["A2"] = 110;
		TbFreq["A#2"] = 116.54;
		TbFreq["B2"] = 123.47;
		TbFreq["C3"] = 130.81;
		TbFreq["C#3"] = 138.59;
		TbFreq["D3"] = 146.83;
		TbFreq["D#3"] = 155.56;
		TbFreq["E3"] = 164.81;
		TbFreq["F3"] = 174.61;
		TbFreq["F#3"] = 185;
		TbFreq["G3"] = 196;
		TbFreq["G#3"] = 207.65;
		TbFreq["A3"] = 220;
		TbFreq["A#3"] = 233.08;
		TbFreq["B3"] = 246.94;
		TbFreq["C4"] = 261.63;
		TbFreq["C#4"] = 277.18;
		TbFreq["D4"] = 293.66;
		TbFreq["D#4"] = 311.13;
		TbFreq["E4"] = 329.63;
		TbFreq["F4"] = 349.23;
		TbFreq["F#4"] = 369.99;
		TbFreq["G4"] = 392;
		TbFreq["G#4"] = 415.3;
		TbFreq["A4"] = 440;
		TbFreq["A#4"] = 466.16;
		TbFreq["B4"] = 493.88;
		TbFreq["C5"] = 523.25;
		TbFreq["C#5"] = 554.37;
		TbFreq["D5"] = 587.33;
		TbFreq["D#5"] = 622.25;
		TbFreq["E5"] = 659.25;
		TbFreq["F5"] = 698.46;
		TbFreq["F#5"] = 739.99;
		TbFreq["G5"] = 783.99;
		TbFreq["G#5"] = 830.61;
		TbFreq["A5"] = 880;
		TbFreq["A#5"] = 932.33;
		TbFreq["B5"] = 987.77;
		TbFreq["C6"] = 1046.5;
		TbFreq["C#6"] = 1108.73;
		TbFreq["D6"] = 1174.66;
		TbFreq["D#6"] = 1244.51;
		TbFreq["E6"] = 1318.51;
		TbFreq["F6"] = 1396.91;
		TbFreq["F#6"] = 1479.98;
		TbFreq["G6"] = 1567.98;
		TbFreq["G#6"] = 1661.22;
		TbFreq["A6"] = 1760;
		TbFreq["A#6"] = 1864.66;
		TbFreq["B6"] = 1975.53;
		TbFreq["C7"] = 2093;
		TbFreq["C#7"] = 2217.46;
		TbFreq["D7"] = 2349.32;
		TbFreq["D#7"] = 2489.02;
		TbFreq["E7"] = 2637.02;
		TbFreq["F7"] = 2793.83;
		TbFreq["F#7"] = 2959.96;
		TbFreq["G7"] = 3135.96;
		TbFreq["G#7"] = 3322.44;
		TbFreq["A7"] = 3520;
		TbFreq["A#7"] = 3729.31;
		TbFreq["B7"] = 3951.07;
		TbFreq["C8"] = 4186.01;
		TbFreq["C#8"] = 4434.92;
		TbFreq["D8"] = 4698.63;
		TbFreq["D#8"] = 4978.03;
		TbFreq["E8"] = 5274.04;
		TbFreq["F8"] = 5587.65;
		TbFreq["F#8"] = 5919.91;
		TbFreq["G8"] = 6271.93;
		TbFreq["G#8"] = 6644.88;
		TbFreq["A8"] = 7040;
		TbFreq["A#8"] = 7458.62;
		TbFreq["B8"] = 7902.13;
	}

	void Init()
	{
		InitToneFreqTable();
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
			float freq = TbFreq[String::Trim(values[i++])];
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

	void GenerateSamples(short* stream, int length)
	{
		const int count = length / sizeof(short);

		if (AudioOpen) {
			if (WaveType == TSoundType::Sine)
				GenerateSineSamples(stream, count);
			else if (WaveType == TSoundType::Square)
				GenerateSquareSamples(stream, count);
		}
		else {
			GenerateSilenceSamples(stream, count);
		}
	}

	void GenerateSilenceSamples(short* stream, int count)
	{
		for (int i = 0; i < count; i++)
			stream[i] = 0;
	}

	void GenerateSineSamples(short* stream, int count)
	{
		for (int i = 0; i < count; i++) {
			short value = (short)(Amplitude * sin(SamplingIndex));
			stream[i] = value;
			SamplingIndex += (WaveFreq * M_PI * 2) / SamplingRate;
			if (SamplingIndex >= (M_PI * 2))
				SamplingIndex -= M_PI * 2;
		}
	}

	void GenerateSquareSamples(short* stream, int count)
	{
		for (int i = 0; i < count; i++) {
			short value = Amplitude * SquareWavePeak;
			stream[i] = value;
			SamplingIndex += (WaveFreq * M_PI * 2) / SamplingRate;
			if (SamplingIndex >= (M_PI * 2)) {
				SamplingIndex -= M_PI * 2;
				SquareWavePeak = -SquareWavePeak;
			}
		}
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
