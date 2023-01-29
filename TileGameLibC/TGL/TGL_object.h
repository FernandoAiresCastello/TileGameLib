#pragma once
#include "TGL_global.h"

struct object
{
	object();

private:
	friend struct TGL;

	object(const object&) = delete;
	object(object&&) = delete;
};
