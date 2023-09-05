using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    internal class MovieRentDbUnitOfWork : IUnitOfWork
    {
        private readonly MovieRentContext movieRentContext;
        private MovieRepository? movieRepository;
        private MovieTypeRepository? movieTypeRepository;
        private UserRepository? userRepository;
        public MovieRentDbUnitOfWork(string connection)
        {
            movieRentContext = new MovieRentContext(new DbContextOptionsBuilder()
                .UseSqlServer(connection)
                .Options);
        }
        public IRepository<Movie> Movie
        {
            get
            {
                if (movieRepository == null)
                {
                    movieRepository = new MovieRepository(movieRentContext);
                }
                return movieRepository;
            }
        }


        public IRepository<MovieType> MovieType
        {
            get
            {
                if (movieTypeRepository == null)
                {
                    movieTypeRepository = new MovieTypeRepository(movieRentContext);
                }
                return movieTypeRepository;
            }
        }

        public IRepository<User> User
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(movieRentContext);
                }
                return userRepository;
            }
        }

        public void Save()
        {
            movieRentContext.SaveChanges();
        }
    }
}
