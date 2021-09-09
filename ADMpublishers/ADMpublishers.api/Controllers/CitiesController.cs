using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ADMpublishers.Data;
using ADMpublishers.Data.Dto;
using ADMpublishers.Data.MapperConfigurations;
using ADMpublishers.Data.Models;
using ADMpublishers.Data.Repositories;

namespace ADMpublishers.api.Controllers
{
    public class CitiesController : ApiController
    {
        private ICityReposity _repository;

        public CitiesController(ICityReposity repository)
        {
            _repository = repository;
        }

        // GET: api/Cities
        public IEnumerable<CityDto> Get()
        {
            return Mapping.Mapper.Map<List<City>,List<CityDto>>(_repository.GetAll().ToList());
        }

        // GET: api/Cities/5
        [ResponseType(typeof(CityDto))]
        public async Task<IHttpActionResult> Get(int id)
        {
            City city = await _repository.GetByID(id);

            if (city == null)
            {
                return NotFound();
            }
            var citydto = Mapping.Mapper.Map<City, CityDto>(city);
            return Ok(citydto);
        }

        // PUT: api/Cities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(int id, CityDto citydto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != citydto.Id)
            {
                return BadRequest();
            }

         

            try
            {
                var city = Mapping.Mapper.Map<CityDto, City>(citydto);
                await _repository.update(city);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.CityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cities
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> Post(CityDto citydto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = Mapping.Mapper.Map<CityDto, City>(citydto);
            await _repository.Add(city);

            return CreatedAtRoute("DefaultApi", new { id = city.Id }, citydto);
        }

        // DELETE: api/Cities/5
        [ResponseType(typeof(CityDto))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            City city = await _repository.remove(id);

            var citydto = Mapping.Mapper.Map<City, CityDto>(city);

            return Ok(citydto);
        }

  

    }
}