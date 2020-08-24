using System.ComponentModel.DataAnnotations;

namespace TestEfCoreUpdate.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        public Company Company { get; set; } = null!;

        public Product Product { get; set; } = null!;

        public Variant? Variant { get; set; }
    }
}
