#include <TGL.h>

int main(int argc, char* args[]) 
{
	TILEGAMELIB();
	SCREEN(32, 24, 2, 4, 4);
	TITLE("Hello World!");

	PAL(0, 0x000000);
	PAL(1, 0xffffff);
	PAL(2, 0xff0000);
	PAL(3, 0x00ff00);
	PAL(4, 0x0000ff);

	BGCOL(2);
	CLS();

	TROFF();
	LOCATE(1, 1);
	COLOR(3, 4);
	PRINT("Hello World!");

	HALT();

	return 0;
}
