using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestEfCoreUpdate.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        public string CompanyName { get; set; } = null!;

        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>(0);
    }
}
