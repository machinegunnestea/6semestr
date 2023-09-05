const readline = require('readline');

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});


const fs = require('fs')
const filePath = './file.txt'

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
    info(){
        Object.keys(this).forEach(key =>{
            console.log(key+':'+this[key])
        })
        console.log("\n")
    }
}

trackersList = [
    new FitnessTracker("1024", "ios", "Accelerometer",),
    new FitnessTracker("256", "android", "Gyroscope",),
    new FitnessTracker("512", "mi", "Magnetometer",),
]


const questionBar = (data) => {
    rl.question('options: ', message => {
        if (message == 'exit'){
            return rl.close()
        }
        
        if(message == 'add'){
            tracker = new FitnessTracker('128','mi','sensorr')
            trackersList.push(tracker)
            clients.forEach(el =>{
                el.call({type:'add',data:tracker})
                el.writeDiary({type:'add',data:tracker})
            })
        }
        if(message == 'update'){
            let tracker = trackersList[Math.floor(Math.random() * trackersList.length)]
            tracker.RAM = "1024"
            clients.forEach(el =>{
                el.call({type:'update',data:tracker})
                el.writeDiary({type:'update',data:tracker})
            })
        }
        if(message == 'show'){
           trackersList.forEach(b=>b.info())
        }
        questionBar()
      })
}

const task = (filePath) => {
    fs.access(filePath, fs.F_OK, (err) => {
        if (err) {
            fs.open('file.txt', 'w', (error) => {
                if(error) throw error;
                console.log('file created')
            })
        }
        questionBar(trackersList)
    })
}
const EventEmitter = require('events');
const myEmitter = new EventEmitter();

class Client {
    constructor(name){
        this.name = name
    }
    call(obj){
        console.log('клиент : ' + this.name + ' сработало оповещение!')
        switch(obj.type){
            case 'add':
                myEmitter.emit('add',obj.data)
                break
            case 'update':
                myEmitter.emit('update',obj.data)
                break
            default:
                break
        }
              
    }
    writeDiary(obj){
        fs.appendFileSync('file.txt',`${new Date()} | Тип: ${obj.type} | Товар: ${JSON.stringify(obj.data)}\n`)
    }
}

clients = [
    new Client('nestea'),
    new Client('lipton')
]

myEmitter.on('add', (data) => {
    console.log('Товар был добавлен: ', data)
});
myEmitter.on('update', (data) => {
    console.log('Товар был обновлен: ', data)
});



task(filePath)