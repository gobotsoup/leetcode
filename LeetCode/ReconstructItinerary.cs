using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ReconstructItinerary
    {
        private Dictionary<string, List<string>> _arrivalDestinations = new Dictionary<string, List<string>>();

        //TODO pretty sure this is not working 
        public IList<string> FindItinerary(string[,] tickets)
        {
            var itinerary = new List<string>();
            //Console.WriteLine($"tickets len={tickets.Length}");
            for (int i = 0; i < tickets.Length / 2; i++)
            {
                string dest = tickets[i, 1];
                string arrv = tickets[i, 0];
                //Console.WriteLine($"dest: {dest} arrv: {arrv}");
                if (_arrivalDestinations.ContainsKey(arrv))
                {
                    _arrivalDestinations[arrv].Add(dest);
                }
                else
                {
                    var destList = new List<string>();
                    destList.Add(dest);
                    _arrivalDestinations.Add(arrv, destList);
                }
            }

            string currAirport = "JFK";
            var departures = _arrivalDestinations[currAirport].ToArray();
            Array.Sort(departures, StringComparer.InvariantCulture);
            itinerary.Add(currAirport);
            int tixLeft = (tickets.Length / 2);
            var usedTix = new List<string>();

            while (tixLeft > 0)
            {
                int i = GetNextDeparture(departures, usedTix, currAirport);

                if (i >= 0)
                {
                    itinerary.Add(departures[i]);
                    tixLeft--;
                    usedTix.Add($"{currAirport}{departures[i]}");
                    currAirport = departures[i];
                    departures = _arrivalDestinations[currAirport].ToArray();
                    Array.Sort(departures, StringComparer.InvariantCulture);
                }
                else if (tixLeft == 1)
                {
                    Console.WriteLine($"CurrAirport:{currAirport}");
                    //itinerary.Add(_arrivalDestinations[currAirport][0]);
                    int lastDeparture = GetNextDeparture(_arrivalDestinations[currAirport].ToArray(), usedTix, currAirport, true);
                    itinerary.Add(_arrivalDestinations[currAirport][lastDeparture]);
                    tixLeft--;
                }
            }
            return itinerary;
        }

        private int GetNextDeparture(string[] departures, List<string>usedTix, string currAirport, bool lastTicket = false)
        {
            for (int i = 0; i < departures.Length; i++)
            {
                var d = departures[i];
                if ((_arrivalDestinations.ContainsKey(d) || lastTicket) && usedTix.Contains($"{currAirport}{d}") == false)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
