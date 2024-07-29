
using MediatR;

namespace SednaReservationAPI.Application.Features.Queries.Payment.GetPaymentByUserId
{
    public class GetPaymentByUserIdRequest: IRequest<List<GetPaymentByUserIdResponse>>
    {
        public string userId { get; set; }
    }
}
