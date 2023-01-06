/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <string>
#include <vector>
#include <CppUtils.h>
#include "TGlobal.h"
#include "TChar.h"

using byte = CppUtils::byte;

namespace TileGameLib
{
	class TCharset
	{
	public:
		static TCharset* Default;

		TCharset();
		TCharset(const TCharset& other);
		~TCharset();

		std::vector<TChar>& GetChars();
		TChar& Get(CharsetIndex ix);
		std::vector<byte> GetBytes(CharsetIndex ix);
		int GetSize();
		void Clear();
		void DeleteAll();
		void Add(TChar ch);
		void AddBlank(int count = 1);
		void Add(int row0, int row1, int row2, int row3, int row4, int row5, int row6, int row7);
		void Add(std::string pixels);
		void Set(CharsetIndex ix, int row0, int row1, int row2, int row3, int row4, int row5, int row6, int row7);
		void Set(CharsetIndex ix, std::string row0, std::string row1, std::string row2, std::string row3, std::string row4, std::string row5, std::string row6, std::string row7);
		void Set(CharsetIndex ix, std::string pixels);
		void Set(CharsetIndex ix, TChar& ch);
		void Set(CharsetIndex ix, int rowIndex, int rowData);
		void CopyChar(CharsetIndex dstix, CharsetIndex srcix);
		void SetEqual(TCharset& other);
		void Load(std::string filename);
		void Save(std::string filename);
		void LoadFromImage(std::string filename);
		void InitDefault();

	private:
		std::vector<TChar> Chars;
	};
}
