#pragma once
#include <SDL.h>
#include <memory>

#ifdef TGLEXPORTS
	#define TGLAPI __declspec(dllexport)
#else
	#define TGLAPI __declspec(dllimport)
#endif

namespace TGL
{
	template<typename T>
	using Ptr = std::shared_ptr<T>;

	template<typename T>
	using Uptr = std::unique_ptr<T>;
}
