#include <TGL.h>

void demo_helloworld()
{
	TGL tgl;
	
	tgl.window(0x0000ff);
	tgl.color_single(0xffff00);
	tgl.print_free("Hello World!", 35, 65);
	tgl.halt();
}
