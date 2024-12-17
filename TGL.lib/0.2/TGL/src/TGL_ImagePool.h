#pragma once
#include "TGL_Global.h"
#include "TGL_Color.h"
#include "TGL_Index.h"
#include "TGL_String.h"
#include "TGL_Dict.h"
#include "TGL_Image.h"

namespace TGL
{
	class TGLAPI ImagePool
	{
	public:
		ImagePool();
		~ImagePool();

		Image* LoadImage(const String& filePath, bool transparent = false, const Color& transparencyKey = 0);
		void LoadImages(const String& directoryPath, bool transparent = false, const Color& transparencyKey = 0);
		Image* GetImage(const String& name);
		Dict<String, Image>& GetImages();
		void RemoveAll();

	private:
		Dict<String, Image> images;
	};
}
