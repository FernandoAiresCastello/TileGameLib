#include <TGL.h>

void demo_helloworld()
{
	TGL_APP tgl;
	tgl.window_160x144(0xffffff, 4);
	tgl.text_shadow(true, 0xd0d0d0);
	tgl.text_color(0x000000);
	tgl.print_free("Hello World!", 35, 65);
	tgl.halt();
}
