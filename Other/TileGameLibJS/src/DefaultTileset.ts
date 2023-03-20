import { Tileset } from "./Tileset";

export class DefaultTileset {

    static init(chr: Tileset) {
        
        chr.initBlank(256);

        chr.set(0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
        chr.set(0x21, 0x30, 0x30, 0x30, 0x30, 0x30, 0x00, 0x30, 0x00);
        chr.set(0x22, 0x6c, 0x6c, 0x48, 0x00, 0x00, 0x00, 0x00, 0x00);
        chr.set(0x23, 0x00, 0x00, 0x28, 0x7c, 0x28, 0x7c, 0x28, 0x00);
        chr.set(0x24, 0x10, 0xfe, 0xd0, 0xfe, 0x16, 0xd6, 0xfe, 0x10);
        chr.set(0x25, 0x00, 0xc6, 0xcc, 0x18, 0x30, 0x66, 0xc6, 0x00);
        chr.set(0x26, 0x10, 0x7c, 0xe0, 0x7c, 0xe0, 0x7c, 0x10, 0x00);
        chr.set(0x27, 0x70, 0x30, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00);
        chr.set(0x28, 0x0c, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x0c);
        chr.set(0x29, 0x30, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x30);
        chr.set(0x2a, 0x00, 0x6c, 0x38, 0xfe, 0x38, 0x6c, 0x00, 0x00);
        chr.set(0x2b, 0x00, 0x18, 0x18, 0x7e, 0x18, 0x18, 0x00, 0x00);
        chr.set(0x2c, 0x00, 0x00, 0x00, 0x00, 0x00, 0x70, 0x30, 0x60);
        chr.set(0x2d, 0x00, 0x00, 0x00, 0x7e, 0x00, 0x00, 0x00, 0x00);
        chr.set(0x2e, 0x00, 0x00, 0x00, 0x00, 0x00, 0x30, 0x30, 0x00);
        chr.set(0x2f, 0x00, 0x06, 0x0c, 0x18, 0x30, 0x60, 0xc0, 0x00);
        chr.set(0x30, 0x00, 0xfe, 0xc6, 0xd6, 0xd6, 0xc6, 0xfe, 0x00);
        chr.set(0x31, 0x00, 0x38, 0x18, 0x18, 0x18, 0x18, 0x7e, 0x00);
        chr.set(0x32, 0x00, 0x7e, 0x66, 0x06, 0x7e, 0x60, 0x7e, 0x00);
        chr.set(0x33, 0x00, 0x7e, 0x06, 0x3c, 0x06, 0x06, 0x7e, 0x00);
        chr.set(0x34, 0x00, 0x66, 0x66, 0x66, 0x7e, 0x06, 0x06, 0x00);
        chr.set(0x35, 0x00, 0x7e, 0x60, 0x7e, 0x06, 0x66, 0x7e, 0x00);
        chr.set(0x36, 0x00, 0x7e, 0x60, 0x7e, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x37, 0x00, 0x7e, 0x06, 0x0c, 0x18, 0x30, 0x30, 0x00);
        chr.set(0x38, 0x00, 0x7e, 0x66, 0x3c, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x39, 0x00, 0x7e, 0x66, 0x66, 0x7e, 0x06, 0x7e, 0x00);
        chr.set(0x3a, 0x00, 0x00, 0x18, 0x18, 0x00, 0x18, 0x18, 0x00);
        chr.set(0x3b, 0x00, 0x00, 0x30, 0x30, 0x00, 0x70, 0x30, 0x60);
        chr.set(0x3c, 0x0c, 0x18, 0x30, 0x60, 0x30, 0x18, 0x0c, 0x00);
        chr.set(0x3d, 0x00, 0x00, 0x7e, 0x00, 0x7e, 0x00, 0x00, 0x00);
        chr.set(0x3e, 0x60, 0x30, 0x18, 0x0c, 0x18, 0x30, 0x60, 0x00);
        chr.set(0x3f, 0x7e, 0x66, 0x06, 0x1e, 0x18, 0x00, 0x18, 0x00);
        chr.set(0x40, 0xfe, 0x82, 0xba, 0xaa, 0xbe, 0x80, 0xfe, 0x00);
        chr.set(0x41, 0x7e, 0x66, 0x66, 0x66, 0x7e, 0x66, 0x66, 0x00);
        chr.set(0x42, 0x7e, 0x66, 0x66, 0x7c, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x43, 0x7e, 0x66, 0x60, 0x60, 0x60, 0x66, 0x7e, 0x00);
        chr.set(0x44, 0x7c, 0x66, 0x66, 0x66, 0x66, 0x66, 0x7c, 0x00);
        chr.set(0x45, 0x7e, 0x60, 0x60, 0x7c, 0x60, 0x60, 0x7e, 0x00);
        chr.set(0x46, 0x7e, 0x60, 0x60, 0x7c, 0x60, 0x60, 0x60, 0x00);
        chr.set(0x47, 0x7e, 0x66, 0x60, 0x6e, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x48, 0x66, 0x66, 0x66, 0x7e, 0x66, 0x66, 0x66, 0x00);
        chr.set(0x49, 0x7e, 0x18, 0x18, 0x18, 0x18, 0x18, 0x7e, 0x00);
        chr.set(0x4a, 0x06, 0x06, 0x06, 0x06, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x4b, 0x66, 0x66, 0x6c, 0x78, 0x66, 0x66, 0x66, 0x00);
        chr.set(0x4c, 0x60, 0x60, 0x60, 0x60, 0x60, 0x60, 0x7e, 0x00);
        chr.set(0x4d, 0x82, 0xc6, 0xee, 0xfe, 0xd6, 0xd6, 0xc6, 0x00);
        chr.set(0x4e, 0x46, 0x66, 0x76, 0x7e, 0x6e, 0x66, 0x62, 0x00);
        chr.set(0x4f, 0x7e, 0x66, 0x66, 0x66, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x50, 0x7e, 0x66, 0x66, 0x66, 0x7e, 0x60, 0x60, 0x00);
        chr.set(0x51, 0x7e, 0x66, 0x66, 0x66, 0x66, 0x6e, 0x7e, 0x03);
        chr.set(0x52, 0x7e, 0x66, 0x66, 0x66, 0x7c, 0x66, 0x66, 0x00);
        chr.set(0x53, 0x7e, 0x66, 0x60, 0x7e, 0x06, 0x66, 0x7e, 0x00);
        chr.set(0x54, 0x7e, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x00);
        chr.set(0x55, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x56, 0x66, 0x66, 0x66, 0x24, 0x3c, 0x18, 0x18, 0x00);
        chr.set(0x57, 0xc6, 0xc6, 0xd6, 0xd6, 0xfe, 0x6c, 0x6c, 0x00);
        chr.set(0x58, 0x66, 0x66, 0x3c, 0x18, 0x3c, 0x66, 0x66, 0x00);
        chr.set(0x59, 0x66, 0x66, 0x66, 0x66, 0x7e, 0x18, 0x18, 0x00);
        chr.set(0x5a, 0x7e, 0x06, 0x0c, 0x18, 0x30, 0x60, 0x7e, 0x00);
        chr.set(0x5b, 0x1e, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x1e);
        chr.set(0x5c, 0x00, 0xc0, 0x60, 0x30, 0x18, 0x0c, 0x06, 0x00);
        chr.set(0x5d, 0x78, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x78);
        chr.set(0x5e, 0x10, 0x38, 0x6c, 0xc6, 0x00, 0x00, 0x00, 0x00);
        chr.set(0x5f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7e, 0x00);
        chr.set(0x60, 0x38, 0x44, 0xba, 0xa2, 0xba, 0x44, 0x38, 0x00);
        chr.set(0x61, 0x00, 0x00, 0x7c, 0x0c, 0x7c, 0x6c, 0x7e, 0x00);
        chr.set(0x62, 0x70, 0x30, 0x3e, 0x36, 0x36, 0x36, 0x3e, 0x00);
        chr.set(0x63, 0x00, 0x00, 0x7e, 0x66, 0x60, 0x60, 0x7e, 0x00);
        chr.set(0x64, 0x0e, 0x0c, 0x7c, 0x6c, 0x6c, 0x6c, 0x7c, 0x00);
        chr.set(0x65, 0x00, 0x00, 0x7e, 0x66, 0x7e, 0x60, 0x7e, 0x00);
        chr.set(0x66, 0x00, 0x3e, 0x30, 0x7c, 0x30, 0x30, 0x30, 0x00);
        chr.set(0x67, 0x00, 0x00, 0x7e, 0x6c, 0x6c, 0x7c, 0x0c, 0x7c);
        chr.set(0x68, 0x60, 0x60, 0x7c, 0x6c, 0x6c, 0x6c, 0x6e, 0x00);
        chr.set(0x69, 0x18, 0x00, 0x38, 0x18, 0x18, 0x18, 0x7e, 0x00);
        chr.set(0x6a, 0x06, 0x00, 0x06, 0x06, 0x06, 0x36, 0x36, 0x3e);
        chr.set(0x6b, 0x60, 0x60, 0x66, 0x6c, 0x78, 0x66, 0x66, 0x00);
        chr.set(0x6c, 0x38, 0x18, 0x18, 0x18, 0x18, 0x18, 0x7e, 0x00);
        chr.set(0x6d, 0x00, 0x00, 0xfe, 0xd6, 0xd6, 0xd6, 0xd6, 0x00);
        chr.set(0x6e, 0x00, 0x00, 0x7e, 0x36, 0x36, 0x36, 0x36, 0x00);
        chr.set(0x6f, 0x00, 0x00, 0x7e, 0x66, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x70, 0x00, 0x00, 0x7e, 0x36, 0x36, 0x3e, 0x30, 0x30);
        chr.set(0x71, 0x00, 0x00, 0x7c, 0x6c, 0x6c, 0x7c, 0x0c, 0x0e);
        chr.set(0x72, 0x00, 0x00, 0x7e, 0x36, 0x30, 0x30, 0x30, 0x00);
        chr.set(0x73, 0x00, 0x00, 0x7e, 0x60, 0x7e, 0x06, 0x7e, 0x00);
        chr.set(0x74, 0x00, 0x30, 0x7e, 0x30, 0x30, 0x30, 0x3e, 0x00);
        chr.set(0x75, 0x00, 0x00, 0x6c, 0x6c, 0x6c, 0x6c, 0x7e, 0x00);
        chr.set(0x76, 0x00, 0x00, 0x66, 0x66, 0x66, 0x3c, 0x18, 0x00);
        chr.set(0x77, 0x00, 0x00, 0xd6, 0xd6, 0xd6, 0xfe, 0x6c, 0x00);
        chr.set(0x78, 0x00, 0x00, 0x66, 0x3c, 0x18, 0x3c, 0x66, 0x00);
        chr.set(0x79, 0x00, 0x00, 0x76, 0x36, 0x36, 0x3e, 0x06, 0x3e);
        chr.set(0x7a, 0x00, 0x00, 0x7e, 0x06, 0x18, 0x60, 0x7e, 0x00);
        chr.set(0x7b, 0x0c, 0x18, 0x18, 0x70, 0x18, 0x18, 0x0c, 0x00);
        chr.set(0x7c, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x00);
        chr.set(0x7d, 0x60, 0x30, 0x30, 0x1c, 0x30, 0x30, 0x60, 0x00);
        chr.set(0x7e, 0x00, 0x00, 0x60, 0xf2, 0x9e, 0x0c, 0x00, 0x00);
        chr.set(0x7f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
    }
}