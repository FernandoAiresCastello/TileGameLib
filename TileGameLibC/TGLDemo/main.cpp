#include <TGL.h>

int main(int argc, char* args[])
{
	tgl.init();
	tgl.screen(160, 144, 4, 4);

loop:
	tgl.sysproc();
	goto loop;

	return tgl.halt();
}
