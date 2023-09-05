const {  calculation } = require('./Library')
const readline = require('readline');
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
})

rl.question(`X = `, x => {
    rl.question(`Y = `, y => {
        rl.question(`Z = `, z => {
            console.log("The answer is ",calculation(x,y,z))
            rl.close()
        })
    })
})
