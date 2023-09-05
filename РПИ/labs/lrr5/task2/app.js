const express = require("express");
const { Sequelize, DataTypes } = require('sequelize');

const isTest = process.argv.slice(-1)[0] === "--test";
const app = express();
const sequelize = new Sequelize('sqlite:./database/movie.db', { logging: !isTest });

const Movie = sequelize.define('Movie', {
    Id: {
        type: DataTypes.INTEGER,
        autoIncrement: true,
        primaryKey: true,
        allowNull: false        
    },
    Name:{
        type: DataTypes.TEXT,
        allowNull: false
    },
    Price:{
        type: DataTypes.INTEGER,
        allowNull: false
    },
    Description:{
        type: DataTypes.TEXT,
        allowNull: false
    },
    Genre:{
        type: DataTypes.TEXT,
        allowNull: false
    }
},{
    timestamps: false
})

function isMovieValid(movie){
    return movie && Number.isInteger(movie.id) && movie.id >= 0 && movie.name !== undefined
    && movie.description !== undefined && Number.isInteger(movie.price) && movie.price >= 0 &&
    movie.genre !== undefined;
}
function getObjectFromModel(model) {
    return { 
        id: model.Id, 
        name: model.Name, 
        price: model.Price,
        description: model.Description, 
        genre: model.Genre
    };
}

app.use(express.json());

app
    .route("/movie")
    .get((request, response) => {
        const id = request.query.id;

        if(id) {
            Movie.findOne({where: {Id: id}})
            .then((model) =>{
                if(model === null){
                    response.status(404).send(`Movie with 'id' = ${id} not found.`);
                    return;
                }

                response.status(200).json({ movie: getObjectFromModel(model) });
            })
            .catch((err) => response.status(500).send(err.message));
        }

        else{
            Movie.findAll()
            .then((models) =>{
                let array = [];
                models.forEach((model) => array.push(getObjectFromModel(model)));
                response.status(200).json({ movies: array });               
            })
            .catch((err) => response.status(500).send(err.message));
        }
    })
    .post((request, response) =>{
        const movie = request.body.movie;

        if(isMovieValid(movie)){
            Movie.findOrCreate({
                where: {Id: movie.id},
                defaults:{
                    Id: model.id, 
                    Name: model.name, 
                    Price: model.price,
                    Description: model.description, 
                    Genre: model.genre
                }
            })
            .then((result) => {
                if (result[1] === false) {
                    response.status(400).send(`Movie with 'id' = ${movie.id} already exists in the database.`);
                    return;
                }

                response.status(200).send(`Movie with 'id' = ${movie.id} was successfully added to the database.`);
            })
            .catch((err) => response.status(500).send(err.message));
        }
        else{
            response.status(400).send("Bad request body: 'movie' not present correctly.");
        }
    })
    .put((request, response) =>{
        const movie = request.body.movie;
        
        if(isMovieValid(movie)){
            Movie.update({
                Name: model.name, 
                Price: model.price,
                Description: model.description, 
                Genre: model.genre
            },{
                where: {
                    Id: movie.id
                }
            })            

            .then((count) => {
                if (count == 0) {
                    response.status(404).send(`Movie with 'id' = ${movie.id} not found in the database.`);
                    return;
                }
                response.status(200).send(`Movie with 'id' = ${movie.id} was successfully updated.`);
            })
            .catch((err) => response.status(500).send(err.message));
        }
        else{
            response.status(400).send("Bad request body: 'movie' not present correctly.");
        }
    })
    .delete((request, response) =>{
        const id = request.query.id;

        if(id){
            Movie.destroy({where: {Id : id}})
            .then(count => {
                if(count ==0){
                    response.status(404).send(`Movie with 'id' = ${movie.id} not found in the database.`);
                    return;
                }

                response.status(200).send(`Movie with 'id' = ${movie.id} was successfully deleted.`);
            })
            .catch((err) => response.status(500).send(err.message));
        }
        
        else{
            response.status(400).send("Bad delete request body: 'must contains 'id' parameter.");
        }
    });
sequelize.sync()
.then(() =>{
    if(!isTest){
        console.log("Successfully connected to the database...");
        app.listen(3000, () => console.log("Server is listening on port 3000..."));
    }
})
.catch((err) => console.error(err));

if(!isTest){
    module.exports.app = app;  
}