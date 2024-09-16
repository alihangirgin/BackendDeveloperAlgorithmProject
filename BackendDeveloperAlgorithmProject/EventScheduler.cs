using BackendDeveloperAlgorithmProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendDeveloperAlgorithmProject
{
    public class EventScheduler
    {
        private List<Event>? GetEventsFromFile()
        {
            string eventsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inputs/events.json");
            var eventsBytes = File.ReadAllText(eventsFilePath);
            var events = JsonSerializer.Deserialize<List<Event>>(eventsBytes);
            return events;
        }

        private List<DurationBetweenLocation>? GetDurationsFromFile()
        {
            string durationBetweenLocationsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inputs/durationBetweenLocations.json");
            var durationBytes = File.ReadAllText(durationBetweenLocationsFilePath);
            var durations = JsonSerializer.Deserialize<List<DurationBetweenLocation>>(durationBytes);
            return durations;
        }


        public void Schedule()
        {
            var events = GetEventsFromFile();
            var durations = GetDurationsFromFile();

            if (events == null || durations == null) return;

            List<Event> orderedEvents = events.OrderBy(x => x.EndTime).ToList();

            List<int> attendedEventIdList = new();
            int attendedTotalPriority = 0;

            var lastItem = orderedEvents.FirstOrDefault();
            if (lastItem == null) return;

            attendedEventIdList.Add(lastItem.Id);
            attendedTotalPriority = lastItem.Priority;

            foreach (var newItem in orderedEvents.Skip(1))
            {
                var travelDuration = durations.FirstOrDefault(x => (x.From == lastItem.Location && x.To == newItem.Location)
                    || (x.From == newItem.Location && x.To == lastItem.Location))?.DurationMinutes ?? 0; // because B to A defined as A to B in json

                if (newItem.StartTime > lastItem.EndTime.Add(TimeSpan.FromMinutes(travelDuration)))  // new event is after the old event is over.
                {
                    attendedEventIdList.Add(newItem.Id);
                    attendedTotalPriority += newItem.Priority;
                    lastItem = newItem;
                }
                else  // If the new event is before the old event ends, the new event can be preferred insted of old by priority
                {
                    if (newItem.Priority > lastItem.Priority)
                    {
                        attendedEventIdList.Remove(lastItem.Id);
                        attendedEventIdList.Add(newItem.Id);
                        attendedTotalPriority -= lastItem.Priority;
                        attendedTotalPriority += newItem.Priority;
                        lastItem = newItem;
                    }
                }
            }

            var resultString = $"Katılınabilecek Maksimum Etkinlik Sayısı: {attendedEventIdList.Count}\n" +
                $"Katılınabilecek Etkinliklerin ID'leri: {string.Join(",", attendedEventIdList)}\n" +
                $"Toplam Değer: {attendedTotalPriority}";

            Console.WriteLine(resultString);

        }
    }
}
