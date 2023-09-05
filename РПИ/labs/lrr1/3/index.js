import {func} from "../1/function.js" 
import readline from "readline";

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});
rl.question('Введите x ', (x) => {
    rl.question('Введите у ', (y) => {
        rl.question('Введите z ', (z) => {
            console.log(`При x = ${x} y = ${y}  z= ${z} Ответ `+func(Number(x),Number(y),Number(z)))
            rl.close();
        })
     })
})
