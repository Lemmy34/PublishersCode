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
    public class AuthorsController : ApiController
    {
        private IAuthorRepository _repository;

        public AuthorsController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Authors
        public IEnumerable<AuthorDto> Get()
        {
            return Mapping.Mapper.Map<List<Author>,List<AuthorDto>>(_repository.GetAll().ToList());
        }

        // GET: api/Authors/5
        [ResponseType(typeof(AuthorDto))]
        public async Task<IHttpActionResult> Get(string id)
        {
            Author author = await _repository.GetByID(id);

            if (author == null)
            {
                return NotFound();
            }
            var authordto = Mapping.Mapper.Map<Author, AuthorDto>(author);
            return Ok(authordto);
        }

        // PUT: api/Authors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(string id, AuthorDto authordto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authordto.au_id)
            {
                return BadRequest();
            }

          
            try
            {
                var author = Mapping.Mapper.Map<AuthorDto, Author>(authordto);
                await _repository.update(author);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.AuthorExists(id))
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

        // POST: api/Authors
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> Post(AuthorDto authordto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                var author = Mapping.Mapper.Map<AuthorDto, Author>(authordto); 
                await _repository.Add(author);
            }
            catch (DbUpdateException)
            {
                if (_repository.AuthorExists(authordto.au_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = authordto.au_id }, authordto);
        }

        // DELETE: api/Authors/5
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> Delete(string id)
        {

            Author author = await _repository.remove(id);

            var authordto = Mapping.Mapper.Map<Author, AuthorDto>(author);

            return Ok(authordto);
        }


  
    }
}