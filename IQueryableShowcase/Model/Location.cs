using IQueryableShowcase.Contracts;
using IQueryableShowcase.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQueryableShowcase.Model
{
    public class Location : IModel
    {
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public LocationDto ToDto()
        {
            return new LocationDto 
            { 
                Name = this.Name, 
                Latitude = this.Latitude, 
                Longitude = this.Longitude
            };
        }

        object IModel.ToDto()
        { 
            return this.ToDto();
        }
    }
}
