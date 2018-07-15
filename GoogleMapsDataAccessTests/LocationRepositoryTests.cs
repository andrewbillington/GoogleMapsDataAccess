using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using Moq;
using NUnit.Framework;
using GoogleMapsDataAccess;

namespace GoogleMapsDataAccessTests
{
    public class LocationRepositoryTests
    {
        [Test]
        public void GivenRepositoryContainsOneLocationWithPlaceNameOfLeedsAndCountryOfUKAndLatitudeOf30AndLongitudeOf50_WhenListOfLocationsAccessed_OneLocationWithPlaceNameOfLeedsAndCountryOfUKAndLatitudeOf30AndLongitudeOf50IsReturned()
        {
            // Arrange
            var location = new Location()
            {
                PlaceName = "Leeds",
                Country = "UK",
                Latitude = 30,
                Longitude = 50
            };

            var listOfLocations = new List<Location>() { location };

            var locationRepository =
                            new LocationRepository(listOfLocations);


            List<Location> actualLocations;

            // Act
            actualLocations = locationRepository.ListOfLocations;

            // Assert
            Assert.AreEqual(listOfLocations, actualLocations);
        }

        [Test]
        public void GivenLocationWithPlaceNameOfLeedsAndCountryOfUkIsInRepository_WhenGetLocationCalledWithPlaceNameOfLeedsAndCountryOfUk_LocationIsReturned()
        {
            // Arrange
            var placeName = "Leeds";
            var country = "UK";
            var latitude = 30.0f;
            var longitude = 50.0f;
            var location = new Location()
            {
                PlaceName = placeName,
                Country = country,
                Latitude = latitude,
                Longitude = longitude
            };

            var listOfLocations = new List<Location>() { location };

            var locationRepository =
                            new LocationRepository(listOfLocations);

            Location actualLocation;

            // Act
            actualLocation = locationRepository.GetLocation("Leeds", "UK");

            // Assert
            Assert.AreEqual(location, actualLocation);
        }

        [Test]
        public void GivenLocationWithPlaceNameOfLeedsAndCountryOfUKIsNotInRepositoryAlongWithOtherLocations_WhenGetLocationCalledWithPlaceNameOfLeedsAndCountryOfUk_NullLocationIsReturned()
        {
            // Arrange

            var placeNameOfLocationOnDatabase = "Chicago";
            var countryOfLocationOnDatabase = "US";
            var latitude = 30.0f;
            var longitude = 50.0f;
            var location = new Location()
            {
                PlaceName = placeNameOfLocationOnDatabase,
                Country = countryOfLocationOnDatabase,
                Latitude = latitude,
                Longitude = longitude
            };

            var anotherLocation = new Location();

            var listOfLocations = new List<Location>() { anotherLocation, location };

            var locationRepository =
                            new LocationRepository(listOfLocations);

            var placeNameOfLocationForGetLocation = "Leeds";
            var countryOfLocationForGetLocation = "UK";

            Location actualLocation;

            // Act
            actualLocation = locationRepository.GetLocation
                (placeNameOfLocationForGetLocation, countryOfLocationForGetLocation);

            // Assert
            Assert.IsNull(actualLocation);
        }

        [Test]
        public void GivenLocationWithPlaceNameOfParisAndCountryOfUSButNotFranceIsInRepositoryAlongWithOtherLocations_WhenGetLocationCalledWithPlaceNameOfParissAndCountryOfFrance_NullLocationIsReturned()
        {
            // Arrange

            var placeNameOfLocationOnDatabase = "Paris";
            var countryOfLocationOnDatabase = "US";
            var latitude = 30.0f;
            var longitude = 50.0f;
            var location = new Location()
            {
                PlaceName = placeNameOfLocationOnDatabase,
                Country = countryOfLocationOnDatabase,
                Latitude = latitude,
                Longitude = longitude
            };

            var anotherLocation = new Location();

            var listOfLocations = new List<Location>() { anotherLocation, location };

            var locationRepository =
                            new LocationRepository(listOfLocations);

            var placeNameOfLocationForGetLocation = "Paris";
            var countryOfLocationForGetLocation = "France";

            Location actualLocation;

            // Act
            actualLocation = locationRepository.GetLocation
                (placeNameOfLocationForGetLocation, countryOfLocationForGetLocation);

            // Assert
            Assert.IsNull(actualLocation);
        }


        [Test]
        public void GivenLocationRepositoryDoesNotContainLocationWithPlaceNameOfDublineAndCountryOfIreland_WhenSaveLocationCalledWithPlaceNameOfDublinAndCountryOfIrelandAndLatitudeOfThirtyAndLongitudeOfFifty_StatusOfTrueIsReturned()
        {
            // Arrange

            var placeNameOfLocationOnDatabase = "Dublin";
            var countryOfLocationOnDatabase = "Ireland";
            var latitude = 30.0f;
            var longitude = 50.0f;
            var location = new Location()
            {
                PlaceName = placeNameOfLocationOnDatabase,
                Country = countryOfLocationOnDatabase,
                Latitude = latitude,
                Longitude = longitude
            };

            var locationRepository = new LocationRepository(new List<Location>());

            bool returnedStatus;

            // Act
            returnedStatus = locationRepository.SaveLocation(location);

            // Assert
            Assert.AreEqual(true, returnedStatus);
        }
    }
}