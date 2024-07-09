﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Reservation.GetAllReservation
{
    public class GetAllReservationQueryHandler : IRequestHandler<GetAllReservationQueryRequest, GetAllReservationQueryResponse>
    {
        public Task<GetAllReservationQueryResponse> Handle(GetAllReservationQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
