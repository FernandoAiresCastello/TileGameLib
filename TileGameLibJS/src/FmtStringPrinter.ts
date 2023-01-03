import { TGL_RuntimeError } from "./TGL_RuntimeError";
import { Cursor } from "./Cursor";
import { TileSeq } from "./TileSeq";
import { TGL } from "./TileGameLib";

export class FmtStringPrinter {
    
    tgl: TGL;
    error: string | null;

    constructor(tgl: TGL) {
        this.tgl = tgl;
        this.error = null;
    }

    print(fmt: string, csr: Cursor, initFgc: number, initBgc: number, transp: boolean) {
        const buf = csr.buffer;
        const layer = csr.layer;
        const initX = csr.x;

        let tile = new TileSeq();
        tile.transparent = transp;
        tile.setSingle(0, 0, 0);
        let textColor = new TextColor(initFgc, initBgc);

        const chEscapeBegin = "{";
        const chEscapeEnd = "}";
        let escaped = false;
        let escapeSeq = "";
        
        let isVariable = false;
        let resolvedVariableValue = "";

        for (let i = 0; i < fmt.length; i++) {
            let tileIndex = fmt.charCodeAt(i);
            const ch = fmt.charAt(i);

            if (ch === chEscapeBegin) {
                if (escaped) {
                    this.error = "Escape sequences cannot be nested";
                    return;
                }
                escaped = true;
                continue;

            } else if (ch === chEscapeEnd) {
                if (!escaped) {
                    this.error = "Missing opening escape character";
                    return;
                }
                escaped = false;
                const res = this.interpretEscapeSequence(escapeSeq, csr, initX, textColor);
                escapeSeq = "";
                if (res) {
                    if (res.tileIndex) {
                        tileIndex = res.tileIndex;
                    } else if (res.varValue) {
                        isVariable = true;
                        resolvedVariableValue = res.varValue;
                    }
                } else {
                    continue;
                }

            } else if (escaped) {
                escapeSeq += ch;
                continue;
            }

            if (isVariable) {
                isVariable = false;
                for (let i = 0; i < resolvedVariableValue.length; i++) {
                    tile.set(0, resolvedVariableValue.charCodeAt(i), textColor.fg, textColor.bg);
                    buf.setTile(tile, layer, csr.x, csr.y);
                    csr.x++;
                }
            } else {
                tile.set(0, tileIndex, textColor.fg, textColor.bg);
                buf.setTile(tile, layer, csr.x, csr.y);
                csr.x++;
            }
        }
    }

    private interpretEscapeSequence(esc: string, csr: Cursor, initX: number, textColor: TextColor): ResolvedEscapeSeq | null {

        if (esc.toUpperCase() === "LF") {
            csr.y++;
            csr.x = initX;
            return null;

        } else if (esc[0].toUpperCase() === "F") {
            textColor.fgPrev = textColor.fg;
            textColor.fg = Number(esc.substring(1).trim());
            return null;

        } else if (esc.toUpperCase() === "/F") {
            textColor.fg = textColor.fgPrev;
            return null;

        } else if (esc[0].toUpperCase() === "B") {
            textColor.bgPrev = textColor.bg;
            textColor.bg = Number(esc.substring(1).trim());
            return null;

        } else if (esc.toUpperCase() === "/B") {
            textColor.bg = textColor.bgPrev;
            return null;

        } else if (esc[0].toUpperCase() === "C") {
            const res = new ResolvedEscapeSeq();
            res.tileIndex = Number(esc.substring(1).trim());
            return res;

        } else if (esc[0] === "%") {
            const id = esc.substring(1).trim();
            const value = this.tgl.getGlobals()[id];
            if (value === undefined || value === null) {
                throw new TGL_RuntimeError(`Unknown variable: ${id}`);
            }
            const res = new ResolvedEscapeSeq();
            res.varValue = value.toString();
            return res;

        } else {
            throw new TGL_RuntimeError(`Unrecognized escape sequence: ${esc}`);
        }
    }
}

class TextColor {
    fg: number = 0;
    bg: number = 0;
    fgPrev: number = 0;
    bgPrev: number = 0;

    constructor(fg: number, bg: number) {
        this.fg = fg;
        this.bg = bg;
        this.fgPrev = fg;
        this.bgPrev = bg;
    }
}

class ResolvedEscapeSeq {
    varValue: string | null = null;
    tileIndex: number | null = null;
}
