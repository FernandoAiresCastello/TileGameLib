#include <TGL.h>

void demo_helloworld()
{
	TGL tgl;

	tgl.window_wide();
	tgl.print_tiled("Hello World!", 16, 12);
	tgl.halt();
}
