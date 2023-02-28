export class Viewport {

    displayX: number;
    displayY: number;
    width: number;
    height: number;
    scrollX: number;
    scrollY: number;

    constructor(dispX: number, dispY: number, w: number, h: number) {
        this.displayX = dispX;
        this.displayY = dispY;
        this.width = w;
        this.height = h;
        this.scrollX = 0;
        this.scrollY = 0;
    }

    set(dispX: number, dispY: number, w: number, h: number) {
        this.displayX = dispX;
        this.displayY = dispY;
        this.width = w;
        this.height = h;
    }

    scroll(dx: number, dy: number) {
        this.scrollX += dx;
        this.scrollY += dy;
    }
}
