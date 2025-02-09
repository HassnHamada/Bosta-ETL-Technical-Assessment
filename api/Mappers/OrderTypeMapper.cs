using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.OrderType;
using api.Models;

namespace api.Mappers
{
    public static class OrderTypeMapper
    {
        public static OrderType ToOrderType(this OrderTypeCreateDto orderTypeCreateDto)
        {
            return new OrderType
            {
                Type = orderTypeCreateDto.Type
            };
        }

        public static OrderTypeGetDto ToOrderTypeGetDto(this OrderType orderType)
        {
            return new OrderTypeGetDto
            {
                Id = orderType.Id,
                Type = orderType.Type
            };
        }
    }
}