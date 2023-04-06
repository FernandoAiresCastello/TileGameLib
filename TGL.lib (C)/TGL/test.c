#include "TGL.h"

int main(int argc, char* argv[]) {
    tgl_init();
    tgl_screen_360x200(4, 0x101010);
    while (tgl_window()) {
        tgl_clear();
        tgl_test_static();
        tgl_update();
    }
    return 0;
}
