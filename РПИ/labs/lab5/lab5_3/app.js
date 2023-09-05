const express = require("express");
const { Sequelize } = require('sequelize');

const app = express();
const sequelize = new Sequelize('sqlite:../database/movie.db');

module.exports.sequelize = sequelize;

const { movieRouter } = require("./routes/movieRouter");

app.set("view engine", "hbs");
app.set('views', "./views");

app.use("/css", express.static(__dirname + "/views/css"));
app.use("/js", express.static(__dirname + "/views/js"));
app.use(express.urlencoded({ extended: false }));

app.use("/movie", movieRouter);

app.use((_, response) => {
    response.status(404).send("Page Not Found");
});

sequelize.sync()
.then(() => {
    console.log("Successfully connected to the database...");
    app.listen(3000, () => console.log("Server is listening on port 3000..."));
})
.catch((err) => console.error(err));