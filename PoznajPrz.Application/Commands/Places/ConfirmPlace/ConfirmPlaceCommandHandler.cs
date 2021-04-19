using MediatR;
using PoznajPrz.Domain.Interfaces.Repositories;
using PoznajPrz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajPrz.Application.Commands.Places.ConfirmPlace
{
    public class ConfirmPlaceCommandHandler : IRequestHandler<ConfirmPlaceCommand, Unit>
    {
        private readonly IPlaceRepository _placeRepository;

        public ConfirmPlaceCommandHandler(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<Unit> Handle(ConfirmPlaceCommand request, CancellationToken cancellationToken)
        {
            var place = await _placeRepository.GetAsync(request.PlaceId);
            place.IsConfirmed = true;
            await _placeRepository.UpdateAsync(place);
            return Unit.Value;
        }
    }
}
