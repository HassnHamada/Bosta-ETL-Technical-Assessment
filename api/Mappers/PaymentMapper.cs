using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Payment;
using api.Models;

namespace api.Mappers
{
    public static class PaymentMapper
    {
        public static Payment ToPayment(this PaymentCreateDto paymentCreateDto)
        {
            return new Payment
            {
                Amount = paymentCreateDto.Amount,
                IsPaid = paymentCreateDto.IsPaid,
                PaidAmount = paymentCreateDto.PaidAmount
            };
        }

        public static PaymentGetDto ToPaymentGetDto(this Payment payment)
        {
            return new PaymentGetDto
            {
                Id = payment.Id,
                Amount = payment.Amount,
                IsPaid = payment.IsPaid,
                PaidAmount = payment.PaidAmount
            };
        }
    }
}