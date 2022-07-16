/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <vector>
#include <string>
#include <CppUtils.h>
#include "TGlobal.h"

namespace TileGameLib
{
	class TBufferedWindow;
	class TBufferEditor;
	class TCharSelector;
	class TCharEditor;
	class TColorSelector;
	class TColorEditor;

	class TToolkitApp
	{
	public:
		TToolkitApp();
		~TToolkitApp();

		void Run();

	private:
		bool Running;
		TBufferedWindow* Wnd;
	};
}
