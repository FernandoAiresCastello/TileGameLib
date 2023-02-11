#include <TGL.h>

void test_basic()
{
	tgl.init();
	tgl.window(0x000000);

	while (tgl.system()) {
		
		if (tgl.kb_esc()) tgl.exit();
	}
}
