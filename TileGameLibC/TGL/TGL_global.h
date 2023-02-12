#pragma once

// Standard C++
#include <cstdarg>
#include <string>
#include <vector>
#include <map>
#include <unordered_map>
using namespace std;

// SDL 2
#include <SDL.h>

// CppUtils
#include <CppUtils.h>
using namespace CppUtils;

// TGL private internals
#include "Internal/TRGBWindow.h"
#include "Internal/TGamepad.h"
#include "Internal/TKey.h"
#include "Internal/TSound.h"

// TGL public typedefs
typedef int rgb;

// TGL public API singleton
extern struct TGL tgl;
