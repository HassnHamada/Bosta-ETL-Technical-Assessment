using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace api.DTOs.Order
{
    public class OrderGetDto
    {
        public required int Id { get; set; }
        public required int CodId { get; set; }
        public required int ConfirmId { get; set; }
        public required int DropOffAddressId { get; set; }
        public required int PickupAddressId { get; set; }
        public required int ReceiverId { get; set; }
        public required int StarId { get; set; }
        public required int TypeId { get; set; }
        public required DateTime CollectedFromBusinessDate { get; set; }
        public required DateTime CreatedAtDate { get; set; }
        public required DateTime UpdatedAtDate { get; set; }
        public required string Tracker { get; set; }
    }
}