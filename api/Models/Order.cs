using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderType
{
    SEND,
    RECEIVE,
    CANCEL
}

namespace api.Models
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public required int CodId { get; set; }
        public required int ConfirmId { get; set; }
        public required int DropOffAddressId { get; set; }
        public required int PickupAddressId { get; set; }
        public required int ReceiverId { get; set; }
        public required int StarId { get; set; }
        public required OrderType Type { get; set; }
        public required DateTime CollectedFromBusinessDate { get; set; }
        public required DateTime CreatedAtDate { get; set; }
        public required DateTime UpdatedAtDate { get; set; }
        public required string Tracker { get; set; }
        public virtual Payment? Cod { get; set; }
        public virtual Confirm? Confirm { get; set; }
        public virtual Address? DropOffAddress { get; set; }
        public virtual Address? PickupAddress { get; set; }
        public virtual Receiver? Receiver { get; set; }
        public virtual Star? Star { get; set; }
    }
}