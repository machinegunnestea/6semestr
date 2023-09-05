const fs = require('fs');

function executeTime( startTime){
    const stop = (new Date()).getTime();
    console.log(` время ${stop-startTime} мс`)
}
function sayImmediate() {

}

function Immediate() {
  let startTime = performance.now()
  setImmediate(sayImmediate)
  let endTime = performance.now()
  console.log("Время setImmidiate = " + (endTime - startTime));
}

let temptime = 1000
const startFirst = (new Date()).getTime();
setTimeout(executeTime, temptime, startFirst);
const startSecond = (new Date()).getTime();
setTimeout(executeTime, temptime * 3, startSecond);
const startThird = (new Date()).getTime();
setTimeout(executeTime, temptime * 5, startThird);



let startTimer = performance.now()
fs.readFile("task1out.txt", "utf-8", function (err, data) {
  if (err)
    throw err;
  else
  {
    let endTime = performance.now()
    console.log("Время чтения = " + (endTime - startTimer));
    console.log(data)

  }
  
  
});
let startTimew = performance.now()
fs.writeFile("task1in.txt", "TEXT TEST TEXT", (err) => {
    if (err)
      console.log(err);
    else
      {
        let endTime = performance.now()
        console.log("Время записи = " + (endTime - startTimew));
      }
    
  });
  
  Immediate()