using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Models;
using AccountingWorksIinstruments.Web.Interfaces;
using AccountingWorksIinstruments.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapperConfig _mapperConfig;
        private readonly IPositionService _positionService;
        private readonly ILocationServices _locationServices;
        private readonly IToolService _toolService;

        public HomeController(ILogger<HomeController> logger, IMapperConfig mapConfig, IPositionService positionService,ILocationServices locationServices, IToolService toolService)
        {
            _mapperConfig = mapConfig;
            _logger = logger;
            _positionService = positionService;
            _locationServices = locationServices;
            _toolService = toolService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Positions()
        {
            var entities = _positionService.ReadAll();
            var positions = _mapperConfig.Mapper.Map<IEnumerable<Position>, IEnumerable<PositionViewModel>>(entities);
            return View(positions);
        }

        public IActionResult GetByIdPosition(int Id)
        {
            var entities = _positionService.GetById(Id);
            var position = _mapperConfig.Mapper.Map<IEnumerable<Position>, IEnumerable<PositionViewModel>>(entities);
            return View(position);
        }

        public IActionResult UpdatePosition(int id)
        {
            
            var entities = _positionService.GetById(id);
            var positions = _mapperConfig.Mapper.Map<IEnumerable<Position>, IEnumerable<PositionViewModel>>(entities).FirstOrDefault();
            return View(positions);
        }

        //public IActionResult AddPosition(Position position)
        //{
        //    var entities = _positionService.Add(position);
        //    var position = _mapperConfig.Mapper.Map<IEnumerable<<Position, IEnumerable<PositionViewModel>>(entities);
        //    return;
        //}

        [HttpPost]
        public IActionResult UpdatePosition( IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string position = Convert.ToString(collection["Name"]);
                Position positionEntity = new Position(id, position);
                _positionService.Update(positionEntity);
                return RedirectToAction("Positions");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public IActionResult DeletePosition(int id)
        {
            var entities = _positionService.GetById(id);
            var positions = _mapperConfig.Mapper.Map<IEnumerable<Position>, IEnumerable<PositionViewModel>>(entities).FirstOrDefault();
            return View(positions);
        }

        [HttpPost]
        public IActionResult DeletePosition(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string position = Convert.ToString(collection["Name"]);
                Position positionEntity = new Position(id, position);
                _positionService.DeleteAll(positionEntity);
                return RedirectToAction("Positions");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public IActionResult CreatePosition()
        {
            var entities = new Position(0,null);
            var positions = _mapperConfig.Mapper.Map<Position, PositionViewModel>(entities);
            return View(positions);
        }

        [HttpPost]
        public IActionResult CreatePosition(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string position = Convert.ToString(collection["Name"]);
                Position positionEntity = new Position(id, position);
                _positionService.Add(positionEntity);
                return RedirectToAction("Positions");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
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
                string NameOfTheOrganization = Convert.ToString(collection["TheNameOfTheOrganization"]);
                string warehouse = Convert.ToString(collection["Warehouse"]);
                Location locationEntity = new Location(id,NameOfTheOrganization, warehouse);
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
                string NameOfTheOrganization = Convert.ToString(collection["NameOfTheOrganization"]);
                string warehouse = Convert.ToString(collection["Warehouse"]);
                Location locationEntity = new Location(id,NameOfTheOrganization, warehouse);
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
            var entities = new Location(0, null,null);
            var locations = _mapperConfig.Mapper.Map<Location, LocationViewModel>(entities);
            return View(locations);
        }

        [HttpPost]
        public IActionResult CreateLocation(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string NameOfTheOrganization = Convert.ToString(collection["NameOfOrganization"]);
                string warehouse = Convert.ToString(collection["Warehouse"]);
                Location locationEntity = new Location(id,NameOfTheOrganization, warehouse);
                _locationServices.Add(locationEntity);
                return RedirectToAction("Locations");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IActionResult Tool()
        {
            var tools = _toolService.ReadAll();
            var locations = _locationServices.ReadAll().ToList();
            var viewTools = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(tools);
            foreach (ToolViewModel item in viewTools)
            {
                int locationId=item.LocationId;
                Location location =locations.Find(p => p.Id == locationId);
                item.NameOfTheOrganization = location.NameOfTheOrganization;
            }
            return View(viewTools);
        }
        public IActionResult GetByIdTool(int Id)
        {
            var entities = _toolService.GetById(Id);
            var tool = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(entities);
            return View(tool);
        }
        public IActionResult UpdateTool(int id)
        {

            var entities = _toolService.GetById(id);
            var tool = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(entities).FirstOrDefault();
            return View(tool);
        }
        [HttpPost]
        public IActionResult UpdateTool(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string Name = Convert.ToString(collection["Name"]);
                string Description = Convert.ToString(collection["Description"]);
                int LocationId = Convert.ToInt32(collection["LocationId"]);
                Tool toolEntity = new Tool(id, Name, Description, LocationId);
                _toolService.Update(toolEntity);
                return RedirectToAction("Tool");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IActionResult DeleteTool(int id)
        {
            var tool = _toolService.GetById(id);
            var locations = _locationServices.GetById(id).ToList();
            var viewTool = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(tool).FirstOrDefault();
            int locationId= tool.FirstOrDefault().LocationId;
            viewTool.NameOfTheOrganization = locations.FirstOrDefault().NameOfTheOrganization;
            return View(viewTool);
        }

        [HttpPost]
        public IActionResult DeleteTool(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string name = Convert.ToString(collection["Name"]);
                string description = Convert.ToString(collection["Description"]);
                int locationId = Convert.ToInt32(collection["LocationId"]);
                Tool toolEntity = new Tool(id, name, description, locationId);
                _toolService.DeleteAll(toolEntity);
                return RedirectToAction("Tool");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ActionResult GetItemsPartial(int id)
        {
            return PartialView(_locationServices.ReadAll().Where(x => x.Id == id).ToList());
        }
        public IActionResult CreateTool()
        {
            var locations = _mapperConfig.Mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(_locationServices.ReadAll());
            var entities = new Tool(0, null, null,0);
            var tools = _mapperConfig.Mapper.Map<Tool, ToolViewModel>(entities);
            ViewBag.Locations = new SelectList(locations, "Id", "NameOfTheOrganization", 1);
            return View(tools);
        }

        [HttpPost]
        public IActionResult CreateTool(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string Name = Convert.ToString(collection["Name"]);
                string Description = Convert.ToString(collection["Description"]);
                int LocationId = Convert.ToInt32(collection["LocationId"]);
                Tool toolEntity = new Tool(id, Name, Description, LocationId);
                _toolService.Update(toolEntity);
                return RedirectToAction("Tool");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
