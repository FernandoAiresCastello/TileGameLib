#include "TGL.h"

int main(int argc, char* argv[]) {
    tgl_init();

    tgl_file_open("test_data/hello.txt");
    while (!tgl_file_eof()) {
        char* line = tgl_file_line();
        tgl_trim(line);
        tgl_lcase(line);
        tgl_msgbox(line);
    }
    tgl_file_close();

    return 0;
}
