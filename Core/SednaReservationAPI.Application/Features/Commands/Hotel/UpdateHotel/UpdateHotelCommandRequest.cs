﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Hotel.UpdateHotel
{
    public class UpdateHotelCommandRequest : IRequest<UpdateHotelCommandResponse>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public float StarRating { get; set; }
        public int Star {  get; set; }
        public string? ImageUrl { get; set; }
    }
}
