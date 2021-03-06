using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajPrz.Application.Queries.Places.GetPlaces
{
    public class PlaceDto
    {
        public PlaceDto(Guid placeId, decimal latitude, decimal attitude, string name, string description, string address,
            string categoryName, bool haveVisited, int zoom)
        {
            PlaceId = placeId;
            Latitude = latitude;
            Attitude = attitude;
            Name = name;
            Description = description;
            Address = address;
            CategoryName = categoryName;
            HaveVisited = haveVisited;
            Zoom = zoom;
        }

        public Guid PlaceId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Attitude { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string CategoryName { get; set; }
        public bool HaveVisited { get; set; }
        public int Zoom { get; set; }
    }
}
