const calculation = (x, y, z) => {
    let b = (Math.log(Math.sqrt(x)+Math.sqrt(y)+2))/Math.abs(2+z);
    return b;
}

module.exports = { calculation }
