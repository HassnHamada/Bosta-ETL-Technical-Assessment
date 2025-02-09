using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Country
{
    public class CountryGetDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
}