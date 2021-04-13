using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajPrz.Application.Queries.Places.GetPlace
{
    public class GetPlaceQuery : IRequest<PlaceDto>
    {
        public Guid PlaceId { get; set; }
    }
}
