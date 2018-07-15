using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleMapsDataAccess
{
    public class LocationRepository
    {
        private List<Location> listOfLocations;

        public LocationRepository(List<Location> listOfLocations)
        {
            this.listOfLocations = listOfLocations;
        }

        public List<Location> GetAllLocations()
        {
            return listOfLocations;
        }

        public Location GetLocation(string placeName, string country)
        {
            return listOfLocations.
                FirstOrDefault(l => l.PlaceName == placeName 
                                        && 
                                    l.Country == country);
        }
    }
}