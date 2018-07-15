using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleMapsDataAccess
{
    public class LocationRepository
    {
        public List<Location> ListOfLocations { get; private set; }

        public LocationRepository(List<Location> listOfLocations)
        {
            ListOfLocations = listOfLocations;
        }

        public Location GetLocation(string placeName, string country)
        {
            return ListOfLocations.
                FirstOrDefault(l => l.PlaceName == placeName 
                                        && 
                                    l.Country == country);
        }

        public bool SaveLocation(Location location)
        {
            return true;
        }
    }
}