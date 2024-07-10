﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Room.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommandRequest, DeleteRoomCommandResponse>
    {
        public Task<DeleteRoomCommandResponse> Handle(DeleteRoomCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}