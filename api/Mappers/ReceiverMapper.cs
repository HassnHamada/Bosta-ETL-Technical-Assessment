using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Receiver;
using api.Models;

namespace api.Mappers
{
    public static class ReceiverMapper
    {
        public static Receiver ToReceiver(this ReceiverCreateDto receiverCreateDto)
        {
            return new Receiver
            {
                FirstName = receiverCreateDto.FirstName,
                LastName = receiverCreateDto.LastName,
                Phone = receiverCreateDto.Phone
            };
        }
        public static ReceiverGetDto ToReceiverGetDto(this Receiver receiver)
        {
            return new ReceiverGetDto
            {
                Id = receiver.Id,
                FirstName = receiver.FirstName,
                LastName = receiver.LastName,
                Phone = receiver.Phone
            };
        }
    }
}