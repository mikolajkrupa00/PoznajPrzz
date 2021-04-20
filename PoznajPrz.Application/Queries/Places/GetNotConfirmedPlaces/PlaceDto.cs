﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajPrz.Application.Queries.Places.GetNotConfirmedPlaces
{
    public class PlaceDto
    {
        public PlaceDto(Guid placeId, string name, string description, string address,
            string categoryName, int zoom)
        {
            PlaceId = placeId;
            Name = name;
            Description = description;
            Address = address;
            CategoryName = categoryName;
            Zoom = zoom;
        }

        public Guid PlaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string CategoryName { get; set; }
        public int Zoom { get; set; }
    }
}
