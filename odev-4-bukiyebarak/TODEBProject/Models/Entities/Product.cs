using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
       
        public string Detail { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }

        public ICollection<ShopCart> ShopCarts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<OrdersProducts> OrdersProducts { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


    }
}
