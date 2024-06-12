#include <TGL.h>
using namespace tgl;

t_window wnd;
t_tileout out(&wnd);

int main(int argc, char* argv[])
{
	wnd.open("TGL Test", 360, 200, 3, 3, 0xffffff);

	while (wnd.is_open()) {
		wnd.clear(t_color::get_random());
		out.draw_text("Hello World!", 1, 1, 0xff0000, 0xffff00, true);
		wnd.update();
	}

	return 0;
}
