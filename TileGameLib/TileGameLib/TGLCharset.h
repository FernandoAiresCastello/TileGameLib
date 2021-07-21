/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once

#include <string>
#include <vector>
#include "TGLGlobal.h"
#include "TGLClass.h"
#include "TGLChar.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TGLCharset : TGLClass
	{
	public:
		TGLCharset();
		TGLCharset(const TGLCharset& other);
		~TGLCharset();

		std::vector<TGLChar>& GetChars();
		TGLChar& Get(TGLCharsetIndex ix);
		std::vector<byte> GetBytes(TGLCharsetIndex ix);
		int GetSize();
		void Clear();
		void DeleteAll();
		void Add(TGLChar ch);
		void AddBlank(int count = 1);
		void Add(int row0, int row1, int row2, int row3, int row4, int row5, int row6, int row7);
		void Set(TGLCharsetIndex ix, int row0, int row1, int row2, int row3, int row4, int row5, int row6, int row7);
		void Set(TGLCharsetIndex ix, std::string row0, std::string row1, std::string row2, std::string row3, std::string row4, std::string row5, std::string row6, std::string row7);
		void Set(TGLCharsetIndex ix, TGLChar& ch);
		void CopyChar(TGLCharsetIndex dstix, TGLCharsetIndex srcix);
		void SetEqual(TGLCharset& other);
		void InitDefault();

	private:
		std::vector<TGLChar> Chars;
	};
}
