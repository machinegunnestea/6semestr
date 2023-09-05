const { DataTypes } = require('sequelize');
const { sequelize } = require("../app");

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
});

module.exports.Movie = Movie;