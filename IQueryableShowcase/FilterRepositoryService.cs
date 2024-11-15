using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using IQueryableShowcase.DTO;
using IQueryableShowcase.DTO.Filters;
using IQueryableShowcase.Model.Filters;

namespace IQueryableShowcase
{
    public class EventFilterRepositoryService
    {
        public async Task<EventFilter> GetEventFilter(string name)
        {
            try
            {
                string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\IQueryableShowcase\\{name}";

                using FileStream openStream = File.OpenRead(path);
                EventFilterDto? eventFilterDto =
                    await JsonSerializer.DeserializeAsync<EventFilterDto>(openStream);

                if (eventFilterDto != null)
                    return eventFilterDto.ToModel();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            throw new ArgumentException(nameof(name));
        }

        public async Task SaveEventFilter(string name, EventFilter filter)
        {
            try
            {
                string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\IQueryableShowcase\\{name}";
                using FileStream openStream = File.OpenWrite(path);
                await JsonSerializer.SerializeAsync(openStream, filter.ToDto());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
