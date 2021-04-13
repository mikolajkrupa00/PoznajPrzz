﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajPrz.Application.Commands.Places.CreatePlace
{
    public class CreatePlaceCommand : IRequest<PlaceDto>
    {
        public decimal Latitude { get; set; }
        public decimal Attitude { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Guid CategoryId { get; set; }
    }
}
