using AutoMapper;
using Movies.BLL.DTO;
using Movies.BLL.Exceptions;
using Movies.DAL.Base;
using Movies.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BLL.Services
{
    public class ScreenwriterService
    {
        private IUnitOfWork _storage;
        public ScreenwriterService(IUnitOfWork storage)
        {
            _storage = storage;
        }
        public void Create(ScreenwriterDTO item)
        {
            try
            {
                Validate(item);
                Screenwriter screenwriter = new MapperConfiguration(cfg => cfg.CreateMap<ScreenwriterDTO, Screenwriter>())
                    .CreateMapper()
                    .Map<Screenwriter>(item);
                _storage.Screenwriters.Create(screenwriter);
                _storage.Save();
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно добавить человека. {exception.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _storage.Screenwriters.Delete(id);
                _storage.Save();
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно удалить человека. {exception.Message}");
            }
        }

        public IEnumerable<ScreenwriterDTO> Get()
        {
            try
            {
                var screenwriters = _storage.Screenwriters.Get();
                return new MapperConfiguration(cfg => cfg.CreateMap<Screenwriter, ScreenwriterDTO>())
                    .CreateMapper()
                    .Map<List<ScreenwriterDTO>>(screenwriters);
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно получить человека. {exception.Message}");
            }
        }

        public ScreenwriterDTO Get(int id)
        {
            try
            {
                var screenwriter = _storage.Screenwriters.Get(id);
                return new MapperConfiguration(cfg => cfg.CreateMap<Screenwriter, ScreenwriterDTO>())
                    .CreateMapper()
                    .Map<ScreenwriterDTO>(screenwriter);
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно получить человека. {exception.Message}");
            }
        }

        void Update(ScreenwriterDTO item)
        {
            try
            {
                Validate(item);
                var screenwriter = new MapperConfiguration(cfg => cfg.CreateMap<ScreenwriterDTO, Screenwriter>())
                .CreateMapper()
                .Map<Screenwriter>(item);
                var personItem = _storage.Screenwriters.Find(m => m.Id == screenwriter.Id).FirstOrDefault();

                personItem.FullName = screenwriter.FullName;
                personItem.YearOfBirth = screenwriter.YearOfBirth;
                personItem.PlaceOfBirth = screenwriter.PlaceOfBirth;

                _storage.Screenwriters.Update(personItem);
                _storage.Save();
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно обновить человека. {exception.Message}");
            }
        }
        public bool Exists(int id)
        {
            if (_storage.Screenwriters.Find(item => item.Id == id).Count() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Validate(ScreenwriterDTO item)
        {
            if (item.FullName == null || item.FullName.Length < 8)
            {
                throw new ValidationException("Короткое имя. Должно быть больше 7 символов", "Имя");
            }
            if (item.PlaceOfBirth == null || item.PlaceOfBirth.Length < 11)
            {
                throw new ValidationException("Короткое название места рождения. Должно быть больше 10 символов", "Место рождения");
            }
            if (item.YearOfBirth < 1930 || item.YearOfBirth > 2023)
            {
                throw new ValidationException("Неверный размер. Год рождения должен быть в диапазоне от 1930 до 2023.", "Год рождения");
            }
        }
    }
}
