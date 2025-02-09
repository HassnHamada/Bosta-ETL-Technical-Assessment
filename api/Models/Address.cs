using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Address")]
    public class Address
    {
        public int Id { get; set; }
        public required int Floor { get; set; }
        public required int Apartment { get; set; }
        public required string FirstLine { get; set; }
        public required string Secondline { get; set; }
        public required int DistrictId { get; set; }
        public required int CityId { get; set; }
        public required int ZoneId { get; set; }
        public required int CountryId { get; set; }
        public required float latitude { get; set; }
        public required float longitude { get; set; }
        public virtual District? District { get; set; }
        public virtual City? City { get; set; }
        public virtual Zone? Zone { get; set; }
        public virtual Country? Country { get; set; }
        public virtual ICollection<Order>? Order { get; set; }
    }
}