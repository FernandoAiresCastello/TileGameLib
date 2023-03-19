export class Perfmon {

    startTimeMs: number = 0;
    endTimeMs: number = 0;
    timeDiffMs: number = 0;

    constructor() {
        this.start();
    }

    start(): number {
        this.startTimeMs = performance.now();
        return this.startTimeMs;
    }

    stop(): number {
        this.endTimeMs = performance.now();
        this.timeDiffMs = this.endTimeMs - this.startTimeMs;
        return this.timeDiffMs;
    }

    stopThenPrint() {
        const msTimeSpent = this.stop();
        const lastMsTimeSpent = (window as any).TGL_PerfmonMs;
        if (lastMsTimeSpent === undefined || msTimeSpent > lastMsTimeSpent) {
            (window as any).TGL_PerfmonMs = msTimeSpent;
            console.log("Cycle max time ms: " + msTimeSpent);
        }
    }
}
