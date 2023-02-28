#include <TGL.h>

void demo_helloworld()
{
	TGL tgl;

	tgl.window();
	tgl.print_free("Hello World!", 35, 65);
	tgl.halt();
}
