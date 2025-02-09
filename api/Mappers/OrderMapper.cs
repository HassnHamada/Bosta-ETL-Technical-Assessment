using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Order;
using api.Models;

namespace api.Mappers
{
    public static class OrderMapper
    {
        public static Order ToOrder(this OrderCreateDto orderCreateDto, int codId, int confirmId, int dropOffAddressId, int pickupAddressId, int receiverId, int starId)
        {
            return new Order
            {
                CodId = codId,
                ConfirmId = confirmId,
                DropOffAddressId = dropOffAddressId,
                PickupAddressId = pickupAddressId,
                ReceiverId = receiverId,
                StarId = starId,
                Type = orderCreateDto.Type,
                CollectedFromBusinessDate =  orderCreateDto.CollectedFromBusinessDate,
                CreatedAtDate = orderCreateDto.CreatedAtDate,
                UpdatedAtDate = orderCreateDto.UpdatedAtDate,
                Tracker = orderCreateDto.Tracker
            };
        }

        public static OrderGetDto ToOrderGetDto(this Order order)
        {
            return new OrderGetDto
            {
                Id = order.Id,
                CodId = order.CodId,
                ConfirmId = order.ConfirmId,
                DropOffAddressId = order.DropOffAddressId,
                PickupAddressId = order.PickupAddressId,
                ReceiverId = order.ReceiverId,
                StarId = order.StarId,
                Type = order.Type,
                CollectedFromBusinessDate = order.CollectedFromBusinessDate,
                CreatedAtDate = order.CreatedAtDate,
                UpdatedAtDate = order.UpdatedAtDate,
                Tracker = order.Tracker
            };
        }
    }
}