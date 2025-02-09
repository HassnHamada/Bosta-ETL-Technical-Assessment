using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Star
{
    public class StarCreateDto
    {
        public required string Name { get; set; }
        public required string Phone { get; set; }
    }
}