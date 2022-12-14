using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Total { get; set; }
        public string Note { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<OrdersProducts> OrdersProducts { get; set; }

    }
}
