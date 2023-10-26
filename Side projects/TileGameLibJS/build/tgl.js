(function(){function r(e,n,t){function o(i,f){if(!n[i]){if(!e[i]){var c="function"==typeof require&&require;if(!f&&c)return c(i,!0);if(u)return u(i,!0);var a=new Error("Cannot find module '"+i+"'");throw a.code="MODULE_NOT_FOUND",a}var p=n[i]={exports:{}};e[i][0].call(p.exports,function(r){var n=e[i][1][r];return o(n||r)},p,p.exports,r,e,n,t)}return n[i].exports}for(var u="function"==typeof require&&require,i=0;i<t.length;i++)o(t[i]);return o}return r})()({1:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Log = void 0;
class Log {
    static info(msg) {
        console.log("[TGL] " + msg);
    }
}
exports.Log = Log;

},{}],2:[function(require,module,exports){
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
document.addEventListener("DOMContentLoaded", (event) => {
    window.tgl = new TGL();
});

},{"./log":1}]},{},[2]);
