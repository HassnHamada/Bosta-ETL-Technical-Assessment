using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Confirm;
using api.Models;

namespace api.Mappers
{
    public static class ConfirmMapper
    {
        public static Confirm ToConfirm(this ConfirmCreateDto confirmCreateDto)
        {
            return new Confirm
            {
                IsConfirmed = confirmCreateDto.IsConfirmed,
                NumberOfSmsTrials = confirmCreateDto.NumberOfSmsTrials
            };
        }

        public static ConfirmGetDto ToConfirmGetDto(this Confirm confirm)
        {
            return new ConfirmGetDto
            {
                Id = confirm.Id,
                IsConfirmed = confirm.IsConfirmed,
                NumberOfSmsTrials = confirm.NumberOfSmsTrials
            };
        }
    }
}