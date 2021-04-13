﻿using MediatR;
using PoznajPrz.Domain.Interfaces.Repositories;
using PoznajPrz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajPrz.Application.Commands.Visits.CreateVisit
{
    public class CreateVisitCommandHandler : IRequestHandler<CreateVisitCommand, VisitDto>
    {
        private readonly IVisitRepository _visitRepository;

        public CreateVisitCommandHandler(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public async Task<VisitDto> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
        {
            var visit = Visit.Create(request.VisitDate, request.UserId, request.PlaceId);
            await _visitRepository.CreateAsync(visit);
            return new VisitDto(visit.VisitId);
        }
    }
}
