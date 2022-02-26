using Data_Layer;
using MVC_Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Data_Layer.PersonDA;

namespace MVC_Data_Layer.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            PersonDA dal = new PersonDA();

            var persons = dal.GetPersons();

            List<Person> personList = new List<Person>();

            foreach (var person in persons)
            {
                Person person1 = new Person();

                person1.PersonID = person.PersonID;
                person1.Age = person.Age;
                person1.AddressID = person.AddressID;
                person1.Gender = person.Gender;
                person1.FirstName = person.FirstName;
                person1.LastName = person.LastName;
                person1.EmailID = person.EmailID;

                personList.Add(person1);

            }
            return View(personList);
        }

        

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PersonBO person = new PersonBO();

                    person.FirstName = collection["FirstName"];
                    person.LastName = collection["LastName"];
                    person.Age = Convert.ToInt32(collection["Age"]);
                    person.Gender = collection["Gender"];
                    person.EmailID = collection["EmailID"];
                    person.AddressID = Convert.ToInt32(collection["AddressID"]);


                    PersonDA dal = new PersonDA();

                    dal.InsertPerson(person);

                    RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            PersonDA dal = new PersonDA();

            var personBO = dal.GetPerson(id);

            Person person = new Person()
            {
                PersonID = personBO.PersonID,
                FirstName = personBO.FirstName,
                LastName = personBO.LastName,
                Age = Convert.ToInt32(personBO.Age),
                Gender = personBO.Gender,
                EmailID = personBO.EmailID,
                AddressID = personBO.AddressID
            };

            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                PersonBO person = new PersonBO();

                person.PersonID = Convert.ToInt32(id);
                person.FirstName = collection["FirstName"];
                person.LastName = collection["LastName"];
                person.Age = Convert.ToInt32(collection["Age"]);
                person.Gender = collection["Gender"];
                person.EmailID = collection["EmailID"];
                person.AddressID = Convert.ToInt32(collection["AddressID"]);

                PersonDA dal = new PersonDA();

                dal.UpdatePerson(person);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

        [HttpDelete]
        public ActionResult DeletePerson(int userId)
        {
            PersonDA dal = new PersonDA();

            dal.DeletePerson(userId);

            return null;
        }
    }
}
