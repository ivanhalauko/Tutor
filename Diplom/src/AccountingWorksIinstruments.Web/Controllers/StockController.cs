using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Models;
using AccountingWorksIinstruments.Web.Interfaces;
using AccountingWorksIinstruments.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Controllers
{
    public class StockController : Controller
    {
        private readonly IMapperConfig _mapperConfig;
        private readonly IToolService _toolService;
        private readonly ILocationServices _locationServices;
        private readonly IStatusService _statusService;
        private readonly ISubmissionForToolsService _submissionForToolsService;
        private readonly ISubmissionForToolToolService _submissionForToolToolService;
        private readonly INoteDeliveryService _noteDeliveryService;
        private readonly INotesDeliveryToolService _notesDeliveryToolService;
        private readonly ISubmissionWriteToolService _submissionWriteToolService;
        private readonly ISubmissionWriteOffService _submissionWriteOffService;
        private readonly UserManager<ApplicationUser> _identityUserManager;

        public StockController(IMapperConfig mapperConfig, 
            IToolService toolService, 
            ILocationServices locationServices, 
            IStatusService statusService,
            ISubmissionForToolsService submissionForToolsService,
            ISubmissionForToolToolService submissionForToolToolService,
            INoteDeliveryService noteDeliveryService,
            INotesDeliveryToolService notesDeliveryToolService, 
            ISubmissionWriteOffService submissionWriteOffService,
            ISubmissionWriteToolService submissionWriteToolService,
            UserManager<ApplicationUser> identityUserManager)
        {
            _mapperConfig = mapperConfig;
            _toolService = toolService;
            _locationServices = locationServices;
            _statusService = statusService;
            _submissionForToolsService = submissionForToolsService;
            _submissionForToolToolService = submissionForToolToolService;
            _noteDeliveryService = noteDeliveryService;
            _notesDeliveryToolService = notesDeliveryToolService;
            _submissionWriteOffService = submissionWriteOffService;
            _submissionWriteToolService = submissionWriteToolService;
            _identityUserManager = identityUserManager;
        }


        // GET: StockAccountController
        public ActionResult StockAccount()
        {
            return View();
        }

        // GET: StockAccountController/Details/5
        public ActionResult SubmissionsFromWorkers()
        {
            var submissionForToolTools = _submissionForToolToolService.ReadAll();
            var submissionForTools = _submissionForToolsService.ReadAll();
            var viewsubmissionForToolTools = _mapperConfig.Mapper.Map<IEnumerable<SubmissionForToolTool>, IEnumerable<SubmissionFromWorkersViewModel>>(submissionForToolTools);
            return View(viewsubmissionForToolTools);
        }
        public ActionResult HistoryOfADeliveryNotes()
        {
            var notesOfDelivery = _noteDeliveryService.ReadAll();
            var viewNotesOfDelivery = _mapperConfig.Mapper.Map<IEnumerable<NoteDelivery>, IEnumerable<HistoryOfADelivaryNotesViewModel>>(notesOfDelivery);
            return View(viewNotesOfDelivery);
        }

        // POST: StockAccountController/Create
        public ActionResult CreateWriteOffTool()
        {
            var tools = _toolService.ReadAll();
            var statuses = _statusService.ReadAll().ToList();
            var toolsView = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(tools);
            foreach (var item in toolsView)
            {
                int statusId = item.StatusId;
                Status status = statuses.Find(p => p.Id == statusId);
                item.StatusDiscription = status.StatusDiscription;
            }
            return View(toolsView);
        }
        public ActionResult AddToWriteOffList(int toolId)
        {
            var tool = _toolService.GetById(toolId).FirstOrDefault();
            tool.MarkWriteOffTools = true;
            _toolService.Update(tool);
            return RedirectToAction("CreateWriteOffTool");
        }

        public ActionResult RemoveFromWriteOffSubmission(int toolId)
        {
            var tool = _toolService.GetById(toolId).FirstOrDefault();
            tool.MarkWriteOffTools = false;
            _toolService.Update(tool);
            return RedirectToAction("CreateWriteOffTool");
        }
        
        public ActionResult CreateSubmissionWriteOffTools()
        {
            var toolList = _toolService.ReadAll().Where(x => x.MarkWriteOffTools == true).ToList();
            var newSubmissionId = _submissionWriteOffService.Add(new SubmissionWriteOff(date: DateTime.Now));
            foreach (var item in toolList)
            {
                var modelSubWriteTool = new SubmissionWriteTool { ToolId = item.Id, SubmissionWriteID = newSubmissionId };
                var submissionWriteOff = _submissionWriteToolService.Add(modelSubWriteTool);
            }
            return RedirectToAction("StockAccount");
        }

        public ActionResult WriteOffToolsSubmissions()
        {
            var submissions = _submissionWriteToolService.ReadAll();
            return View(submissions);
        }

        public ActionResult CreateDeliveryNote()
        {
            var availableTools = _toolService.ReadAll();
            var availableToolsView = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(availableTools);
            var workers = _identityUserManager.Users.ToList();
            var destinations = _locationServices.ReadAll();

            var deliveryNotesView = new DeliveryNoteViewModel();
            deliveryNotesView.AvailableTools = availableToolsView;
            var toolsWithMarkTrue=_toolService.ReadAll().Where(x => x.MarkForShipment == true);
            deliveryNotesView.ToolForShipment = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(toolsWithMarkTrue);
            ViewBag.Locations = new SelectList(destinations, "Id", "NameOfLocation", 1);
            ViewBag.Workers = new SelectList(workers, "Id", "UserName", 1);
            return View(deliveryNotesView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDeliveryNote([FromForm] DeliveryNoteViewModel model)
        {
            var newNoteDelivery = new NoteDelivery
            {
                NumberOfDeliveryNote = model.NumberOfDeliveryNote,
                CarsNumber = model.CarsNumber,
                DeliveryDate = model.DeliveryDate,
            };
            var toolsInNoteDeliveryTools = _notesDeliveryToolService.ReadAll().ToList();
            var toolsWithMarkForShipment = _toolService.ReadAll().Where(x => x.MarkForShipment == true).ToList();

            var noteDeliveryId = _noteDeliveryService.Add(newNoteDelivery);
            newNoteDelivery.Id = noteDeliveryId;
            var mark = 1;
            foreach (var tool in toolsWithMarkForShipment)
            {
                var newDeliveryNote = new NotesDeliveryTool
                {
                    ToolId = tool.Id,
                    NoteDeliveryId = noteDeliveryId,
                };
                if (!toolsInNoteDeliveryTools.Exists(x => x.ToolId == tool.Id))
                {
                    _notesDeliveryToolService.Add(newDeliveryNote);
                    mark++;
                }
            }
            if (mark == 1)
            {
                _noteDeliveryService.DeleteAll(newNoteDelivery);
            }
            return RedirectToAction(nameof(StockAccount));
        }
        public ActionResult AddToToolForShipmentList(int toolId)
        {
            var tool = _toolService.GetById(toolId).FirstOrDefault();
            tool.MarkForShipment = true;
            _toolService.Update(tool);
            return RedirectToAction(nameof(CreateDeliveryNote));
        }
        public ActionResult RemoveFromToolForShipmentList(int toolId)
        {
            var tool = _toolService.GetById(toolId).FirstOrDefault();
            tool.MarkForShipment = false;
            _toolService.Update(tool);
            return RedirectToAction(nameof(CreateDeliveryNote));
        }


        public ActionResult TransferTool(int id)
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
        public IActionResult TransferTool(IFormCollection collection)
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
                return RedirectToAction("StockAccount");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateDelivaryNote(IFormCollection collection)
        // GET: StockAccountController/Edit/5


        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StockAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StockAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StockAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult GetItemsPartials(int id)
        {
            return PartialView(_locationServices.ReadAll().Where(x => x.Id == id).ToList());

        }
    }
}
