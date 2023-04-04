#include "TGL.h"

int main(int argc, char* argv[]) {
    tgl_init(256, 192, 4, 0x101010);
    while (true) {
        tgl_test_static();
    }
    tgl_halt();
    return 0;
}
