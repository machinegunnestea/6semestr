const express = require("express");
const movieController = require("../controllers/movieController");

const movieRouter = express.Router();

movieRouter.get("/", movieController.getAllMovies);
movieRouter.get("/input", movieController.getMovieInput);
movieRouter.post("/create", movieController.createMovie);
movieRouter.post("/update", movieController.updateMovie);
movieRouter.post("/delete", movieController.deleteMovie);

module.exports.movieRouter = movieRouter;