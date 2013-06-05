using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMatrixCore.DAL;
using CarMatrixData.Models;

namespace CarMatrixServices.FileOperations
{
    public class FileService
    {
        private IRepository<Car> _carRepository;
        private IRepository<Company> _companyRepository;
        private IRepository<Brands> _brandsRepository;
        private IRepository<CarModel> _carModelRepository;
        private IRepository<Person> _personRepository;
        private IRepository<Order> _orderRepository;

        private readonly ModelsContainer _container;

        public FileService()
        {
            this._container = new ModelsContainer();
            this._carRepository = new Repository<Car>(this._container);
            this._companyRepository = new Repository<Company>(this._container);
            this._brandsRepository = new Repository<Brands>(this._container);
            this._carModelRepository = new Repository<CarModel>(this._container);
            this._personRepository = new Repository<Person>(this._container);
            this._orderRepository = new Repository<Order>(this._container);
        }

        public void CreateCompany(Company company)
        {
            this._companyRepository.Create(company);
        }

        public void CreateOrder(Order order)
        {
            this._orderRepository.Create(order);
        }

        public void CreatePerson(Person person)
        {
            this._personRepository.Create(person);
        }
    }
}
