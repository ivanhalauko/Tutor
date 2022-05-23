using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Services
{
    public class LocationService : ILocationServices
    {
        private readonly IEfGenRepository<Location> _locationRepository;

        public LocationService(IEfGenRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public int Add(Location location)
        {
            var idNewLocation = _locationRepository.AddAsync(location).Result;
            return idNewLocation;
        }

        public IEnumerable<Location> ReadAll()
        {
            var locations = _locationRepository.ReadAllAsync().Result;
            return locations;
        }

        public Location Update(Location location)
        {
            var updateLocation = _locationRepository.UpdateAsync(location).Result;

            return updateLocation;
        }

        public IQueryable<Location> DeleteAll(Location location)
        {
            _locationRepository.DeleteAsync(location).Wait();
            var deletePosition = _locationRepository.ReadAllAsync().Result;
            return deletePosition;
        }
        public IEnumerable<Location> GetById(int id)
        {
            var locations = _locationRepository.GetByIdAsync(id).Result;
            return locations;
        }
    }
}
