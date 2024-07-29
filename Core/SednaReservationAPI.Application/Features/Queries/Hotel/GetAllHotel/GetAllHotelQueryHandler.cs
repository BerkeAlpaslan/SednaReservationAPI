using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetAllHotel
{
    public class GetAllHotelQueryHandler : IRequestHandler<GetAllHotelQueryRequest, List<GetAllHotelQueryResponse>>
    {
        readonly IHotelReadRepository _hotelReadRepository;

        public GetAllHotelQueryHandler(IHotelReadRepository hotelReadRepository)
        {
            _hotelReadRepository = hotelReadRepository;
        }

        public Task<List<GetAllHotelQueryResponse>> Handle(GetAllHotelQueryRequest request, CancellationToken cancellationToken)
        {// Nullable boolean olarak tanımlıyoruz
            bool? maxStarFilter = request.MaxStar; // Nullable bool

            if (request.Size != null && request.Page != null && request.MaxStar != null)
            {
                var totalCount = _hotelReadRepository.GetAll(false).Count();
                var hotelsQuery = _hotelReadRepository.GetAll(false);



                if (maxStarFilter == true)
                {
                    // Star değerine göre azalan sıralama
                    hotelsQuery = hotelsQuery.OrderByDescending(h => h.Star);
                }
                else if (maxStarFilter == false)
                {
                    //MaxStar belirtilmemişse küçükten büyüğe sıralama false ilse
                    hotelsQuery = hotelsQuery.OrderBy(h => h.Star);
                }
                var hotels = hotelsQuery.ToList();

                var ahotels = hotels
                    .Skip(request.Page * request.Size)
                    .Take(request.Size)
                    .Select(hotel => new GetAllHotelQueryResponse
                    {
                        Id = hotel.Id.ToString(),
                        Name = hotel.Name,
                        Address = hotel.Address,
                        Phone = hotel.Phone,
                        Email = hotel.Email,
                        Description = hotel.Description,
                        StarRating = hotel.StarRating,
                        Star = hotel.Star,
                        ImageUrl = hotel.ImageUrl,
                        TotalCount = totalCount,
                    }).ToList();


                var ashotels = ahotels.ToList();

                return Task.FromResult(ashotels);
            }
            else if (request.Size != null && request.Page != null && request.MaxStar == null)
            {

                var totalCount = _hotelReadRepository.GetAll(false).Count();
                var hotelsQuery = _hotelReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size)
                   .Select(hotel => new GetAllHotelQueryResponse
                   {
                       Id = hotel.Id.ToString(),
                       Name = hotel.Name,
                       Address = hotel.Address,
                       Phone = hotel.Phone,
                       Email = hotel.Email,
                       Description = hotel.Description,
                       StarRating = hotel.StarRating,
                       Star = hotel.Star,
                       ImageUrl = hotel.ImageUrl,
                       TotalCount = totalCount,
                   });

                var hotels = hotelsQuery.ToList();
                return Task.FromResult(hotels);
            }
            else
            {
                return null;
            }


        }
    }
}
