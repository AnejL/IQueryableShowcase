using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQueryableShowcase.Model;

namespace IQueryableShowcase
{
    public class EventService
    {
        public List<Event> GetEvents()
        {
            var ljubljana = new Location
            {
                Name = "Ljubljana",
                Latitude = 46.0569,
                Longitude = 14.5058
            };

            var maribor = new Location
            {
                Name = "Maribor",
                Latitude = 46.5547,
                Longitude = 15.6459
            };

            var horjul = new Location
            {
                Name = "Horjul",
                Latitude = 46.0167,
                Longitude = 14.2833
            };

            var events = new List<Event>()
            {
                new Event
                {
                    Name = "Ljubljana Festival",
                    Description = "A celebration of local music, arts, and food in the heart of Ljubljana.",
                    Start = new DateTime(2024, 6, 1, 18, 0, 0),
                    End = new DateTime(2024, 6, 1, 23, 0, 0),
                    Location = ljubljana
                },
                new Event
                {
                    Name = "Agropop Concert",
                    Description = "Music",
                    Start = new DateTime(2024, 11, 20, 9, 0, 0),
                    End = new DateTime(2024, 11, 20, 14, 0, 0),
                    Location = horjul,
                },
                new Event
                {
                    Name = "Horjul Market Day",
                    Description = "A lively market day featuring local crafts, food, and community events.",
                    Start = new DateTime(2024, 4, 20, 9, 0, 0),
                    End = new DateTime(2024, 4, 20, 14, 0, 0),
                    Location = horjul
                },
                new Event
                {
                    Name = "Maribor Wine Festival",
                    Description = "An annual festival showcasing the finest wines of the region with tastings and live music.",
                    Start = new DateTime(2024, 9, 15, 12, 0, 0),
                    End = new DateTime(2024, 9, 15, 20, 0, 0),
                    Location = maribor
                },
                new Event
                {
                    Name = "Martinovo",
                    Description = "Wine and music.",
                    Start = new DateTime(2024, 11, 11, 12, 0, 0),
                    End = new DateTime(2024, 11, 11, 22, 0, 0),
                    Location = maribor
                }
            };

            return events;
        }
    }
}
