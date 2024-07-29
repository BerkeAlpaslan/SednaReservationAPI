using MediatR;
using SednaReservationAPI.Application.Repositories;
using SednaReservationAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Payment.GetPaymentByUserId
{
    public class GetPaymentByUserIdHandler : IRequestHandler<GetPaymentByUserIdRequest, List<GetPaymentByUserIdResponse>>
    {
        IPaymentReadRepository _paymentReadRepository;

        public GetPaymentByUserIdHandler(IPaymentReadRepository paymentReadRepository)
        {
            _paymentReadRepository = paymentReadRepository;
        }

        public async Task<List<GetPaymentByUserIdResponse>> Handle(GetPaymentByUserIdRequest request, CancellationToken cancellationToken)
        {
            var payments = _paymentReadRepository.GetWhere(r => r.UserId == request.userId).Select(payments => new GetPaymentByUserIdResponse
            {
                Id = payments.Id.ToString(),
                userId= payments.UserId,
                ReservationId = payments.ReservationId,
                hotelId = payments.HotelId,
                Amount = payments.Amount,
                Status = payments.Status,
                PaymentMethod = payments.PaymentMethod,
                Date = payments.Date,
            }).ToList();

            return await Task.FromResult(payments);
        }
    }
}
