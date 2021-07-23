/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <string>
#include <vector>
#include "TGlobal.h"
#include "TClass.h"
#include "TChar.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TCharset : TClass
	{
	public:
		static TCharset* Default;

		TCharset();
		TCharset(const TCharset& other);
		~TCharset();

		std::vector<TChar>& GetChars();
		TChar& Get(TCharsetIndex ix);
		std::vector<byte> GetBytes(TCharsetIndex ix);
		int GetSize();
		void Clear();
		void DeleteAll();
		void Add(TChar ch);
		void AddBlank(int count = 1);
		void Add(int row0, int row1, int row2, int row3, int row4, int row5, int row6, int row7);
		void Set(TCharsetIndex ix, int row0, int row1, int row2, int row3, int row4, int row5, int row6, int row7);
		void Set(TCharsetIndex ix, std::string row0, std::string row1, std::string row2, std::string row3, std::string row4, std::string row5, std::string row6, std::string row7);
		void Set(TCharsetIndex ix, TChar& ch);
		void CopyChar(TCharsetIndex dstix, TCharsetIndex srcix);
		void SetEqual(TCharset& other);
		void Load(std::string filename);
		void Save(std::string filename);
		void InitDefault();

	private:
		std::vector<TChar> Chars;
	};
}
