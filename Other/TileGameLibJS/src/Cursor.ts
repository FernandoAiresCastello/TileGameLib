import { TileBuffer } from "./TileBuffer";

export class Cursor {

    buffer: TileBuffer;
    layer: number;
    x: number;
    y: number;

    constructor(buffer: TileBuffer) {
        this.buffer = buffer;
        this.layer = 0;
        this.x = 0;
        this.y = 0;
    }

    set(buffer: TileBuffer, layer: number, x: number, y: number) {
        this.buffer = buffer;
        this.layer = layer;
        this.x = x;
        this.y = y;
    }

    setPos(x: number, y: number) {
        this.x = x;
        this.y = y;
    }

    reset(buffer: TileBuffer) {
        this.buffer = buffer;
        this.layer = 0;
        this.x = 0;
        this.y = 0;
    }
}
