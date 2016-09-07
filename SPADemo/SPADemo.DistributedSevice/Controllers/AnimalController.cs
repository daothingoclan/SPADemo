using SPADemo.Service;
using SPADemo.Service.Dtos;
using System.Collections.Generic;
using System.Web.Http;

namespace SPADemo.DistributedSevice.Controllers
{
    [RoutePrefix("api/animals")]
    public class AnimalController : ApiController
    {
        private IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            this._animalService = animalService;
        }

        [Route("{id}")]
        [HttpGet]
        public AnimalDto Get(int id)
        {
            return _animalService.GetAnimal(id);
        }

        public void Post([FromBody]AnimalDto animalDto)
        {

        }

        public void Put([FromBody] AnimalDto animalDto)
        {

        }

        public void Delete(int id)
        {

        }
    }
}