#include <TGL.h>

void demo_helloworld()
{
	TGL tgl;

	tgl.window_wide(0xffffff, 4);
	tgl.font_color(0x000000);
	tgl.font_shadow(true, 0xd0d0d0);
	tgl.print_tiled("Hello World!", 17, 12);
	tgl.halt();
}
