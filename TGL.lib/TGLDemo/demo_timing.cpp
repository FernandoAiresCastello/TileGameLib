#include <TGL.h>

#define RND_COLOR	tgl.rnd(0x000000, 0xffffff)

void demo_timing()
{
	TGL_APP tgl;
	tgl.window_160x144(0xffffff, 4);

	int pause_frames = 30;

	while (tgl.window()) {
		tgl.backcolor(RND_COLOR);
		tgl.clear();
		tgl.font_color(RND_COLOR);
		tgl.print_free(tgl.fmt("Pause: %3i frames", pause_frames), 13, 65);
		tgl.update();
		tgl.pause(pause_frames);
		if (tgl.kb_esc()) {
			tgl.exit();
		}
	}
}
