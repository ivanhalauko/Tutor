using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Models;
using AccountingWorksIinstruments.Web.Interfaces;
using AccountingWorksIinstruments.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Controllers
{
    public class StockAccountController : Controller
    {
        private readonly IMapperConfig _mapperConfig;
        private readonly IToolService _toolService;
        private readonly ILocationServices _locationServices;
        private readonly IStatusService _statusService;
        private readonly IWorkerServices _workerService;
        private readonly ISubmissionForToolsService _submissionForToolsService;
        private readonly ISubmissionForToolToolService _submissionForToolToolService;
        private readonly INoteDeliveryService _noteDeliveryService;

        public StockAccountController(IMapperConfig mapperConfig, IToolService toolService, ILocationServices locationServices, 
            IStatusService statusService, IWorkerServices workerService, ISubmissionForToolsService submissionForToolsService,
            ISubmissionForToolToolService submissionForToolToolService, INoteDeliveryService noteDeliveryService)
        {
            _mapperConfig = mapperConfig;
            _toolService = toolService;
            _locationServices = locationServices;
            _statusService = statusService;
            _workerService = workerService;
            _submissionForToolsService = submissionForToolsService;
            _submissionForToolToolService = submissionForToolToolService;
            _noteDeliveryService = noteDeliveryService;
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
        public ActionResult CreateTool(int workerId)
        {
            var tools = _toolService.ReadAll();
            var locations = _locationServices.ReadAll().ToList();
            var toolsByWorkerId = tools.Where(x => x.WorkerId == workerId);
            var viewCreateTools = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(toolsByWorkerId);
            foreach (ToolViewModel item in viewCreateTools)
            {
                int locationId = item.LocationId;
                Location location = locations.Find(p => p.Id == locationId);
                item.NameOfLocation = location.NameOfLocation;
            }
            return View(viewCreateTools);
        }

        // POST: StockAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
