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
    public class PositionController : Controller
    {
        private readonly IMapperConfig _mapperConfig;
        private readonly IPositionService _positionService;

        public PositionController(IMapperConfig mapConfig, IPositionService positionService)
        {
            _mapperConfig = mapConfig;
            _positionService = positionService;
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

        [HttpPost]
        public IActionResult UpdatePosition(IFormCollection collection)
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
            var entities = new Position(0, null);
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
