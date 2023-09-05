using AutoMapper;
using Movies.BLL.DTO;
using Movies.BLL.Exceptions;
using Movies.BLL.Interfaces;
using Movies.BLL.Interfaces.EntityServices;
using Movies.DAL.Base;
using Movies.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BLL.Services
{
    public class MovieService : IMovieService
    {
        private IUnitOfWork _storage;
        public MovieService(IUnitOfWork storage)
        {
            _storage = storage;
        }
        public void Create(MovieDTO item)
        {
            try
            {
                Validate(item);
                Movie movie = new MapperConfiguration(cfg => cfg.CreateMap<MovieDTO, Movie>())
                    .CreateMapper()
                    .Map<Movie>(item);
                _storage.Movies.Create(movie);
                _storage.Save();
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно добавить фильм. {exception.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _storage.Movies.Delete(id);
                _storage.Save();
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно удалить фильм. {exception.Message}");
            }
        }

        public IEnumerable<MovieDTO> Get()
        {
            try
            {
                var movies = _storage.Movies.Get();
                return new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieDTO>())
                    .CreateMapper()
                    .Map<List<MovieDTO>>(movies);
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно получить фильм. {exception.Message}");
            }
        }

        public MovieDTO Get(int id)
        {
            try
            {
                var movie = _storage.Movies.Get(id);
                return new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieDTO>())
                    .CreateMapper()
                    .Map<MovieDTO>(movie);
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно получить фильм. {exception.Message}");
            }
        }
        public void Update(MovieDTO item)
        {
            try
            {
                Validate(item);
                var movie = new MapperConfiguration(cfg => cfg.CreateMap<MovieDTO, Movie>())
                .CreateMapper()
                .Map<Movie>(item);
                var movieItem = _storage.Movies.Find(m => m.Id == movie.Id).FirstOrDefault();

                movieItem.Name = movie.Name;
                movieItem.Description = movie.Description;
                movieItem.ReleaseYear = movie.ReleaseYear;
                movieItem.Country = movie.Country;
                movieItem.Tagline = movie.Tagline;
                movieItem.Budget = movie.Budget;
                movieItem.Price = movie.Price;
                movieItem.Duration = movie.Duration;
                movieItem.ScreenwriterId = movie.ScreenwriterId;
                movieItem.ProducerId = movie.ProducerId;

                _storage.Movies.Update(movieItem);
                _storage.Save();
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно обновить фильм. {exception.Message}");
            }
        }
        public bool Exists(int id)
        {
            if (_storage.Movies.Find(item => item.Id == id).Count() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Validate(MovieDTO item)
        {
            if (item.Name == null || item.Name.Length < 8)
            {
                throw new ValidationException("Короткое название фильма. Должно быть больше 7 символов", "Фильм");
            }

            if (item.Description == null || item.Description.Length < 8)
            {
                throw new ValidationException("Короткое описание фильма. Должно быть больше 7 символов", "Описание");
            }
            if (item.Country == null || item.Country.Length < 4)
            {
                throw new ValidationException("Короткое название страны. Должно быть больше 3 символов", "Страна");
            }
            if (item.ReleaseYear < 1800 || item.ReleaseYear > 2030)
            {
                throw new ValidationException("Неверный размер. Год выхода должен быть в диапазоне от 1800 до 2030.", "Год выхода");
            }
            if (item.Tagline == null || item.Tagline.Length < 8)
            {
                throw new ValidationException("Неверный слогана. Должно быть больше 7 символов.", "Слоган");
            }

            if (item.Budget < 20000 || item.Budget > 70000)
            {
                throw new ValidationException("Неверный размер. Бюджет должен быть в диапазоне от 20000 до 70000.", "Бюджет");
            }
            if (item.Duration < 60 || item.Duration > 300)
            {
                throw new ValidationException("Неверный размер. Длительность фильма должна быть в диапазоне от 60 до 300.", "Длительность фильма");
            }

            if (item.Price < 1)
            {
                throw new ValidationException("Неверная цена. Цена должна быть положительной", "Size");
            }

            try
            {
                _storage.Screenwriters.Get(item.ScreenwriterId);
            }
            catch
            {
                throw new Exception("Нет такого сценариста");
            }

            try
            {
                _storage.Producers.Get(item.ProducerId);
            }
            catch
            {
                throw new Exception("Нет такого продюссера");
            }
        }

    }
}
