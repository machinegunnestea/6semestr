
const { makeDirectiryApps, makeDirectiryFiles, fromDir, fs} = require('./Library');
const nameDir = 'src';
const nameForFiles = 'dist';
makeDirectiryApps(nameDir);
makeDirectiryApps(nameForFiles);
  
fromDir('./',/\.js$/, function(fileName){
    fs.copyFile(fileName, `./${nameDir}/${fileName}`, (err) => {
        if (err) throw err;
      console.log('File was copied');});
});

fromDir('./',/\.json$/, function(fileName){
    fs.copyFile(fileName, `./${nameForFiles}/${fileName}`, (err) => {
        if (err) throw err;
      console.log('File was copied');});
});

fromDir('./',/\.txt$/, function(fileName){
    fs.copyFile(fileName, `./${nameForFiles}/${fileName}`, (err) => {
        if (err) throw err;
      console.log('File was copied');});
});
