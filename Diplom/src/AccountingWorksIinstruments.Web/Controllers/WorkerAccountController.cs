using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Models;
using AccountingWorksIinstruments.Web.Interfaces;
using AccountingWorksIinstruments.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Controllers
{
    [Authorize(Roles = "Worker, Admin")]
    public class WorkerAccountController : Controller
    {
        private readonly IMapperConfig _mapperConfig;
        private readonly IToolService _toolService;
        private readonly ILocationServices _locationServices;
        private readonly ISubmissionForToolsService _submissionForToolsService;
        private readonly ISubmissionForToolToolService _submissionForToolToolService;
        private readonly IStatusService _statusService;
        private readonly UserManager<ApplicationUser> _identityUserManager;
        public WorkerAccountController(IMapperConfig mapConfig, 
            ILocationServices locationServices, 
            ISubmissionForToolToolService submissionForToolToolService,
            IToolService toolService, 
            ISubmissionForToolsService submissionForToolsService,
            IStatusService statusService,
            UserManager<ApplicationUser> identityUserManager)
        {
            _mapperConfig = mapConfig;
            _locationServices = locationServices;
            _toolService = toolService;
            _submissionForToolsService = submissionForToolsService;
            _submissionForToolToolService = submissionForToolToolService;
            _statusService = statusService;
            _identityUserManager = identityUserManager;
        }
        // GET: WorkerAccountController
        public ActionResult PersonalAccount()
        {
            return View();
        }


        public ActionResult ShowMyTools()
        {
            var tools = _toolService.ReadAll();
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
        ///WorkerAccount/ShowMySubmission?workerId=1
        public ActionResult ShowMySubmission(int workerId)
        {
            
            var submissionForToolTools = _submissionForToolToolService.ReadAll();
            var viewSubmissions = _mapperConfig.Mapper.Map<IEnumerable<SubmissionForToolTool>, IEnumerable<SubmissionForToolsViewModel>>(submissionForToolTools);
            //var toolsByWorkerId = tools.Where(x => x.WorkerId == workerId);
            //List<SubmissionForToolTool> submissionForToolByWorkerId = new List<SubmissionForToolTool>();

            //foreach (var toolId in toolsByWorkerId)
            //{
            //    foreach (var item in submissionForToolTools)
            //    {
            //        if (item.ToolId == toolId.Id)
            //        {
            //            submissionForToolByWorkerId.Add(item);
            //        }
            //    }
            //}
            //List<SubmissionForToolsViewModel> submissionForToolsById = new List<SubmissionForToolsViewModel>();
            //foreach (var submission in submissionForToolByWorkerId)
            //{
            //    foreach (var item in submissionForTools)
            //    {
            //        if (item.Id == submission.SubmissionId)
            //        {
            //            SubmissionForToolsViewModel model = new SubmissionForToolsViewModel();
            //            model.Purpose = item.Purpose;
            //            model.DateOfDelivery = item.DateOfDelivery;
            //            model.Name = toolsByWorkerId.Select(x => x.Name).FirstOrDefault();
            //            submissionForToolsById.Add(model);
            //        }
            //    }
            //}

            //var submissionForToolToolById = submissionForToolTools.GroupBy(p => p.ToolId)
            //var submissionForToolById = submissionForTools.Where(x => x.)
            return View(viewSubmissions);
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
        public ActionResult CreateWorkerSubmission(DateTime dateOfDelivery, string purpose= null)
        {
            var availableTools = _toolService.ReadAll();
            var availableToolsView = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(availableTools);

            var toolForWorkerView = new ToolViewModel();
            toolForWorkerView.AvailableTools = availableToolsView;
            var toolsWithMarkTrue = _toolService.ReadAll().Where(x => x.MarkFromWorker == true);
            toolForWorkerView.ToolForShipment = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(toolsWithMarkTrue);
            toolForWorkerView.Purpose = purpose;
            toolForWorkerView.DateOfDelivery = dateOfDelivery;
            return View(toolForWorkerView);
        }
        public ActionResult AddToSubmissionList(int toolId)
        {
            var tool = _toolService.GetById(toolId).FirstOrDefault();
            tool.MarkFromWorker = true;
            _toolService.Update(tool);
            return RedirectToAction(nameof(CreateWorkerSubmission));
        }
        public ActionResult RemoveFromSubmissionList(int toolId)
        {
            var tool = _toolService.GetById(toolId).FirstOrDefault();
            tool.MarkFromWorker = false;
            _toolService.Update(tool);
            return RedirectToAction("CreateWorkerSubmission");
        }

        [HttpPost]
        public ActionResult CreateWorkerSubmission([FromForm] ToolViewModel model)
        {
            var submission = new SubmissionForTools
            {
                Purpose = model.Purpose,
                DateOfDelivery = model.DateOfDelivery,
            };
            var idToolSubmissionForWorker = _submissionForToolsService.Add(submission);
            var toolsForNote = _toolService.ReadAll().Where(x => x.MarkFromWorker == true);
            foreach (var item in toolsForNote)
            {
                var submissionForToolTool = new SubmissionForToolTool
                {
                    ToolId = item.Id,
                    SubmissionId = idToolSubmissionForWorker
                };
                _submissionForToolToolService.Add(submissionForToolTool);
            }

            return RedirectToAction(nameof(ShowMySubmission));
        }
        public ActionResult ShipmentFromBaseStock()
        {
            var transferTools = _toolService.ReadAll();
            var currentUserName = User.Identity.Name;
            var currentUser = _identityUserManager.FindByNameAsync(currentUserName).Result;
            var currentUserId = currentUser.Id;
            var usersTransferTools = transferTools.Where(x => x.MarkDestinationUser == currentUserId);
            var DestinationUsersToolsView = _mapperConfig.Mapper.Map<IEnumerable<Tool>, IEnumerable<ToolViewModel>>(transferTools);
            return View(DestinationUsersToolsView);
        }
        
        public ActionResult AcceptTool (int toolId)
        {
            var updatedTool = _toolService.GetById(toolId).FirstOrDefault();
            var currentUserName = User.Identity.Name;
            var currentUser = _identityUserManager.FindByNameAsync(currentUserName).Result;
            var currentUserId = currentUser.Id;
            updatedTool.AspNetUsersId = currentUserId;
            _toolService.Update(updatedTool);
            return RedirectToAction(nameof(ShipmentFromBaseStock));
        }
        [HttpPost]
        public ActionResult ShipmentFromBaseStock([FromForm] DeliveryNoteViewModel model)
        {

            return RedirectToAction();
        }
    }
}
