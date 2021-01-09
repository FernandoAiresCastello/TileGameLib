/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <vector>
#include <string>
#include <cstdio>
#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API File
	{
	public:
		static const std::string CurrentDirectory;
		static const std::string ParentDirectory;

		enum Mode {
			ReadBinary, WriteBinary
		};

		File(std::string path, Mode mode);
		~File();

		static std::vector<std::string> List(std::string directory, std::string pattern, 
			bool showFolders, bool showHidden = false);

		static bool IsDirectory(std::string file);
		static bool IsCurrentDirectory(std::string file);
		static bool IsParentDirectory(std::string file);
		static bool IsRoot(std::string directory);
		static std::string GetRoot();
		static bool Exists(std::string path);
		static void Create(std::string path);
		static void CreateFolder(std::string path);
		static void Delete(std::string path);
		static std::string ReadText(std::string filename);
		static std::vector<std::string> ReadLines(std::string filename);
		static unsigned char* Read(std::string filename, int* length);
		static void Duplicate(std::string orig, std::string dupl);
		static std::string GetParentDirectory(std::string file);
		static std::string GetName(std::string fullPath);

		void WriteString(std::string str);
		void WriteByte(byte b);
		void WriteShort(ushort s);
		void WriteInt(uint i);
		std::string ReadString();
		byte ReadByte();
		uint ReadInt();
		ushort ReadShort();

	private:
		FILE* Fp;
		unsigned char* DataRead;
		int LengthRead;
		int ReadPtr;

		bool ValidRead();
	};
}
