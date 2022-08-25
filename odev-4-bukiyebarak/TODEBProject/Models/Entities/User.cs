using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int ShopCartId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [ForeignKey("ShopCartId")]
        public ShopCart ShopCart { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<OrdersProducts> OrdersProducts { get; set; }
     
    }
}
