using EvoClientSPA.APIServices;
using EvoClientSPA.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using System.ComponentModel.Composition;

namespace EvoClientSPA.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PersonController : Controller //BaseController<IPersonClientAPIAdapter> 
    {
        private readonly IPersonClientAPIAdapter _personClientAPIAdapter;

        [ImportingConstructor]
        public PersonController(IPersonClientAPIAdapter personClientAPIAdapter)//:base(personClientAPIAdapter)
        {
            _personClientAPIAdapter = personClientAPIAdapter;
        }
        public ActionResult Index()
        {
            IList<PersonVM> listPersons = new List<PersonVM>();
            HttpResponseMessage response = _personClientAPIAdapter.GetResponseFromAPI();
            if (response.IsSuccessStatusCode)
            {
                var persons = response.Content.ReadAsAsync<IEnumerable<PersonVM>>().Result;
                listPersons = persons.ToList();
            }
            return View(listPersons);
        }

        public ActionResult Details(int id)
        {
            PersonVM person = new PersonVM();
            HttpResponseMessage response = _personClientAPIAdapter.GetResponseFromAPI(id.ToString());
            if (response.IsSuccessStatusCode)
            {
                person = response.Content.ReadAsAsync<PersonVM>().Result;
            }
            return View(person);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create

        public async Task<ActionResult> Create(PersonVM model)
        {
            try
            {
                await _personClientAPIAdapter.PostToAPI(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            PersonVM person = new PersonVM();
            HttpResponseMessage response = _personClientAPIAdapter.GetResponseFromAPI(id.ToString());
            if (response.IsSuccessStatusCode)
            {
                person = response.Content.ReadAsAsync<PersonVM>().Result;
            }
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(int Id, PersonVM model)
        {
            try
            {
                _personClientAPIAdapter.EditPerson(model.Id, model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            PersonVM person = new PersonVM();
            HttpResponseMessage response = _personClientAPIAdapter.GetResponseFromAPI(id.ToString());
            if (response.IsSuccessStatusCode)
            {
                person = response.Content.ReadAsAsync<PersonVM>().Result;
            }
            return View(person);
        }

        [HttpPost]
        public ActionResult Delete(int id, PersonVM person)
        {
            try
            {
                var response = _personClientAPIAdapter.DeleteToAPI(id.ToString(), person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
