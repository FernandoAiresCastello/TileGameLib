#include <TGL.h>

void demo_helloworld()
{
	TGL tgl;
	
	tgl.window(0x000000);
	tgl.print_free("Hello World!", 0, 0);
	tgl.halt();
}
