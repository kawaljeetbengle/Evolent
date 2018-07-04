using EvoRepository.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EvoRepository.Repository
{
    public class PersonRepository
    {

        public IEnumerable<Person> GetPersonList()
        {
            IList<Person> listPerson = null;
            try
            {
                using (var Entities = new EvoDBEntities())
                {
                    listPerson = Entities.People.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return listPerson;
        }

        public Person GetPerson(int id)
        {
            using (var Entities = new EvoDBEntities())
            {
                var person = Entities.People.FirstOrDefault(x => x.Id == id);
                return person;
            }
        }

        public int Post(Person person)
        {
            using (var Entities = new EvoDBEntities())
            {
                Entities.People.Add(person);
               return Entities.SaveChanges();
            }
        }

        public void Put(int id, Person person)
        {
            using (var Entities = new EvoDBEntities())
            {
                Entities.Entry(person).State = person.Id == 0 ? EntityState.Added : EntityState.Modified;
                Entities.SaveChanges();
            }
        }

        public void Put(Person person)
        {
            using (var Entities = new EvoDBEntities())
            {
                Entities.Entry(person).State = person.Id == 0 ? EntityState.Added : EntityState.Modified;
                Entities.SaveChanges();
            }
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
            
            using (var Entities = new EvoDBEntities())
            {
                var person = new Person { Id = id };
                Entities.Entry(person).State = EntityState.Deleted;
                Entities.SaveChanges();
            }
        }
    }
}
