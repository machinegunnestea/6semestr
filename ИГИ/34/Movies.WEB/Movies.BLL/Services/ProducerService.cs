using AutoMapper;
using Movies.BLL.DTO;
using Movies.BLL.Exceptions;
using Movies.BLL.Interfaces;
using Movies.DAL.Base;
using Movies.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BLL.Services
{
    public class ProducerService
    {
        private IUnitOfWork _storage;
        public ProducerService(IUnitOfWork storage)
        {
            _storage = storage;
        }
        public void Create(ProducerDTO item)
        {
            try
            {
                Validate(item);
                Producer producer = new MapperConfiguration(cfg => cfg.CreateMap<ProducerDTO, Producer>())
                    .CreateMapper()
                    .Map<Producer>(item);
                _storage.Producers.Create(producer);
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
                _storage.Producers.Delete(id);
                _storage.Save();
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно удалить человека. {exception.Message}");
            }
        }

        public IEnumerable<ProducerDTO> Get()
        {
            try
            {
                var producers = _storage.Producers.Get();
                return new MapperConfiguration(cfg => cfg.CreateMap<Producer, ProducerDTO>())
                    .CreateMapper()
                    .Map<List<ProducerDTO>>(producers);
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно получить человека. {exception.Message}");
            }
        }

        public ProducerDTO Get(int id)
        {
            try
            {
                var producer = _storage.Producers.Get(id);
                return new MapperConfiguration(cfg => cfg.CreateMap<Producer, ProducerDTO>())
                    .CreateMapper()
                    .Map<ProducerDTO>(producer);
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно получить человека. {exception.Message}");
            }
        }

        void Update(ProducerDTO item)
        {
            try
            {
                Validate(item);
                var producer = new MapperConfiguration(cfg => cfg.CreateMap<ProducerDTO, Producer>())
                .CreateMapper()
                .Map<Producer>(item);
                var personItem = _storage.Producers.Find(m => m.Id == producer.Id).FirstOrDefault();

                personItem.FullName = producer.FullName;
                personItem.YearOfBirth = producer.YearOfBirth;
                personItem.PlaceOfBirth = producer.PlaceOfBirth;

                _storage.Producers.Update(personItem);
                _storage.Save();
            }
            catch (Exception exception)
            {
                throw new EntityServiceException($"Невозможно обновить человека. {exception.Message}");
            }
        }
        public bool Exists(int id)
        {
            if (_storage.Producers.Find(item => item.Id == id).Count() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Validate(ProducerDTO item)
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
