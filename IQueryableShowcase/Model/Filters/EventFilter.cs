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

        
        public List<Expression<Func<Event, bool>>> GetFilterExpressionList()
        {
            var list = new List<Expression<Func<Event, bool>>>();

            // kateri eventi imajo vrednost EventName v imenu?
            if (!string.IsNullOrEmpty(this.EventName))
            {
                list.Add(e => e.Name.ToLowerInvariant().Contains(this.EventName.ToLowerInvariant()));
            }

            // kateri eventi imajo vrednost LocationName v imenu?
            if (!string.IsNullOrEmpty(this.LocationName))
            {
                list.Add(e => e.Location.Name.ToLowerInvariant().Contains(this.LocationName.ToLowerInvariant()));
            }

            // datum zacetka eventa >= StartFrom
            if (this.StartFrom != null)
                list.Add(e => e.Start >= this.StartFrom);

            // datum konca eventa <= EndTo
            if (this.EndTo != null)
                list.Add(e => e.End <= this.EndTo);

            return list;
        }

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
