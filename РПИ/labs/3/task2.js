const Emitter = require("events");
let emitter = new Emitter();
let eventName = "say";
emitter.on(eventName, function(){
    console.log("Привет!");
});
emitter.emit(eventName);