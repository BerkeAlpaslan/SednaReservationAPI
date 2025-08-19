using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Reservation.GetHotelByIdReservation
{

    // Hotel Rezervasyonları görüntüleme

    public class GetHotelByIdReservationQueryHandler : IRequestHandler<GetHotelByIdReservationQueryRequest, List<GetHotelByIdReservationQueryResponse>>
    {
        readonly IReservationReadRepository _reservationReadRepository;

        public GetHotelByIdReservationQueryHandler(IReservationReadRepository reservationReadRepository)
        {
            _reservationReadRepository = reservationReadRepository;
        }

        public async Task<List<GetHotelByIdReservationQueryResponse>> Handle(GetHotelByIdReservationQueryRequest request, CancellationToken cancellationToken)
        {
            var rezervation = _reservationReadRepository.GetWhere(r => r.HotelId == request.hotelId).Select(rezer => new GetHotelByIdReservationQueryResponse
            {
                Id = rezer.Id.ToString(),
                UserId = rezer.UserId,
                HotelId = rezer.HotelId,
                RoomId = rezer.RoomId,
                CheckIn = rezer.CheckIn,
                CheckOut = rezer.CheckOut,
                TotalPrice = rezer.TotalPrice,
                Status = rezer.Status,
                Deleted = rezer.Deleted
            }).ToList();

            return await Task.FromResult(rezervation);


        }
    }
}
