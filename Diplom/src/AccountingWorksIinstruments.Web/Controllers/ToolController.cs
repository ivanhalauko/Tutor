using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Models;
using AccountingWorksIinstruments.Web.Interfaces;
using AccountingWorksIinstruments.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Controllers
{
    [Authorize(Roles = "Stock Boy, Admin")]
    public class ToolController : Controller
    {
        private readonly IMapperConfig _mapperConfig;
        private readonly ILocationServices _locationServices;
        private readonly IToolService _toolService;
        private readonly IStatusService _statusService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _identityUserManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ToolController(IMapperConfig mapConfig,
            ILocationServices locationServices,
            IToolService toolService, 
            IStatusService statusService, 
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> identityUserManager,
            IWebHostEnvironment webHostEnvironment,
            RoleManager<IdentityRole> roleManager)
        {
            _mapperConfig = mapConfig;
            _locationServices = locationServices;
            _toolService = toolService;
            _statusService = statusService;
            _signInManager = signInManager;
            _identityUserManager = identityUserManager;
            _webHostEnvironment = webHostEnvironment;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.Name == null)
            {
                return RedirectToAction(nameof(AccountController.Login));
            }
            return View();
        }

        public async Task<IActionResult> Tool()
        {
            var tools = _toolService.ReadAll();
            var locations = _locationServices.ReadAll().ToList();
            var statuses = _statusService.ReadAll().ToList();
            var viewTools = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(tools);
            var users =_identityUserManager.Users.ToList();
            var userName = User.Identity.Name;
            var user = _identityUserManager.FindByNameAsync(userName).Result;
            var userId = user.Id;
            var viewToolByUserId = viewTools.Where(id => id.AspNetUsersId == userId);
            foreach (ToolViewModel item in viewToolByUserId)
            {
                int locationId = item.LocationId;
                Location location = locations.Find(p => p.Id == locationId);
                item.NameOfLocation = location.NameOfLocation;
                int statusId = item.StatusId;
                Status status = statuses.Find(p => p.Id == statusId);
                item.StatusDiscription = status.StatusDiscription;
                //item.UserName = User.Identity.Name;
                var temp = await _identityUserManager.FindByIdAsync(item.AspNetUsersId);
                item.UserName = temp.UserName;
                //var secTemp = temp.UserName.ToString();
                //item.UserName = (await _identityUserManager.FindByIdAsync(item.AspNetUserId)).UserName.ToString();
            }
            return View(viewToolByUserId);
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
            var statuses = _statusService.ReadAll().ToList();
            var tool = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(entities).FirstOrDefault();
            ViewBag.Locations = new SelectList(locations, "Id", "NameOfLocation", 1);
            ViewBag.Status = new SelectList(statuses, "Id", "StatusDiscription", 1);
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
                int status = Convert.ToInt32(collection["StatusDiscription"]);
                Tool toolEntity = new Tool(id, Name, Description, idOfLocation,status);
                _toolService.Update(toolEntity);
                return RedirectToAction("Tool");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IActionResult ChangeOwner(int id)
        {
            var locations = _mapperConfig.Mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(_locationServices.ReadAll());
            var entities = _toolService.GetById(id);
            var statuses = _statusService.ReadAll().ToList();
            var tool = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(entities).FirstOrDefault();
            ViewBag.Locations = new SelectList(locations, "Id", "NameOfLocation", 1);
            ViewBag.Status = new SelectList(statuses, "Id", "StatusDiscription", 1);
            return View(tool);
        }
        [HttpPost]
        public IActionResult ChangeOwner(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string Name = Convert.ToString(collection["Name"]);
                string Description = Convert.ToString(collection["Description"]);
                int idOfLocation = Convert.ToInt32(collection["NameOfLocation"]);
                int toolId = Convert.ToInt32(collection["ToolId"]);
                int status = Convert.ToInt32(collection["StatusDiscription"]);
                Tool toolEntity = new Tool(id, Name, Description, idOfLocation, status);
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
            var statuses = _statusService.ReadAll().ToList();
            var tools = _mapperConfig.Mapper.Map<Tool, ToolViewModel>(entities);
            ViewBag.Locations = new SelectList(locations, "Id", "NameOfLocation", 1);
            ViewBag.Status = new SelectList(statuses, "Id", "StatusDiscription", 1);
            return View(tools);
        }

        [HttpPost]
        public async Task<IActionResult>  CreateTool([FromForm] ToolViewModel toolViewModel)
        {
            try
            {
                ////int id = Convert.ToInt32(collection["Id"]);
                ////string Name = Convert.ToString(collection["Name"]);
                ////string Description = Convert.ToString(collection["Description"]);
                ////int idOfTheOrganization = Convert.ToInt32(collection["NameOfLocation"]);
                ////int status = Convert.ToInt32(collection["StatusDiscription"]);
                ////int toolId = Convert.ToInt32(collection["ToolId"]);
                //string urlImage = Convert.ToString(collection["PosterImageUrl"]);
                ////StringValues value;
                ////IFormFile image = collection.TryGetValue("PosterImage", out value);
                //IFormFile image = collection.Keys;
                //string folder = "poster/image/";
                //folder += Guid.NewGuid().ToString() + "_" + urlImage;
                //string pathToFile = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                //urlImage.CopyTo(new FileStream(pathToFile, FileMode.Create));
                //Tool toolEntity = new Tool(id, Name, Description, idOfTheOrganization, status);
                //_toolService.Add(toolEntity);
                var stockBoyAccount = await _identityUserManager.GetUsersInRoleAsync("Stock Boy");
                var stockBoyId = stockBoyAccount.FirstOrDefault().Id;
                int id = toolViewModel.Id;
                string name = toolViewModel.Name;
                string description = toolViewModel.Description;
                int locationId = toolViewModel.LocationId;
                int status = toolViewModel.StatusId;
                string urlImage = toolViewModel.PosterImage.FileName;
                string folder = "posters/image/";
                folder += Guid.NewGuid().ToString() + "_" + urlImage;
                string pathToFile = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                toolViewModel.PosterImage.CopyTo(new FileStream(pathToFile, FileMode.Create));
                Tool toolEntity = new Tool(id, name, description, locationId, status);
                toolEntity.PosterImageUrl = "/" + folder;
                var userName = User.Identity.Name;
                var user = _identityUserManager.FindByNameAsync(userName).Result;
                toolEntity.AspNetUsersId = stockBoyId;
                toolEntity.MarkForDecline = false;
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
