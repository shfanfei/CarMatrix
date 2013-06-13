using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMatrixCore.DAL;
using CarMatrixData.Models;

namespace CarMatrixServices.Orders
{
    public class OrderService
    {
        private IRepository<Order> orderRepository;
        private readonly ModelsContainer container;

        public OrderService()
        { 
            container = new ModelsContainer();
            orderRepository = new Repository<Order>(container);
        }

        public IEnumerable<string> GetOrdersYears()
        {
            var year = from y in orderRepository.GetEntities
                       select y.BuyTime.ToShortDateString();
            return year.Distinct();
        }
    }
}
