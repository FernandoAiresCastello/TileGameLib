"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TGL = void 0;
const log_1 = require("./log");
class TGL {
    constructor() {
        log_1.Log.info("TGL singleton created!");
    }
    hello() {
        log_1.Log.info("Hello World!");
    }
}
exports.TGL = TGL;
