export class TGL_RuntimeError extends Error {
    constructor(msg: string,) {
        super();
        Object.setPrototypeOf(this, new.target.prototype);
        this.stack = undefined;
        this.message = msg;
    }
}
