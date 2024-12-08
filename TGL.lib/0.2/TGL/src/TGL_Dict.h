#pragma once
#include <unordered_map>
#include "TGL_Global.h"

namespace TGL
{
	template<typename K, typename V>
	using Dict = std::unordered_map<K, V>;
}
