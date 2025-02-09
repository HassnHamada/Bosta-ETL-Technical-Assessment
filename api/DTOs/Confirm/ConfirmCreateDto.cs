using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Confirm
{
    public class ConfirmCreateDto
    {
        public required bool IsConfirmed { get; set; }
        public required int NumberOfSmsTrials { get; set; }
    }
}