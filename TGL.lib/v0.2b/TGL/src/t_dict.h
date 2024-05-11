#pragma once
#include <unordered_map>

namespace tgl
{
	template<typename T1, typename T2>
	using t_dict = std::unordered_map<T1, T2>;
}
