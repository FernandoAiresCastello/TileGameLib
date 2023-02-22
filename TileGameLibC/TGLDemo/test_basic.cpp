#include <TGL.h>

void test_basic()
{
	TGL tgl;
	tgl.window(0xff0080);

	while (tgl.running()) {
		tgl.system();
		if (tgl.kb_esc()) tgl.exit();
	}
}
