#include "TGL.h"

int main(int argc, char* argv[]) {
    tgl_init();
    tgl_screen_360x200(3, 0x101010);
    while (true) {
        tgl_test_static();
        tgl_update();
    }
    tgl_halt();
    return 0;
}
