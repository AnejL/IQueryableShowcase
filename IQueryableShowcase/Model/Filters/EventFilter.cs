using IQueryableShowcase.Contracts;
using IQueryableShowcase.DTO;
using IQueryableShowcase.DTO.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IQueryableShowcase.Extensions;

namespace IQueryableShowcase.Model.Filters
{
    public class EventFilter : IModel, IFilter<Event>
    {
        public string EventName { get; set; }

        public string LocationName { get; set; }


        public DateTime? StartFrom { get; set; }

        public DateTime? EndTo { get; set; }


        public List<Expression<Func<Event, bool>>> GetFilterExpressionList() => [
            e =>            
                // kateri eventi imajo vrednost EventName v imenu?
                (!string.IsNullOrEmpty(EventName) && e.Name.ToLowerInvariant().Contains(this.EventName.ToLowerInvariant())) 
                ||
                // kateri eventi imajo lokacijo z imenom LocationName?
                (!string.IsNullOrEmpty(this.LocationName) && e.Location.Name.ToLowerInvariant().Contains(this.LocationName.ToLowerInvariant()))
                ||
                // datum zacetka eventa >= StartFrom
                (this.StartFrom != null && e.Start >= this.StartFrom)
                ||            
                // datum konca eventa <= EndTo
                (this.EndTo != null && e.End <= this.EndTo)
        ];

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(this.EventName)
                   && string.IsNullOrEmpty(this.LocationName)
                   && this.StartFrom == null
                   && this.EndTo == null;
        }

        public EventFilterDto ToDto()
        {
            return new EventFilterDto()
            {
                EventName = this.EventName,
                LocationName = this.LocationName,
                StartFrom = this.StartFrom == null ? null : this.StartFrom.Value.ToUnixTime(),
                EndTo = this.EndTo == null ? null : this.EndTo.Value.ToUnixTime(),
            };
        }

        object IModel.ToDto()
        {
            return this.ToDto();
        }
    }
}
