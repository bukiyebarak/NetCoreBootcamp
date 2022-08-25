using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class ShopCart
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public ICollection<User> Orders { get; set; }
    }
}