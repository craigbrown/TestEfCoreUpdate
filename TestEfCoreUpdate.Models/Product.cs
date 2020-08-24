using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestEfCoreUpdate.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<Variant> Variants { get; set; } = new List<Variant>(0);
    }
}
