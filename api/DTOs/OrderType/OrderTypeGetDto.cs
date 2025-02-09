using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.OrderType
{
    public class OrderTypeGetDto
    {
        public required int Id { get; set; }
        public required string Type { get; set; }
    }
}