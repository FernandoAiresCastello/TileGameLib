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

	int i = 0;

loop:
	WCOL(i);
	i++; if (i > 4) i = 0;

	CLS();
	TRON();
	
	TILE_NEW(1, 2, 3);
	TILE_ADD(2, 3, 2);
	LOCATE(1, 1);
	PUT();

	PAUSE(4);

	goto loop;

	HALT();

	return 0;
}
