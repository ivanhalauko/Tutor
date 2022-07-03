using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Models;
using AccountingWorksIinstruments.Web.Interfaces;
using AccountingWorksIinstruments.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Controllers
{
    public class LocationController : Controller
    {
        private readonly IMapperConfig _mapperConfig;
        private readonly ILocationServices _locationServices;
        
        public LocationController(IMapperConfig mapConfig, ILocationServices locationServices)
        {
            _mapperConfig = mapConfig;
            _locationServices = locationServices;
        }

        public IActionResult Locations()
        {
            var entities = _locationServices.ReadAll();
            var locations = _mapperConfig.Mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(entities);
            return View(locations);
        }
        public IActionResult GetByIdLocation(int Id)
        {
            var entities = _locationServices.GetById(Id);
            var locations = _mapperConfig.Mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(entities);
            return View(locations);
        }
        public IActionResult UpdateLocation(int id)
        {

            var entities = _locationServices.GetById(id);
            var locations = _mapperConfig.Mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(entities).FirstOrDefault();
            return View(locations);
        }
        [HttpPost]
        public IActionResult UpdateLocation(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string NameOfLocation = Convert.ToString(collection["NameOfLocation"]);
                int warehouse = Convert.ToInt32(collection["Warehouse"]);
                Location locationEntity = new Location(id, NameOfLocation, warehouse);
                _locationServices.Update(locationEntity);
                return RedirectToAction("Locations");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IActionResult DeleteLocation(int id)
        {
            var entities = _locationServices.GetById(id);
            var locations = _mapperConfig.Mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(entities).FirstOrDefault();
            return View(locations);
        }

        [HttpPost]
        public IActionResult DeleteLocation(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string NameOfLocation = Convert.ToString(collection["NameOfTLocation"]);
                int warehouse = Convert.ToInt32(collection["Warehouse"]);
                Location locationEntity = new Location(id, NameOfLocation, warehouse);
                _locationServices.DeleteAll(locationEntity);
                return RedirectToAction("Locations");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public IActionResult CreateLocation()
        {
            var entities = new Location(0, null, 0);
            var locations = _mapperConfig.Mapper.Map<Location, LocationViewModel>(entities);
            return View(locations);
        }

        [HttpPost]
        public IActionResult CreateLocation(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string NameOfLocation = Convert.ToString(collection["NameOfLocation"]);
                int warehouse = Convert.ToInt32(collection["Warehouse"]);
                Location locationEntity = new Location(id, NameOfLocation, warehouse);
                _locationServices.Add(locationEntity);
                return RedirectToAction("Locations");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
