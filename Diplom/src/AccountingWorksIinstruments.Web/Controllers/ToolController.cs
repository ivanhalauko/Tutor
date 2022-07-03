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
    public class ToolController : Controller
    {
        private readonly IMapperConfig _mapperConfig;
        private readonly ILocationServices _locationServices;
        private readonly IToolService _toolService;
        private readonly IWorkerServices _workerService;

        public ToolController(IMapperConfig mapConfig, ILocationServices locationServices, IToolService toolService, IWorkerServices workerService)
        {
            _mapperConfig = mapConfig;
            _locationServices = locationServices;
            _toolService = toolService;
            _workerService = workerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tool()
        {
            var tools = _toolService.ReadAll();
            var locations = _locationServices.ReadAll().ToList();
            var workers = _workerService.ReadAll().ToList();
            var viewTools = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(tools);
            foreach (ToolViewModel item in viewTools)
            {
                int locationId = item.LocationId;
                Location location = locations.Find(p => p.Id == locationId);
                item.NameOfLocation = location.NameOfLocation;
            }
            return View(viewTools);
        }

        public IActionResult GetByIdTool(int Id)
        {
            var tools = _toolService.GetById(Id);
            var locations = _locationServices.ReadAll().ToList();
            var viewTools = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(tools);
            foreach (ToolViewModel item in viewTools)
            {
                int locationId = item.LocationId;
                Location location = locations.Find(p => p.Id == locationId);
                item.NameOfLocation = location.NameOfLocation;
            }
            return View(viewTools);
        }

        public IActionResult UpdateTool(int id)
        {
            var locations = _mapperConfig.Mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(_locationServices.ReadAll());
            var entities = _toolService.GetById(id);
            var tool = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(entities).FirstOrDefault();
            ViewBag.Locations = new SelectList(locations, "Id", "NameOfLocation", 1);
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
                int idOfLocation = Convert.ToInt32(collection["NameOfLocation"]);
                int toolId = Convert.ToInt32(collection["ToolId"]);
                Tool toolEntity = new Tool(id, Name, Description, idOfLocation, toolId);
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
            var viewTool = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(tool).FirstOrDefault();
            int locationIdFromTool = tool.ToList().FirstOrDefault().LocationId;
            var locations = _locationServices.GetById(locationIdFromTool);
            viewTool.NameOfLocation = locations.ToList().FirstOrDefault().NameOfLocation;
            return View(viewTool);
        }

        //[HttpPost]
        //public IActionResult DeleteTool(IFormCollection collection)
        //{
        //    try
        //    {
        //        int id = Convert.ToInt32(collection["Id"]);
        //        string name = Convert.ToString(collection["Name"]);
        //        string description = Convert.ToString(collection["Description"]);
        //        int locationId = Convert.ToInt32(collection["LocationId"]);
        //        Tool toolEntity = new Tool(id, name, description, locationId);
        //        _toolService.DeleteAll(toolEntity);
        //        return RedirectToAction("Tool");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        
        public IActionResult DeleteToolById(int id)
        {
            try
            {
                //int id = Convert.ToInt32(collection["Id"]);
                //string name = Convert.ToString(collection["Name"]);
                //string description = Convert.ToString(collection["Description"]);
                //int locationId = Convert.ToInt32(collection["LocationId"]);
                Tool toolEntity = new Tool(id,null,null,0,0);
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
            var entities = new Tool(0, null, null, 0,0);
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
                int idOfTheOrganization = Convert.ToInt32(collection["NameOfTheOrganization"]);
                int toolId = Convert.ToInt32(collection["ToolId"]);
                Tool toolEntity = new Tool(id, Name, Description, idOfTheOrganization,toolId);
                _toolService.Add(toolEntity);
                return RedirectToAction("Tool");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
