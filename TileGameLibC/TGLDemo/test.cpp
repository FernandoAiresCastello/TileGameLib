#include <TGL.h>

void run_test()
{
	tgl.init();
	tgl.title("TGL Demo");
	tgl.screen(256, 192, 4, 4, 0xf0e0a0);
	tgl.halt();
}
