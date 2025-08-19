using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Review.GetReviewHotelById
{
    public class GetReviewHotelByIdQueryRequest:IRequest<List<GetReviewHotelByIdQueryResponse>>
    {
        public string? HotelId {  get; set; }
    }
}
