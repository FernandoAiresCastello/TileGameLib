#pragma once
#include <memory>
#include "TGL_Global.h"

namespace TGL
{
	template<typename T>
	using Ptr = std::shared_ptr<T>;

	template<typename T>
	using UPtr = std::unique_ptr<T>;
}
