using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Confirm")]
    public class Confirm
    {
        public int Id { get; set; }
        public required bool IsConfirmed { get; set; }
        public required int NumberOfSmsTrials { get; set; }
        public virtual Order? Order { get; set; }
    }
}