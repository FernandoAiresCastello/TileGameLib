#pragma once

// SDL 2
#include <SDL.h>

// C++ STL
#include <string>
#include <vector>
#include <map>
using namespace std;

// CppUtils
#include <CppUtils.h>
using namespace CppUtils;

// TGL private internals
#include "Internal/TKey.h"
#include "Internal/TRGBWindow.h"

// TGL public typedefs
typedef int rgb;

// TGL public API singleton
extern struct TGL tgl;
