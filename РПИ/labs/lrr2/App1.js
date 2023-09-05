const { newFile, writeErrors } = require('./Library');
const readline = require('readline');
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
})
const fileName = "FirstTask.txt";
rl.question(`Please, enter your error: `, answ => {
    newFile(fileName);
    writeErrors(fileName, answ);
    rl.close();
})