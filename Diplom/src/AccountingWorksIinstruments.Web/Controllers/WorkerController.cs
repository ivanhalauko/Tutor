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
    public class WorkerController : Controller
    {
        private readonly IMapperConfig _mapperConfig;
        private readonly IWorkerServices _workerServices;

        public WorkerController(IMapperConfig mapConfig, IWorkerServices workerServices)
        {
            _mapperConfig = mapConfig;
            _workerServices = workerServices;
        }

        public IActionResult Workers()
        {
            var entities = _workerServices.ReadAll();
            var workers = _mapperConfig.Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerViewModel>>(entities);
            return View(workers);
        }
        public IActionResult GetByIdWorker(int Id)
        {
            var entities = _workerServices.GetById(Id);
            var workers = _mapperConfig.Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerViewModel>>(entities);
            return View(workers);
        }
        public IActionResult UpdateWorker(int id)
        {

            var entities = _workerServices.GetById(id);
            var workers = _mapperConfig.Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerViewModel>>(entities).FirstOrDefault();
            return View(workers);
        }
        [HttpPost]
        public IActionResult UpdateWorker(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string Surname = Convert.ToString(collection["Surname"]);
                string Name = Convert.ToString(collection["Name"]);
                string SecondName = Convert.ToString(collection["SecondName"]);
                int PositionId = Convert.ToInt32(collection["PositionId"]);
                Worker workerEntity = new Worker(id, Surname, Name, SecondName, PositionId);
                _workerServices.Update(workerEntity);
                return RedirectToAction("Workers");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IActionResult DeleteWorker(int id)
        {
            var entities = _workerServices.GetById(id);
            var workers = _mapperConfig.Mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerViewModel>>(entities).FirstOrDefault();
            return View(workers);
        }

        [HttpPost]
        public IActionResult DeleteWorker(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string Surname = Convert.ToString(collection["Surname"]);
                string Name = Convert.ToString(collection["Name"]);
                string SecondName = Convert.ToString(collection["SecondName"]);
                int PositionId = Convert.ToInt32(collection["PositionId"]);
                Worker workerEntity = new Worker(id, Surname, Name, SecondName, PositionId);
                _workerServices.DeleteAll(workerEntity);
                return RedirectToAction("Workers");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public IActionResult CreateWorker()
        {
            var entities = new Worker(0, null, null, null, 0);
            var workers = _mapperConfig.Mapper.Map<Worker, WorkerViewModel>(entities);
            return View(workers);
        }

        [HttpPost]
        public IActionResult CreateWorker(IFormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(collection["Id"]);
                string Surname = Convert.ToString(collection["Surname"]);
                string Name = Convert.ToString(collection["Name"]);
                string SecondName = Convert.ToString(collection["SecondName"]);
                int PositionId = Convert.ToInt32(collection["PositionId"]);
                Worker workerEntity = new Worker(id, Surname, Name, SecondName, PositionId);
                _workerServices.Add(workerEntity);
                return RedirectToAction("Workers");
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
