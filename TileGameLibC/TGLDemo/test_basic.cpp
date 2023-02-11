#include <TGL.h>

void test_basic()
{
	tgl.init();
	tgl.window(0xff0080);

	while (true) {
		
		tgl.system();

		if (tgl.kb_esc()) tgl.exit();
	}
}
