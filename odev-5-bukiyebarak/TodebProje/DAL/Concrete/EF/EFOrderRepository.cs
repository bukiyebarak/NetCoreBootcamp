using DAL.Abstract;
using DAL.DbContexts;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EF
{
    public class EFOrderRepository : IOrderRepository
    {
        private TodebDbContext context;

        public EFOrderRepository(TodebDbContext context)
        {
            this.context = context;
        }

        public void Delete(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public void Insert(Order order)
        {
            context.Orders.Add(order);
            //bu olmadan veri tabanında güncelleme sağlanmaz.
            context.SaveChanges();
        }

        public void Update(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }
        public Order Get(int id)
        {
            return context.Orders.FirstOrDefault(x => x.Id == id);

        }
    }
}
