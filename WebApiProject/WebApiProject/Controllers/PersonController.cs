using EvoRepository.BusinessEntities;
using EvoRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiProject.Controllers
{
    public class PersonController : ApiController
    {
        PersonRepository personRep;
        public PersonController()
        {
            personRep = new PersonRepository();
        }
        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            var listPeople = personRep.GetPersonList();
            return listPeople;
        }

        // GET: api/Person/5
        public Person Get(int id)
        {
            return personRep.GetPerson(id);
        }

        // POST: api/Person
        public int Post([FromBody] Person value)
        {
            var result = personRep.Post(value);
            return result;
        }

        // PUT: api/Person/5
        [HttpPut]
        public void Put(int id, [FromBody]Person value)
        {
            personRep.Put(id, value);
        }

        // DELETE: api/Person/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            personRep.Delete(id);
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
