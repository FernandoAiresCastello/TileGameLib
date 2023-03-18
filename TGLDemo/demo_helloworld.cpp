#include <TGL.h>

void demo_helloworld()
{
	TGL tgl;
	tgl.window_gbc(0xffffff, 4);
	tgl.font_color(0x000000);
	tgl.print_free("Hello World!", 35, 65);
	tgl.halt();
}
