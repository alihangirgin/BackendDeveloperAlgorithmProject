
using BackendDeveloperAlgorithmProject.Models;
using System.Text.Json;

string eventsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inputs/events.json");
string durationBetweenLocationsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inputs/durationBetweenLocations.json");


var eventsBytes = File.ReadAllText(eventsFilePath);
var events = JsonSerializer.Deserialize<List<Event>>(eventsBytes);

var durationBytes = File.ReadAllText(durationBetweenLocationsFilePath);
var durations = JsonSerializer.Deserialize<List<DurationBetweenLocation>>(durationBytes);
