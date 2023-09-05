const express = require("express");
const sqlite3 = require("sqlite3");

const isTest = process.argv.slice(-1)[0] === "--test";
const app = express();
const db = new sqlite3.Database("./database/movie.db", (err) => {
    if (err) {
        console.error(err.message);
        return;
    }

    if (!isTest) {
        console.log("Successfully connected to the database...");
    }
});

function isMovieValid(movie){
    return movie && Number.isInteger(movie.id) && movie.id >= 0 && movie.name !== undefined
    && movie.description !== undefined && Number.isInteger(movie.price) && movie.price >= 0 &&
    movie.genre !== undefined;
}
function getObjectFromRow(row) {
    return { 
        id: row.Id, 
        name: row.Name, 
        price: row.Price,
        description: row.Description, 
        genre: row.Genre
    };
}

app.use(express.json());

app
    .route("/movie")
    .get((request, response) => {
        const id = request.query.id;

        if(id) {
            db.serialize(function() {
                db.get("SELECT * FROM Movie WHERE Id = ?;", id, (err, row) =>{
                    if(err){
                        response.status(500).send(err.message);
                        return;
                    }
                    if (row === undefined) {
                        response.status(404).send(`Movie with 'id' = ${id} not found.`);
                        return;                     
                    }
                    response.status(200).json({ movie: getObjectFromRow(row) });
                })
            })
        }
        else{
            db.serialize(function() {
                db.all("SELECT * FROM Movie;", (err, rows) => {
                    if (err) {
                        response.status(500).send(err.message);
                        return;
                    }
                    
                    let array = [];
                    rows.forEach((row) => array.push(getObjectFromRow(row)));
                    response.status(200).json({ movies: array });
                });
            });
        }
    })
    .post((request, response) =>{
        const movie = request.body.movie;

        if(isMovieValid(movie)){
            db.serialize(function() {
                db.get("SELECT COUNT(*) AS 'Count' FROM Movie WHERE Id = ?;", movie.id, (err, row) => {
                    if (err) {
                        response.status(500).send(err.message);
                        return;
                    }

                    if (row.Count != 0) {
                        response.status(400).send(`Movie with 'id' = ${movie.id} is already exists in the database.`);
                        return;
                    }

                    db.run("INSERT INTO Movie VALUES(?, ?, ?, ?, ?);", [ movie.id, movie.name, movie.price, movie.description, movie.genre ], (err) => {
                        if (err) {
                            response.status(500).send(err.message);
                            return;
                        }

                        response.status(200).send(`Movie with 'id' = ${movie.id} was successfully added to the database.`);
                    });
                });
            });
        }
        else{
            response.status(400).send("Bad request body: 'movie' not present correctly.");
        }
    })
    .put((request, response) =>{
        const movie = request.body.movie;
        if(isMovieValid(movie)){
            db.serialize(function() {
                db.get("SELECT COUNT(*) AS 'Count' FROM Movie WHERE Id = ?;", movie.id, (err, row) => {
                    if (err) {
                        response.status(500).send(err.message);
                        return;
                    }

                    if (row.Count == 0) {
                        response.status(400).send(`Movie with 'id' = ${movie.id} is not found in the database.`);
                        return;
                    }

                    db.run("UPDATE Movie SET Name = ?, Price = ?, Description = ?, Genre = ? WHERE Id = ?;", 
                    [ movie.name, movie.price, movie.description, movie.genre, movie.id ], (err) => {
                        if (err) {
                            response.status(500).send(err.message);
                            return;
                        }

                        response.status(200).send(`Movie with 'id' = ${movie.id} was successfully updated.`);
                    });
                });
            });
        }
        else{
            response.status(400).send("Bad request body: 'movie' not present correctly.");
        }
    })
    .delete((request, response) =>{
        const id = request.query.id;

        if(id){
            db.serialize(function() {
                db.get("SELECT COUNT(*) AS 'Count' FROM Movie WHERE Id = ?;", movie.id, (err, row) => {
                    if (err) {
                        response.status(500).send(err.message);
                        return;
                    }

                    if (row.Count == 0) {
                        response.status(400).send(`Movie with 'id' = ${movie.id} is not found in the database.`);
                        return;
                    }

                    db.run("DELETE FROM Movie WHERE Id = ?;", id, (err) => {
                        if (err) {
                            response.status(500).send(err.message);
                            return;
                        }

                        response.status(200).send(`Movie with 'id' = ${movie.id} was successfully deleted.`);
                    });
                });
            });
        }
        else{
            response.status(400).send("Bad request body: 'request must contains 'id' parameter.");
        }
    });
    if(!isTest){
        app.listen(3000, () => console.log("Server is listening on port 3000"));
    }
    else{
        module.exports.app = app;    }