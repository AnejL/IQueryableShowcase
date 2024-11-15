using IQueryableShowcase.Contracts;
using IQueryableShowcase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQueryableShowcase.Extensions;

namespace IQueryableShowcase.DTO
{
    public class EventDto : IDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public long Start { get; set; }

        public long End { get; set; }

        public LocationDto Location { get; set; }

        public Event ToModel()
        {
            return new Event()
            {
                Name = this.Name,
                Description = this.Description,
                Start = this.Start.FromUnixTime(),
                End = this.End.FromUnixTime(),
                Location = this.Location.ToModel(),
            };
        }

        object IDto.ToModel()
        {
            return this.ToModel();
        }
    }
}
