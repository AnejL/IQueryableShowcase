using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQueryableShowcase.Contracts;
using IQueryableShowcase.Model;

namespace IQueryableShowcase.DTO
{
    public class LocationDto : IDto
    {
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Location ToModel()
        {
            return new Location()
            {
                Name = this.Name,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
            };
        }

        object IDto.ToModel()
        {
            return this.ToModel();
        }
    }
}
