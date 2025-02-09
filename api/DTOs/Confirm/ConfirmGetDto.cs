using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Confirm
{
    public class ConfirmGetDto
    {
        public required int Id { get; set; }
        public required bool IsConfirmed { get; set; }
        public required int NumberOfSmsTrials { get; set; }
    }
}