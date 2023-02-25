/*=============================================================================

	 C++ Utils
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <string>
#include <vector>
#include "CppGlobal.h"

namespace CppUtils
{
	class File
	{
	public:
		enum class Mode { ReadBinary, WriteBinary };

		File(std::string path, Mode mode);
		~File();

		static const std::string CurrentDirectory;
		static const std::string ParentDirectory;

		static std::vector<std::string> List(std::string directory, std::string pattern,
			bool showFolders, bool showHidden = false);

		static bool IsDirectory(std::string file);
		static bool IsCurrentDirectory(std::string file);
		static bool IsParentDirectory(std::string file);
		static bool IsRoot(std::string directory);
		static std::string GetRoot();
		static bool Exists(std::string path);
		static bool ExistsFolder(std::string path);
		static void Create(std::string path);
		static void CreateFolder(std::string path);
		static void Delete(std::string path);
		static std::string ReadText(std::string filename);
		static std::vector<std::string> ReadLines(std::string filename, std::string lineDelimiter);
		static std::vector<byte> ReadBytes(std::string filename);
		static std::vector<char> ReadChars(std::string filename);
		static void WriteText(std::string filename, std::string text);
		static void WriteLines(std::string filename, std::vector<std::string> lines);
		static void WriteBytes(std::string filename, std::vector<byte>& bytes);
		static void Duplicate(std::string orig, std::string dupl);
		static std::string GetParentDirectory(std::string file);
		static std::string GetName(std::string fullPath);
		static std::string GetCurrentExecutableFilePath();
		static std::string GetCurrentExecutableFileName(bool removeExtension = false);
		static std::string RemoveExtension(std::string file);
		static std::string GetTempDirectory();
		static std::string GetTempFilePath();

		void WriteString(std::string str);
		void WriteByte(byte b);
		void WriteShort(ushort s);
		void WriteInt(uint i);
		std::string ReadString();
		byte ReadByte();
		uint ReadInt();
		ushort ReadShort();

	private:
		FILE* Fp = nullptr;
		std::vector<byte> DataRead;
		int LengthRead = 0;
		int ReadPtr = 0;

		bool ValidRead();
	};
}
