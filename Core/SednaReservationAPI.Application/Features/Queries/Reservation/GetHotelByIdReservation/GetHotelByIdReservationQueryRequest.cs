﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Reservation.GetHotelByIdReservation
{
    public class GetHotelByIdReservationQueryRequest : IRequest<List<GetHotelByIdReservationQueryResponse>>
    {
        public string hotelId { get; set; }
    }
}
