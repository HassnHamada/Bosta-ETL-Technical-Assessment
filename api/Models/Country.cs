using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Country")]
    public class Country
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<Address>? Addresses { get; set; }
    }
}