using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Payment
{
    public class PaymentCreateDto
    {
        public required float Amount { get; set; }
        public required bool IsPaid { get; set; }
        public required float PaidAmount { get; set; }
    }
}