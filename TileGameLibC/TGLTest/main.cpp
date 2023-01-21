#include <TGL.h>

int main(int argc, char* args[]) 
{
	tgl.init();
	tgl.screen(43, 24, 2, 4, 4);

	auto data = tgl.file.bload("C:\\Fernando\\Temp\\data.bin");

	tgl.halt();

	return 0;
}
