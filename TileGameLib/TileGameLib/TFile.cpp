/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include <Windows.h>
#include <iostream>
#include <fstream>
#include <CppUtils.h>
#include "TFile.h"

using namespace CppUtils;

namespace TileGameLib
{
	const std::string TFile::CurrentDirectory = "./";
	const std::string TFile::ParentDirectory = "../";

	TFile::TFile(std::string path, Mode mode)
	{
		Fp = fopen(path.c_str(), mode == ReadBinary ? "rb" : "wb");
		LengthRead = 0;
		DataRead = mode == ReadBinary ? TFile::ReadBytes(path, &LengthRead) : NULL;
		ReadPtr = 0;
	}

	TFile::~TFile()
	{
		if (Fp) {
			fflush(Fp);
			fclose(Fp);
		}
	}

	std::vector<std::string> TFile::List(std::string directory, std::string pattern,
		bool showFolders, bool showHidden)
	{
		if (pattern.empty())
			pattern = "*";

		std::vector<std::string> files;
		std::string path = directory + "\\" + pattern;
		WIN32_FIND_DATA data;
		HANDLE hFind = FindFirstFile(path.c_str(), &data);

		if (hFind != INVALID_HANDLE_VALUE) {
			do {
				if ((data.dwFileAttributes & FILE_ATTRIBUTE_HIDDEN) && !showHidden)
					continue;
				if ((data.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) && showFolders) {
					std::string dir = data.cFileName;
					if (dir != ".")
						files.push_back(dir + "/");
				}
				else
					files.push_back(data.cFileName);
			}
			while (FindNextFile(hFind, &data));
			FindClose(hFind);
		}

		return files;
	}

	bool TFile::IsDirectory(std::string file)
	{
		return String::EndsWith(file, "/");
	}

	bool TFile::IsCurrentDirectory(std::string file)
	{
		return file == "./";
	}

	bool TFile::IsParentDirectory(std::string file)
	{
		return file == "../";
	}

	bool TFile::IsRoot(std::string directory)
	{
		std::vector<std::string> files = TFile::List(directory, "*", true);
		for (unsigned i = 0; i < files.size(); i++) {
			if (files[i] == "../")
				return false;
		}
		return true;
	}

	std::string TFile::GetRoot()
	{
		return "C:/";
	}

	bool TFile::Exists(std::string path)
	{
		struct stat buffer;
		return (stat(path.c_str(), &buffer) == 0);
	}

	bool TFile::ExistsFolder(std::string path)
	{
		struct stat buffer;
		stat(path.c_str(), &buffer);
		return (buffer.st_mode & S_IFDIR);
	}

	void TFile::Create(std::string path)
	{
		unsigned pos = 0;
		do {
			pos = path.find_first_of("\\/", pos + 1);
			if (pos == std::string::npos)
				break;

			CreateDirectory(path.substr(0, pos).c_str(), NULL);
		}
		while (pos != std::string::npos);
		
		std::fstream fs;
		fs.open(path, std::ios::out);
		fs.close();
	}

	void TFile::CreateFolder(std::string path)
	{
		CreateDirectory(path.c_str(), NULL);
	}

	void TFile::Delete(std::string path)
	{
		DeleteFile(path.c_str());
	}

	std::string TFile::ReadText(std::string filename)
	{
		int length = 0;
		std::string text = std::string((const char*)ReadBytes(filename, &length), length);
		return text;
	}

	std::vector<std::string> TFile::ReadLines(std::string filename)
	{
		std::string file = String::Replace(ReadText(filename), "\r", "");
		return String::Split(file, '\n', false);
	}

	std::vector<int> TFile::ReadBytes(std::string filename)
	{
		std::vector<int> bytes;
		int length = -1;
		unsigned char* data = TFile::ReadBytes(filename, &length);
		for (int i = 0; i < length; i++) {
			bytes.push_back(data[i]);
		}
		return bytes;
	}

	unsigned char* TFile::ReadBytes(std::string filename, int* length)
	{
		std::ifstream ifs(filename, std::ios::binary | std::ios::ate);

		if (ifs.good()) {
			*length = (int)ifs.tellg();
			char *data = new char[*length];
			ifs.seekg(0, std::ios::beg);
			ifs.read(data, *length);
			ifs.close();
			return (unsigned char*)data;
		}

		*length = -1;
		return NULL;
	}

	void TFile::WriteText(std::string filename, std::string text)
	{
		std::ofstream ofs(filename);

		if (ofs.good()) {
			ofs.write(text.c_str(), text.length());
		}

		ofs.flush();
		ofs.close();
	}

	void TFile::WriteLines(std::string filename, std::vector<std::string> lines)
	{
		std::ofstream ofs(filename);

		if (ofs.good()) {
			for (int i = 0; i < lines.size(); i++) {
				std::string line = lines[i];
				line.append("\n");
				ofs.write(line.c_str(), line.length());
			}
		}

		ofs.flush();
		ofs.close();
	}

	void TFile::WriteBytes(std::string filename, std::vector<int>& bytes)
	{
		TFile file(filename, Mode::WriteBinary);
		for (auto& byte : bytes)
			file.WriteByte(byte);
	}

	void TFile::Duplicate(std::string orig, std::string dupl)
	{
		CopyFile(orig.c_str(), dupl.c_str(), true);
	}

	std::string TFile::GetParentDirectory(std::string file)
	{
		int pathDelimiterIndex = String::FindLast(file, '/');
		if (pathDelimiterIndex > 0) {
			return String::GetFirstChars(file, pathDelimiterIndex);
		}
		return "";
	}

	std::string TFile::GetName(std::string fullPath)
	{
		int pathDelimiterIndex = String::FindLast(fullPath, '/');
		if (pathDelimiterIndex > 0) {
			std::string name = String::GetLastChars(fullPath, fullPath.length() - pathDelimiterIndex - 1);
			return name;
		}
		return fullPath;
	}

	void TFile::WriteString(std::string str)
	{
		fprintf(Fp, "%s", str.c_str());
		fputc(0, Fp);
	}

	void TFile::WriteByte(byte b)
	{
		fputc(b, Fp);
	}

	void TFile::WriteShort(ushort s)
	{
		byte bytes[2];
		Util::ShortToBytes(s, bytes);
		fwrite(bytes, sizeof(byte), 2, Fp);
	}

	void TFile::WriteInt(uint i)
	{
		byte bytes[4];
		Util::IntToBytes(i, bytes);
		fwrite(bytes, sizeof(byte), 4, Fp);
	}

	std::string TFile::ReadString()
	{
		std::string str = "";
		while (true) {
			if (ValidRead()) {
				char ch = DataRead[ReadPtr++];
				if (ch > 0)
					str += ch;
				else
					break;
			}
			else
				break;
		}
		return str;
	}

	byte TFile::ReadByte()
	{
		if (ValidRead()) {
			byte ch = DataRead[ReadPtr++];
			return ch;
		}
		return 0;
	}

	uint TFile::ReadInt()
	{
		byte bytes[4] = { 0 };

		if (ValidRead())
			bytes[0] = DataRead[ReadPtr++];
		if (ValidRead())
			bytes[1] = DataRead[ReadPtr++];
		if (ValidRead())
			bytes[2] = DataRead[ReadPtr++];
		if (ValidRead())
			bytes[3] = DataRead[ReadPtr++];

		return Util::BytesToInt(bytes);
	}

	ushort TFile::ReadShort()
	{
		byte bytes[2] = { 0 };
		
		if (ValidRead())
			bytes[0] = DataRead[ReadPtr++];
		if (ValidRead())
			bytes[1] = DataRead[ReadPtr++];

		return Util::BytesToShort(bytes);
	}

	bool TFile::ValidRead()
	{
		return ReadPtr < LengthRead;
	}
}
