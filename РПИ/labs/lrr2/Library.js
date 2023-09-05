const fs = require("fs"), path = require('path');

const newFile = (fileName) => {
    fs.access(fileName, function(error){
        if (error) {
            fs.writeFile(fileName, '', (err) => {
                if (err)
                    console.log (err);
                else
                    console.log('file was created succesfully');
            });
        } else {
            console.log("file was found");
        }
    });}

const writeErrors = (fileName, error) => {
    fs.appendFile(fileName, `\n${error} ${new Date()}`, (err)=>{
    if (err)
        console.log (err);
    else
        console.log ('file was changed');
});}

const writeToJSON = (fileName, strings) => {
  fs.writeFile(fileName, strings, (err) => {
    if (err)
        console.log (err);
    else
        console.log('file was created succesfully');
});
}





class FitnessTracker{
    constructor(ram, support, sensor){
        this.ram = ram;
        this.support = support;
        this.sensor = sensor;
    }
    get RAM(){
        return this.ram;
    }
    set RAM(rams){
        this.ram = rams;
    }
    get Support(){
        return this.support;
    }
    set Support(supports){
        this.support = supports;
    }
    get Sensors(){
        return this.sensor;
    }
    set RAM(sensors){
        this.sensor = sensors;
    }
}

function CreateFitnessTracker(){
    let arrayTracker = [];
    arrayTracker[0] = new FitnessTracker(
        "1024",
        "ios",
        "Accelerometer"
    );
    arrayTracker[1] = new FitnessTracker(
        "256",
        "android",
        "Gyroscope"
    );
    arrayTracker[2] = new FitnessTracker(
        "512",
        "mi",
        "Magnetometer"
    );
    return arrayTracker;
}

module.exports = { fs, newFile, writeErrors, FitnessTracker, CreateFitnessTracker, writeToJSON, makeDirectiryApps, makeDirectiryFiles, fromDir }
