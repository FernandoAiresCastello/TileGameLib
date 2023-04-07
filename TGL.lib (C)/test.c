#include "TGL.h"

int main(int argc, char* argv[]) {
    tgl_init();
    tgl_screen_360x200(4, 0x101010);
    tgl_title("Hello World!");

    tgl_tileset(10);
    tgl_tile_bin(0, 
        "11111111"
        "10000001"
        "10100101"
        "10000001"
        "10100101"
        "10011001"
        "10000001"
        "11111111"
    );
    rgb pixels[64] = {
        0xffff00,0xffff00,0xffff00,0xffff00,0xffff00,0xffff00,0xffff00,0xffff00,
        0xffff00,0xff0000,0xff0000,0xff0000,0xff0000,0xff0000,0xff0000,0xffff00,
        0xffff00,0x00ff00,0x00ff00,0xff0000,0xff0000,0xff0000,0xff0000,0xffff00,
        0xffff00,0x00ff00,0x00ff00,0xff0000,0xff0000,0xff0000,0xff0000,0xffff00,
        0xffff00,0xff0000,0xff0000,0xff0000,0xff0000,0xff0000,0xff0000,0xffff00,
        0xffff00,0xff0000,0xff0000,0xff0000,0xff0000,0xff0000,0xff0000,0xffff00,
        0xffff00,0xff0000,0xff0000,0xff0000,0xff0000,0xff0000,0xff0000,0xffff00,
        0xffff00,0xffff00,0xffff00,0xffff00,0xffff00,0xffff00,0xffff00,0xffff00
    };
    tgl_tile_rgb(1, pixels);

    tgl_mode_bin();
    tgl_transparent(false);

    while (tgl_window()) {
        tgl_clear();
        for (int y = 0; y < tgl_rows(); y++) {
            for (int x = 0; x < tgl_cols(); x++) {
                tgl_color(tgl_rnd(0x000000, 0xffff00), tgl_rnd(0x000000, 0xffffff));
                tgl_draw_tiled(0, x, y);
            }
        }
        tgl_update();
    }
    return 0;
}
