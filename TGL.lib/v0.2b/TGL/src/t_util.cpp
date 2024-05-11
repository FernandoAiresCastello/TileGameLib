#include "t_util.h"

int t_util::rnd(int min, int max)
{
	return min + rand() % (max - min + 1);
}
