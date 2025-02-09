using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Zone
{
    public class ZoneGetDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
}