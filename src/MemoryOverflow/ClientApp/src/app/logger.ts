export class Logger {

    constructor(private prefix: string) {

    }

    public log(...args: any[]) {
        console.log.apply(console, [`[${this.prefix}]`, ...args]);
    }
    public error(...args: any[]) {
        console.error.apply(console, [`[${this.prefix}]`, ...args]);
    }
}