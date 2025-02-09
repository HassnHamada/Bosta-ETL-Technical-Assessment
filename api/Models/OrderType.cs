using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("OrderType")]
    public class OrderType
    {
        public int Id { get; set; }
        public required string Type { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}