import { Tile } from "./Tile";

export class TileSeq {

    frames: Tile[] = [];
    transparent: boolean = false;

    deleteAll() {
        this.frames = [];
    }

    add(ix: number, fgc: number, bgc: number) {
        const frame = new Tile();
        frame.set(ix, fgc, bgc);
        this.frames.push(frame);
    }

    set(frame: number, ix: number, fgc: number, bgc: number) {
        this.frames[frame].set(ix, fgc, bgc);
    }

    setSingle(ix: number, fgc: number, bgc: number) {
        this.deleteAll();
        this.add(ix, fgc, bgc);
    }

    isEmpty(): boolean {
        return this.frames.length === 0;
    }

    setEqual(other: TileSeq) {
        this.transparent = other.transparent;
        this.frames = [];
        for (let i = 0; i < other.frames.length; i++) {
            const tile = new Tile();
            tile.setEqual(other.frames[i]);
            this.frames.push(tile);
        }
    }
}
