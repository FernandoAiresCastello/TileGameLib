#include <TGL.h>

void demo_helloworld()
{
	TGL tgl;

	tgl.window_wide(0xffffff, 4);
	tgl.color_single(0x000000);
	tgl.font_shadow(true, 0xd0d0d0);
	tgl.print_tiled("Hello World!", 16, 12);
	tgl.halt();
}
