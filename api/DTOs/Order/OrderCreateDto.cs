using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Order
{
    public class OrderCreateDto
    {
        public required OrderType Type { get; set; }
        public required DateTime CollectedFromBusinessDate { get; set; }
        public required DateTime CreatedAtDate { get; set; }
        public required DateTime UpdatedAtDate { get; set; }
        public required string Tracker { get; set; }
        // public virtual Payment? Cod { get; set; }
        // public virtual Confirm? Confirm { get; set; }
        // public virtual Address? DropOffAddress { get; set; }
        // public virtual Address? PickupAddress { get; set; }
        // public virtual Receiver? Receiver { get; set; }
        // public virtual Star? Star { get; set; }
        
    }
}