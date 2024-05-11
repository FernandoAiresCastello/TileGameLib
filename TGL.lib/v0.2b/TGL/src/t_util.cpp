#include <random>
#include "t_util.h"

namespace tgl
{
	std::random_device rd;
	std::mt19937 mt(rd());

	int t_util::rnd(int min, int max)
	{
		return std::uniform_int_distribution<int>(min, max)(mt);
	}
}
