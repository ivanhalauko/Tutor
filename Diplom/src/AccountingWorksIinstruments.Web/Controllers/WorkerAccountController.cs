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
    public class WorkerAccountController : Controller
    {
        private readonly IMapperConfig _mapperConfig;
        private readonly IToolService _toolService;
        private readonly IWorkerServices _workerService;
        private readonly ILocationServices _locationServices;
        private readonly ISubmissionForToolsService _submissionForToolsService;
        private readonly ISubmissionForToolToolService _submissionForToolToolService;
        public WorkerAccountController(IMapperConfig mapConfig, ILocationServices locationServices, ISubmissionForToolToolService submissionForToolToolService,
            IToolService toolService, IWorkerServices workerService, ISubmissionForToolsService submissionForToolsService)
        {
            _mapperConfig = mapConfig;
            _locationServices = locationServices;
            _toolService = toolService;
            _workerService = workerService;
            _submissionForToolsService = submissionForToolsService;
            _submissionForToolToolService = submissionForToolToolService;

        }
        // GET: WorkerAccountController
        public ActionResult PersonalAccount()
        {
            return View();
        }
        

        public ActionResult ShowMyTools(int workerId)
        {
            var tools = _toolService.ReadAll();
            var locations = _locationServices.ReadAll().ToList();
            var toolsByWorkerId = tools.Where(x => x.WorkerId == workerId);
            var viewTools = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(toolsByWorkerId);
            foreach (ToolViewModel item in viewTools)
            {
                int locationId = item.LocationId;
                Location location = locations.Find(p => p.Id == locationId);
                item.NameOfTheOrganization = location.NameOfTheOrganization;
            }
            return View(viewTools);
        }
        ///WorkerAccount/ShowMySubmission?workerId=1
        public ActionResult ShowMySubmission(int workerId)
        {
            var tools = _toolService.ReadAll();
            var submissionForTools = _submissionForToolsService.ReadAll();
            var submissionForToolTools = _submissionForToolToolService.ReadAll();
            var toolsByWorkerId = tools.Where(x => x.WorkerId == workerId);
            List<SubmissionForToolTool> submissionForToolByWorkerId = new List<SubmissionForToolTool>(); 

            foreach (var toolId in toolsByWorkerId)
            {
                foreach (var item in submissionForToolTools)
                {
                    if (item.ToolId == toolId.Id)
                    {
                        submissionForToolByWorkerId.Add(item);
                    }
                }
            }
            List<SubmissionForToolsViewModel> submissionForToolsById = new List<SubmissionForToolsViewModel>();
            foreach (var submission in submissionForToolByWorkerId)
            {
                foreach (var item in submissionForTools)
                {
                    if (item.Id == submission.SubmissionId)
                    {
                        SubmissionForToolsViewModel model = new SubmissionForToolsViewModel();
                        model.Purpose = item.Purpose;
                        model.DateOfDelivery = item.DateOfDelivery;
                        model.Name = toolsByWorkerId.Select(x => x.Name).FirstOrDefault();
                        submissionForToolsById.Add(model);
                    }
                }
            }

            //var submissionForToolToolById = submissionForToolTools.GroupBy(p => p.ToolId)
            //var submissionForToolById = submissionForTools.Where(x => x.)
            return View(submissionForToolsById);
        }
        // GET: WorkerAccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkerAccountController/Create
        public ActionResult CreateSubmission()
        {
            return RedirectToAction("CreateSubmission", "SubmissionController");
        }

        // GET: WorkerAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkerAccountController/Edit/5
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

        // GET: WorkerAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkerAccountController/Delete/5
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
