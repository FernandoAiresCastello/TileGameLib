#pragma once
#include <string>
#include <unordered_map>
#include "TGlobal.h"

namespace TGL_Internal
{
	class TSoundFiles
	{
	public:
		TSoundFiles();
		~TSoundFiles();

		void Load(std::string id, std::string file);
		void Play(std::string id, bool async);
		
	private:
		std::unordered_map<std::string, std::string> Files; // id -> file_path
		unsigned int AvailableFileNumber = 0;

		void CloseAll();
		bool Exists(std::string id);
		void ShowError(unsigned long error);
	};
};
