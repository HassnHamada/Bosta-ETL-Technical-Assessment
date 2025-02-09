using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Order;
using api.Interfaces;
using api.Mappers;
using api.Models;

namespace api.Service
{
    public class OrderService
    {
        private readonly IStarRepository _starRepository;
        private readonly IConfirmRepository _confirmRepository;
        private readonly IReceiverRepository _receiverRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly AddressService _addressService;
        private readonly IAddressRepository _addressRepository;
        public OrderService(AddressService addressService, IAddressRepository addressRepository, IPaymentRepository paymentRepository, IConfirmRepository confirmRepository, IReceiverRepository receiverRepository, IStarRepository starRepository)
        {
            _starRepository = starRepository;
            _confirmRepository = confirmRepository;
            _receiverRepository = receiverRepository;
            _paymentRepository = paymentRepository;
            _addressService = addressService;
            _addressRepository = addressRepository;
        }

        public async Task<Order> NewAsync(OrderCreateDto orderCreateDto)
        {
            var star = await _starRepository.CreateAsync(orderCreateDto.Star.ToStar());
            var confirm = await _confirmRepository.CreateAsync(orderCreateDto.Confirm.ToConfirm());
            var receiver = await _receiverRepository.CreateAsync(orderCreateDto.Receiver.ToReceiver());
            var payment = await _paymentRepository.CreateAsync(orderCreateDto.Cod.ToPayment());
            var dropOffAddress = await _addressService.NewAsync(orderCreateDto.DropOffAddress);
            var pickupAddress = await _addressService.NewAsync(orderCreateDto.PickupAddress);
            dropOffAddress = await _addressRepository.CreateAsync(dropOffAddress);
            pickupAddress = await _addressRepository.CreateAsync(pickupAddress);
            var order = orderCreateDto.ToOrder(payment.Id, confirm.Id, dropOffAddress.Id, pickupAddress.Id, receiver.Id, star.Id);
            return order;
        }
    }
}