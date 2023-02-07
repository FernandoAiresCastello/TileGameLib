#include <TGL.h>

void run_test()
{
	tgl.init();
	tgl.title("TGL Demo");
	tgl.screen(256, 192, 4, 4, 0x0000a0);

	tgl.print("Hello World!", 50, 50);

	tgl.halt();
}
