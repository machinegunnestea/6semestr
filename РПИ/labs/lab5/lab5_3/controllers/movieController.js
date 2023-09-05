const { is } = require("express/lib/request");
const { Movie } = require("../models/movie");


function isMovieValid(movie){
    let id = Number(movie.id);
    let price = Number(movie.price);
    console.error(id)
    console.error(Number.isInteger(id))
    console.error(isNaN(price))
    movie.id = id;
    movie.price = price;
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

module.exports.getAllMovies = (_, response) => {
    Movie.findAll()
    .then((models) => {
        let array = [];
        models.forEach((model) => array.push(getObjectFromModel(model)));
        response.render("movies.hbs", {
            movies: array
        });
    })
    .catch((err) => response.status(500).send(err));
};


module.exports.getMovieInput = (request, response) => {
    const action = request.query.action;

    if (action && (action === "create" || action === "update")) {
        if (action === "create") {
            response.render("input.hbs", {
                path: "create"
            });
        }
        else if (request.query.id) {
            Movie.findOne({ where: { Id: request.query.id }})
            .then((model) => {
                if (model === null) {
                    response.status(404).send(`Movie with 'id' = ${id} not found.`);
                    return;
                }

                response.render("input.hbs", {
                    path: "update",
                    tour: getObjectFromModel(model)
                });
            })
            .catch((err) => response.status(500).send(err.message));
        }
        else {
            response.status(400).send("Bad request: must contains 'id' parameter.");
        }
    }
    else {
        response.status(400).send("Bad request: must contains 'action' parameter.");
    }
};

module.exports.createMovie = (request, response) => {
    const body = request.body;

    if (isMovieValid(body)) {
        
        Movie.findOrCreate({
            where: {Id: body.id},
            defaults:{
                Id: body.id, 
                Name: body.name, 
                Price: body.price,
                Description: body.description, 
                Genre: body.genre
            }
        })
        .then((result) => {
            if (result[1] === false) {
                response.status(400).send(`Movie with 'id' = ${body.id} already exists in the database.`);
                return;
            }
            response.redirect("/movie");
        })
        .catch((err) => response.status(500).send(err.message));
    }
    else {
        response.status(400).send("Bad request body: parameters not present correctly.");
    }
};

module.exports.updateMovie = (request, response) => {
    const body = request.body;
        
    if (isMovieValid(body)) {
        
        Movie.update({
            Name: body.name, 
            Price: body.price,
            Description: body.description, 
            Genre: body.genre
        },{
            where: {
                Id: body.id
            }
        })    
        .then(count => {
            if (count == 0) {
                response.status(404).send(`Movie with 'id' = ${body.id} not found.`);
                return;
            }

            response.redirect("/movie");
        })
        .catch((err) => response.status(500).send(err.message));
    }
    else {
        response.status(400).send("Bad request body: parameters not present correctly.");
    }
};

module.exports.deleteMovie = (request, response) => {
    const id = request.body.id;

    if (id) {
        Movie.destroy({ where: { Id: id } })
        .then(count => {
            if (count == 0) {
                response.status(404).send(`Movie with 'id' = ${id} not found.`);
                return;
            }

            response.redirect("/movie");
        })
        .catch((err) => response.status(500).send(err.message));
    }
    else {
        response.status(400).send("Bad request body: must contains 'id' parameter.");
    }
};