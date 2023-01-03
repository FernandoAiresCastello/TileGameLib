export class Tile {

    ix: number;
    fgc: number;
    bgc: number;

    constructor() {
        this.ix = 0;
        this.fgc = 0;
        this.bgc = 0;
    }

    set(ix: number, fgc: number, bgc: number) {
        this.ix = ix;
        this.fgc = fgc;
        this.bgc = bgc;
    }

    setEqual(other: Tile) {
        this.ix = other.ix;
        this.fgc = other.fgc;
        this.bgc = other.bgc;
    }

    setBlank() {
        this.ix = 0;
        this.fgc = 0;
        this.bgc = 0;
    }
}
