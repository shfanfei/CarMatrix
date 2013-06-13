using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMatrixData.Models;

namespace CarMatrixServices.Tests
{
    public class Init
    {
        private static Init instance;
        private Init()
        {
            InitDatas();
        }

        private IList<Person> persons;
        private IList<Order> orders;
        private IList<Car> cars;
        private IList<Company> company;
        private IList<CarModel> models;
        private IList<Brands> brands;

        public static Init Instance
        {
            get
            {
                if (instance == null)
                    instance = new Init();
                return instance;
            }
        }

        private void InitDatas()
        {
            company = new List<Company>();
            persons = new List<Person>();
            orders = new List<Order>();
            cars = new List<Car>();
            models = new List<CarModel>();
            brands = new List<Brands>();



        }
    }
}
