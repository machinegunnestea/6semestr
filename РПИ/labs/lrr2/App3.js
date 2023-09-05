let jsonData = require('./SecondTask.json');
console.log(jsonData);//Object

let arr = JSON.parse(JSON.stringify(jsonData), function (key, value) {
        return value;
    });
console.log(arr);