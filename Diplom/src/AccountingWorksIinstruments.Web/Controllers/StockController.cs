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

        public StockController(IMapperConfig mapperConfig, IToolService toolService, ILocationServices locationServices, 
            IStatusService statusService, ISubmissionForToolsService submissionForToolsService,
            ISubmissionForToolToolService submissionForToolToolService, INoteDeliveryService noteDeliveryService,
            INotesDeliveryToolService notesDeliveryToolService, ISubmissionWriteOffService submissionWriteOffService,
            ISubmissionWriteToolService submissionWriteToolService)
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
        // GET: StockAccountController/Create
        //public ActionResult CreateTool(int workerId)
        //{
        //    var tools = _toolService.ReadAll();
        //    var locations = _locationServices.ReadAll().ToList();
        //    var toolsByWorkerId = tools.Where(x => x.WorkerId == workerId);
        //    var viewCreateTools = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(toolsByWorkerId);
        //    foreach (ToolViewModel item in viewCreateTools)
        //    {
        //        int locationId = item.LocationId;
        //        Location location = locations.Find(p => p.Id == locationId);
        //        item.NameOfLocation = location.NameOfLocation;
        //    }
        //    return View(viewCreateTools);
        //}

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
            var newSubmissionId = _submissionWriteOffService.Add(new SubmissionWriteOff ( date : DateTime.Now));
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
            var notesDeliverys = _noteDeliveryService.ReadAll();
            var notesDeliveryTools = _notesDeliveryToolService.ReadAll();
            var tools = _toolService.ReadAll();
            var locations = _locationServices.ReadAll();
            var statuses = _statusService.ReadAll();
            ViewBag.Locations = new SelectList(locations, "Id", "NameOfLocation", 1);
            ViewBag.Status = new SelectList(statuses, "Id", "StatusDiscription", 1);
            return View(tools);
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
    }
}
