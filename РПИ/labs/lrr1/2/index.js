import {func} from "../1/function.js"      
let x=+process.argv[2]
let y=+process.argv[3]
let z=+process.argv[4]
console.log(`При x = ${x} y = ${y}  z= ${z} Ответ `+func(x,y,z))