using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.OrderType
{
    public class OrderTypeCreateDto
    {
        public required string Type { get; set; }
    }
}