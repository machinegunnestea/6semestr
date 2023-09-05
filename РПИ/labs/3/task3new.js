import { EventEmitter } from 'node:events';
import fs from 'fs';


class FitnessTracker{
    constructor(ram, support, sensor){
        this.ram = ram;
        this.support = support;
        this.sensor = sensor;
    }
    toString()
    {
        return `ram: ${this.ram}, support: ${this.support}, sensor ${this.sensor}`
    }
}

class Client{
    constructor(name, journal){
        this.name = name
        this.journal = journal;
        this.log = this.log.bind(this);         
    }

    log(text) {
        fs.appendFile(this.journal , text,(err)=>{}); 
    }       
}

class Store{
    constructor(){
        this.goods = []
        this.emitter = new EventEmitter()        
        this.clients = []   
        this.emitter.on("add", (data)=>{
            this.clients.forEach(element => {
                element.log(data)
            });
        })    
    }

    add(goods)
    {
        this.goods.push(goods)
        this.emitter.emit("add",`\n Добавлен товар: ${this.goods[this.goods.length - 1]} \n в: ${new Date()}`)     
    }
    change(goods)
    {
        this.goods=goods
        this.emitter.emit("add",`\n Товары изменены \n в: ${new Date()}`) 
    }
    addListener(client)
    {
        this.clients.push(client)      
    }
}

let c1 = new Client("первый",'first.txt')
let c2 = new Client("второй",'second.txt')
let c3 = new Client("третий",'third.txt')

let st = new Store();
st.addListener(c1)
st.addListener(c2)
st.addListener(c3)

st.add(new FitnessTracker(1024, "andriod", "accelerometer"))
st.add(new FitnessTracker(512, "ios", "ios"))
st.add(new FitnessTracker(256, "ios", "magnetometer"))

let goods = [
    new FitnessTracker(200, "mi", "magnetometer"),
    new FitnessTracker(400, "mi", "gyroscope")
]
st.change(goods)

