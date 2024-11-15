using System.Runtime.InteropServices.JavaScript;
using IQueryableShowcase;
using IQueryableShowcase.Contracts;
using IQueryableShowcase.Model;
using IQueryableShowcase.Model.Filters;


var eventService = new EventService();
var events = eventService.GetEvents();

var filterService = new FilterService<Event>();

var filterRepoService = new EventFilterRepositoryService();
var eventsInLjubljanaFilter = await filterRepoService.GetEventFilter("inLjubljana.json");
var upcomingFilter = await filterRepoService.GetEventFilter("upcomingFilter.json");
var wineFilter = await filterRepoService.GetEventFilter("wineBasedEvents.json");

var eventsInLjubljana = filterService.Filter(events, eventsInLjubljanaFilter).ToList();

var upcoming = filterService.Filter(events, upcomingFilter).ToList();

var wine  = filterService.Filter(events, wineFilter).ToList();

Console.WriteLine("B");


// /api/events
// /api/events/upcomingEvents
// /api/events/concerts
// /api/events/eventsInLocation/{name}

// /api/events -> kot body zahteve damo filter v JSON obliki



//var eventsInLjubljanaFilter = new EventFilter()
//{
//    LocationName = "Ljubljana"
//};
//var upcomingFilter = new EventFilter()
//{
//    StartFrom = DateTime.Now
//};

Console.WriteLine("B");

