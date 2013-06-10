using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMatrixCore.DAL;
using CarMatrixData.Models;

namespace CarMatrixServices.Persons
{
    public class PersonService
    {
        private IRepository<Person> _personService;
        private readonly ModelsContainer _container;

        public PersonService()
        {
            this._container = new ModelsContainer();
            this._personService = new Repository<Person>(this._container);
        }

        public IEnumerable<Person> GetPersons()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 1; i++)
            {
                Person p = new Person();
                p.Name = "name" + i.ToString();
                p.Address = "百度大厦";
                p.Lat = 40.056885091681;
                p.Lnt = 116.30814954222;
                persons.Add(p);
            }

            return persons;
            //return this._personService.GetEntities;
        }
    }
}
