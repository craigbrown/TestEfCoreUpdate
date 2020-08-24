using System.ComponentModel.DataAnnotations;

namespace TestEfCoreUpdate.Models
{
    public class Variant
    {
        [Key]
        public int VariantId { get; set; }

        public string Name { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}
