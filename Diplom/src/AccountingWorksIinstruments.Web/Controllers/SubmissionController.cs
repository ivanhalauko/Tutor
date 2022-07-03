using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorksIinstruments.Web.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly IMapperConfig _mapperConfig;
        private readonly ISubmissionForToolsService _submissionForToolsService;
        private readonly ISubmissionForToolToolService _submissionForToolToolService;
        private readonly IToolService _toolService;
        private readonly ILocationServices _locationServices;
        private readonly UserManager<IdentityUser> _userManager;

        public SubmissionController(IMapperConfig mapperConfig, ISubmissionForToolsService submissionForToolsService, ISubmissionForToolToolService submissionForToolToolService,
            IToolService toolService,  ILocationServices locationServices, UserManager<IdentityUser> userManager)
        {
            _mapperConfig = mapperConfig;
            _submissionForToolsService = submissionForToolsService;
            _submissionForToolToolService = submissionForToolToolService;
            _toolService = toolService;
            _locationServices = locationServices;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateSubmission()
        {
            var userName = User.Identity.Name;
            var user = _userManager.FindByNameAsync(userName).Result;
            var userId = user.Id;

            return View();
        }
    }
}
