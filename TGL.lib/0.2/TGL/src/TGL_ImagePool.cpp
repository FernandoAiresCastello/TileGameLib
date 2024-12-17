#include <filesystem>
#include "TGL_ImagePool.h"

namespace TGL
{
	namespace fs = std::filesystem;

	ImagePool::ImagePool()
	{
	}

	ImagePool::~ImagePool()
	{
		images.clear();
	}

	Image* ImagePool::LoadImage(const String& filePath, bool transparent, const Color& transparencyKey)
	{
		fs::path path(filePath.Sstr());
		auto&& name = path.filename().replace_extension("").string();
		images[name] = Image(filePath);
		
		if (transparent)
			images[name].SetTransparency(transparencyKey);

		return &images[name];
	}

	void ImagePool::LoadImages(const String& directoryPath, bool transparent, const Color& transparencyKey)
	{
		for (const auto& entry : fs::directory_iterator(directoryPath.Sstr())) {
			if (entry.is_regular_file()) {
				const auto&& ext = entry.path().extension().string();
				if (ext == ".png" || ext == ".bmp" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif")
					LoadImage(entry.path().string(), transparent, transparencyKey);
			}
		}
	}

	Image* ImagePool::GetImage(const String& name)
	{
		if (images.contains(name))
			return &images[name];

		return nullptr;
	}

	Dict<String, Image>& ImagePool::GetImages()
	{
		return images;
	}

	void ImagePool::RemoveAll()
	{
		images.clear();
	}
}
