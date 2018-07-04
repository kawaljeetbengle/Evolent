
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiProject;
using WebApiProject.Controllers;
using EvoRepository.BusinessEntities;
using System.Collections.Generic;

using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Configuration;
using System;

namespace WebApiProject.Tests.Controllers
{
    [TestClass]
    public class PersonControllerTest
    {
        private static string WebAPIurl
        {
            get { return ConfigurationManager.AppSettings["WebApiurl"]; }
        }
        [TestMethod]
        public void Get()
        {
            // Arrange
            PersonController controller = new PersonController();

            // Act
            IEnumerable<Person> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
        }

        [TestMethod]
        public void GetById()
        {
            PersonController controller = new PersonController();
            Person result = controller.Get(17);

            Assert.AreEqual("Nice", result.FirstName);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            PersonController controller = new PersonController();
            Person per = new Person() { Id = 0, FirstName = "Rohan", LastName = "Jas", Phone = "5614456156", EmailAddress = "email@email.com", Status = true };

            //controller.Post(per);
            IEnumerable<Person> resultBeforepost = controller.Get();
            controller.Post(per);
            IEnumerable<Person> resultAfterpost = controller.Get();

            Assert.AreEqual(resultBeforepost.Count()+1, resultAfterpost.Count()); 
            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            PersonController controller = new PersonController();
            int id =4;
            Person per = new Person() { Id=4, FirstName="johan", LastName="Jill", Phone="5614456156", EmailAddress="email", Status=true};
            controller.Put(id, per);

            Person result = controller.Get(4);

            Assert.AreEqual("johan", result.FirstName);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            PersonController controller = new PersonController();

            controller.Delete(18);
            Person per = controller.Get(18);
            Assert.AreEqual(null, per);
        }
    }
}
