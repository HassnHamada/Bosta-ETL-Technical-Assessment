using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Zone;
using api.Models;

namespace api.Mappers
{
    public static class ZoneMapper
    {
        public static Zone ToZone(this ZoneCreateDto zoneCreateDto)
        {
            return new Zone
            {
                Name = zoneCreateDto.Name
            };
        }

        public static ZoneGetDto ToZoneGetDto(this Zone zone)
        {
            return new ZoneGetDto
            {
                Id = zone.Id,
                Name = zone.Name
            };
        }
    }
}