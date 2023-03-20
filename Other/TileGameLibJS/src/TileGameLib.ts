import { TGL_InitializationError } from "./TGL_InitializationError";
import { TGL_RuntimeError } from "./TGL_RuntimeError";
import { Palette } from "./Palette";
import { Tileset } from "./Tileset";
import { Display } from "./Display";
import { Cursor } from "./Cursor";
import { TileSeq } from "./TileSeq";
import { DefaultTileset } from "./DefaultTileset";
import { DefaultPalette } from "./DefaultPalette";
import { FmtStringPrinter } from "./FmtStringPrinter";
import { KeyboardInput } from "./KeyboardInput";
import { ColorString, PaletteIndex } from "./ColorTypes";

document.addEventListener("DOMContentLoaded", () => {
    const global = window as any;
    global.tgl = new TGL("TGL_Display");
    global.tgl.init();
    global.tgl.runLoop();
});

export class TGL {

    initialized: boolean;
    palette: Palette;
    tileset: Tileset;
    display: Display | null;
    cursor: Cursor | null;
    currentTile: TileSeq;
    currentTextFgc: number;
    currentTextBgc: number;
    displayElement: HTMLElement;
    keyboard: KeyboardInput;
    animationInterval: number;
    runLoopActive: boolean;
    runLoopHandle: number;
    autoVsyncHandle: number;
    exited: boolean;

    constructor(displayElementId: string) {
        
        this.log("Initializing...");
        this.initialized = false;

        const displayElement = document.getElementById(displayElementId);
        if (!displayElement) {
            throw new TGL_InitializationError(`Display element not found with id: ${displayElementId}`);
        }

        this.displayElement = displayElement;
        this.display = null;
        this.palette = new Palette();
        this.tileset = new Tileset();
        this.cursor = null;
        this.currentTile = new TileSeq();
        this.currentTextFgc = 1;
        this.currentTextBgc = 0;
        this.keyboard = new KeyboardInput();
        this.animationInterval = 400;
        this.autoVsyncHandle = 0;
        this.runLoopActive = false;
        this.runLoopHandle = 0;
        this.exited = false;

        DefaultPalette.init(this.palette);
        DefaultTileset.init(this.tileset);

        this.runAutoVsync();
    }

    log(msg: string) {
        console.log(`%c[TileGameLib]%c ${msg}`, "color:#0f0", "color:#fff");
    }

    getGlobals(): any {
        return window as any;
    }

    init() {
        if (this.initialized) {
            throw new TGL_InitializationError(`TGL_Init function has already been called once`);
        }
        const global = this.getGlobals();
        if (!global.TGL_Init) {
            throw new TGL_InitializationError(`TGL_Init function not found`);
        }
        this.log("TGL_Init started...");
        global.TGL_Init();
        this.log("TGL_Init finished");
        this.initialized = true;
    }

    runLoop() {
        if (this.exited) {
            return;
        }
        const global = this.getGlobals();
        if (!global.TGL_Loop) {
            throw new TGL_InitializationError(`TGL_Loop function not found`);
        }
        if (!this.runLoopActive) {
            this.runLoopActive = true;
            this.log("TGL_Loop started...");
        }
        global.TGL_Loop();
        this.runLoopHandle = window.requestAnimationFrame(() => this.runLoop());
    }

    runAutoVsync() {
        if (this.display) {
            this.display.update();
        }
        this.autoVsyncHandle = window.requestAnimationFrame(() => this.runAutoVsync());
    }

    stopAutoVsync() {
        window.cancelAnimationFrame(this.autoVsyncHandle);
    }

    // Commands:

    TEST() {
        this.log("TEST executed");
    }

    EXIT() {
        if (!this.exited) {
            this.exited = true;
            window.cancelAnimationFrame(this.runLoopHandle);
            this.log("TGL_Loop finished");
        }
    }

    RESET() {
        if (this.display) {
            this.display.reset();
            if (this.cursor) {
                this.cursor.reset(this.display.getDefaultBuffer());
            }
        }
        this.currentTile = new TileSeq();
        this.currentTextFgc = 1;
        this.currentTextBgc = 0;
        DefaultPalette.init(this.palette);
        DefaultTileset.init(this.tileset);
    }

    KEY(key: string): boolean {
        return this.keyboard.getKeyState(key);
    }

    SCREEN(width: number, height: number, hStretch: number, vStretch: number, defaultBufLayers: number) {
        if (this.display) {
            this.display.reset();

            if (this.cursor) {
                this.cursor.set(this.display.getDefaultBuffer(), 0, 0, 0);
            }

        } else {
            this.display = new Display(this.displayElement, 
                width, height, hStretch, vStretch, defaultBufLayers, 
                this.palette, this.tileset, this.animationInterval);

            this.cursor = new Cursor(this.display.getDefaultBuffer());
        }
    }

    PAL(ix: number, rgb: ColorString) {
        this.palette.set(ix, rgb);
    }

    CLS() {
        if (this.display) {
            this.display.clearAllBuffers();
        }
        if (this.cursor) {
            this.cursor.setPos(0, 0);
        }
    }

    WCOL(color: PaletteIndex) {
        if (this.display) {
            this.display.setBackColorIx(color);
        }
    }

    FCOL(color: PaletteIndex) {
        this.currentTextFgc = color;
    }

    BCOL(color: PaletteIndex) {
        this.currentTextBgc = color;
    }

    COLOR(fgc: PaletteIndex, bgc: PaletteIndex) {
        this.currentTextFgc = fgc;
        this.currentTextBgc = bgc;
    }

    ROWS(): number {
        if (this.cursor) {
            return this.cursor.buffer.height;
        } else {
            return 0;
        }
    }

    COLS(): number {
        if (this.cursor) {
            return this.cursor.buffer.width;
        } else {
            return 0;
        }
    }

    LOCATE(x: number, y: number) {
        if (this.cursor) {
            this.cursor.setPos(x, y);
        }
    }

    PRINT(fmt: string) {
        if (this.display && this.cursor) {
            const stringFmt = new FmtStringPrinter(this);
            stringFmt.print(fmt, this.cursor, this.currentTextFgc, this.currentTextBgc, this.currentTile.transparent);
            if (stringFmt.error) {
                throw new TGL_RuntimeError(`${stringFmt.error}: ${fmt}`);
            }
        }
    }

    PRINTL(fmt: string) {
        this.PRINT(fmt + "{LF}");
    }
}
