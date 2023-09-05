using Microsoft.EntityFrameworkCore;
using Movies.DAL.Base;
using Movies.DAL.Context;
using Movies.DAL.Models;
using Movies.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.UnitsOfWork
{
    public class MovieCardDbUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private MovieDbRepository _movies;
        private ScreenwriterDbRepository _screenwriters;
        private ProducerDbRepository _producers;

        public MovieCardDbUnitOfWork(string connection)
        {
            _context = new AppDbContext(new DbContextOptionsBuilder()
                .UseSqlServer(connection)
                .Options);
        }

        public IRepository<Movie> Movies
        {
            get
            {
                if (_movies == null)
                {
                    _movies = new MovieDbRepository(_context);
                }
                return _movies;
            }
        }

        public IRepository<Producer> Producers
        {
            get
            {
                if (_producers == null)
                {
                    _producers = new ProducerDbRepository(_context);
                }
                return _producers;
            }
        }

        public IRepository<Screenwriter> Screenwriters
        {
            get
            {
                if (_screenwriters == null)
                {
                    _screenwriters = new ScreenwriterDbRepository(_context);
                }
                return _screenwriters;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
