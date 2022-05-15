using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Models;
using AccountingWorksIinstruments.Web.Interfaces;
using AccountingWorksIinstruments.Web.Models;
using Microsoft.AspNetCore.Mvc;
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

        public HomeController(ILogger<HomeController> logger, IMapperConfig mapConfig, IPositionService positionService)
        {
            _mapperConfig = mapConfig;
            _logger = logger;
            _positionService = positionService;
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
