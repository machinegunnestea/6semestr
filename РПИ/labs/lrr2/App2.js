const { CreateFitnessTracker, writeToJSON} = require('./Library');
const fileName = 'SecondTask.json';

let Trackers = CreateFitnessTracker();
writeToJSON(fileName, JSON.stringify(Trackers, null, '\t'));