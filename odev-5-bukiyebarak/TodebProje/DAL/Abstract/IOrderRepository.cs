using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetAll();

        public void Insert(Order order);
        public void Update(Order order);
        public void Delete(Order order);
        public Order Get ( int id);


    }
}
