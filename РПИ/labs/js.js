const {  calculation } = require('./Library')

const args =  process.argv.slice(2)

console.log(calculation(args[0],args[1],args[2]))

