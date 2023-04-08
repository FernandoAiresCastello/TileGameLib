#include <TGL.h>

void demo_helloworld()
{
	TGL_APP tgl;
	tgl.window_160x144(0xffffff, 4);
	tgl.font_shadow(true, 0xd0d0d0);
	tgl.font_color(0x000000);
	tgl.print_free("Hello World!", 35, 65);
	tgl.halt();
}
