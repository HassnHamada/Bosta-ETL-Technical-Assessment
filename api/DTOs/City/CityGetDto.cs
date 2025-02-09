using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.City
{
    public class CityGetDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
}