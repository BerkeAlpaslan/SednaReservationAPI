using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Reservation.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommandRequest, CreateReservationCommandResponse>
    {
        readonly IReservationWriteRepository _reservationWriteRepository;

        public CreateReservationCommandHandler(IReservationWriteRepository reservationWriteRepository)
        {
            _reservationWriteRepository = reservationWriteRepository;
        }

        public async Task<CreateReservationCommandResponse> Handle(CreateReservationCommandRequest request, CancellationToken cancellationToken)
        {

            var res = new Domain.Entities.Reservation
            {
                UserId = request.UserId,
                RoomId = request.RoomId,
                HotelId = request.HotelId,
                CheckIn = request.CheckIn,
                CheckOut = request.CheckOut,
                TotalPrice = request.TotalPrice,
                Status = request.Status
            };
            await _reservationWriteRepository.AddAsync(res);

            await _reservationWriteRepository.SaveAsync();

            return new()
            {
                Id = res.Id.ToString()
            };
        }
    }
}
