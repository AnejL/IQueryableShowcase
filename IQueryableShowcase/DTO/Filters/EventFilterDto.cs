using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQueryableShowcase.Contracts;
using IQueryableShowcase.Extensions;
using IQueryableShowcase.Model;
using IQueryableShowcase.Model.Filters;

namespace IQueryableShowcase.DTO.Filters
{
    public class EventFilterDto : IDto
    {
        public string EventName { get; set; }

        public string LocationName { get; set; }
        
        public long? StartFrom { get; set; }
        
        public long? EndTo { get; set; }
        
        public EventFilter ToModel()
        {
            return new EventFilter()
            {
                EventName = this.EventName,
                LocationName = this.LocationName,
                StartFrom = this.StartFrom == null ? null : this.StartFrom.Value.FromUnixTime(),
                EndTo = this.EndTo == null ? null : this.EndTo.Value.FromUnixTime(),
            };
        }

        object IDto.ToModel()
        {
            return this.ToModel();
        }
    }
}
