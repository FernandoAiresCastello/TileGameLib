/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "ZipFile.h"
#include "Util.h"
#include "File.h"
#include "Miniz.h"

namespace TBRLGPT
{
	ZipFile::ZipFile()
	{
	}

	ZipFile::~ZipFile()
	{
	}

	void ZipFile::Add(std::string file)
	{
		Files.push_back(file);
	}

	void ZipFile::Save(std::string zipfile)
	{
		remove(zipfile.c_str());
		mz_zip_archive zip = { 0 };
		for (unsigned i = 0; i < Files.size(); i++) {
			int length = -1;
			char* data = (char*)File::Read(Files[i], &length);
			mz_bool status = mz_zip_add_mem_to_archive_file_in_place(
				zipfile.c_str(), Files[i].c_str(), data, length,
				NULL, NULL, MZ_BEST_COMPRESSION);
			delete data;
		}
	}

	char* ZipFile::Load(std::string zipfile, std::string filename, int* size)
	{
		mz_zip_archive zip = { 0 };
		mz_bool status = mz_zip_reader_init_file(&zip, zipfile.c_str(), 0);
		if (!status)
			return NULL;

		size_t uncomp_size;
		void* data = mz_zip_reader_extract_file_to_heap(&zip, filename.c_str(), &uncomp_size, 0);
		mz_zip_reader_end(&zip);

		*size = uncomp_size;
		return (char*)data;
	}
}
