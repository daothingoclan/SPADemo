using SPADemo.Data.Infrastructure;
using SPADemo.Domain;
using SPADemo.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPADemo.Service
{
    public interface IAnimalService
    {
        void CreateAnimal(AnimalDto animalDto);

        AnimalDto GetAnimal(int id);
    }

    public class AnimalService : IAnimalService
    {
        private IRepository _animalRepo;

        public AnimalService(IRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }

        public void CreateAnimal(AnimalDto animalDto)
        {
            var animal = AutoMapper.Mapper.Map<Animal>(animalDto);
            using (var uow = _animalRepo.CreateUnitOfWork())
            {
                _animalRepo.Add(animal);
                uow.Commit();
            }
        }

        public AnimalDto GetAnimal(int id)
        {
            var animal = _animalRepo.GetById<Animal>(id);
            return AutoMapper.Mapper.Map<AnimalDto>(animal);
        }
    }
}
