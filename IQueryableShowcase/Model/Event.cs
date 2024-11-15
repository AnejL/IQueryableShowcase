using IQueryableShowcase.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQueryableShowcase.DTO;
using IQueryableShowcase.Extensions;

namespace IQueryableShowcase.Model
{
    public class Event : IModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }

        public Location Location { get; set; }

        public EventDto ToDto()
        {
            return new EventDto()
            {
                Name = this.Name,
                Description = this.Description,
                Start = this.Start.ToUnixTime(),
                End = this.End.ToUnixTime(),
                Location = this.Location.ToDto(),
            };
        }

        object IModel.ToDto()
        {
            return this.ToDto();
        }
    }
}
