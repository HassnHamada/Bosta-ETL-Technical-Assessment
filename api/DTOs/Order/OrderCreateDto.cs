using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Address;
using api.DTOs.Confirm;
using api.DTOs.OrderType;
using api.DTOs.Payment;
using api.DTOs.Receiver;
using api.DTOs.Star;

namespace api.DTOs.Order
{
    public class OrderCreateDto
    {
        public required DateTime CollectedFromBusinessDate { get; set; }
        public required DateTime CreatedAtDate { get; set; }
        public required DateTime UpdatedAtDate { get; set; }
        public required string Tracker { get; set; }
        public required PaymentCreateDto Cod { get; set; }
        public required ConfirmCreateDto Confirm { get; set; }
        public required AddressCreateDto DropOffAddress { get; set; }
        public required AddressCreateDto PickupAddress { get; set; }
        public required ReceiverCreateDto Receiver { get; set; }
        public required StarCreateDto Star { get; set; }
        public required OrderTypeCreateDto Type { get; set; }
    }
}