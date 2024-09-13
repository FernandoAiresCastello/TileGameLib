#include <TGL.h>

int main(int argc, char* argv[])
{
	TGL::TGL_Window wnd;
	wnd.Create(800, 600, 0x0000ff);
	wnd.Show();

	return 0;
}
