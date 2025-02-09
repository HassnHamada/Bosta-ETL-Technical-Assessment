using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.DTOs.Star
{
    public class StarGetDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
    }
}