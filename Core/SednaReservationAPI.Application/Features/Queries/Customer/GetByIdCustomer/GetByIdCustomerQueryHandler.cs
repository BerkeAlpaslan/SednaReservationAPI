using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Customer.GetByIdCustomer
{
    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQueryRequest, GetByIdCustomerQueryResponse>
    {
        private readonly ICustomerReadRepository _customerReadRepository;

        public GetByIdCustomerQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        async Task<GetByIdCustomerQueryResponse> IRequestHandler<GetByIdCustomerQueryRequest, GetByIdCustomerQueryResponse>.Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            await _customerReadRepository.GetByIdAsync(request.Id, false);
            return new();
        }
    }
}
