using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Payment")]
    public class Payment
    {
        public int Id { get; set; }
        public required float Amount { get; set; }
        public required bool IsPaid { get; set; }
        public required float PaidAmount { get; set; }
        public virtual Order? Order { get; set; }
    }
}