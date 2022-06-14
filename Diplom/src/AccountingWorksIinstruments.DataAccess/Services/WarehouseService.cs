using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IEfGenRepository<Warehouse> _warehouseRepository;

        public WarehouseService(IEfGenRepository<Warehouse> warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public int Add(Warehouse warehouse)
        {
            var idNewWarehouse = _warehouseRepository.AddAsync(warehouse).Result;
            return idNewWarehouse;
        }

        public IEnumerable<Warehouse> ReadAll()
        {
            var warehouse = _warehouseRepository.ReadAllAsync().Result;
            return warehouse;
        }

        public Warehouse Update(Warehouse warehouse)
        {
            var updateWarehouse = _warehouseRepository.UpdateAsync(warehouse).Result;

            return updateWarehouse;
        }

        public IQueryable<Warehouse> DeleteAll(Warehouse warehouse)
        {
            _warehouseRepository.DeleteAsync(warehouse).Wait();
            var deleteWarehouse = _warehouseRepository.ReadAllAsync().Result;
            return deleteWarehouse;
        }
        public IEnumerable<Warehouse> GetById(int id)
        {
            var warehouse = _warehouseRepository.GetByIdAsync(id).Result;
            return warehouse;
        }
    }
}
