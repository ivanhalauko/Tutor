using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Services
{
    public class PositionSevice : IPositionService
    {
        private readonly IEfGenRepository<Position> _positionRepository;

        public PositionSevice(IEfGenRepository<Position> positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public int Add(Position position)
        {
            var idNewPosition = _positionRepository.AddAsync(position).Result;
            return idNewPosition;
        }

        public IEnumerable<Position> ReadAll()
        {
            var positions = _positionRepository.ReadAllAsync().Result;
            return positions;
        }

        public Position Update(Position position)
        {
            var updatePosition = _positionRepository.UpdateAsync(position).Result;

            return updatePosition;
        }

        public IQueryable<Position> DeleteAll(Position position)
        {
            _positionRepository.DeleteAsync(position).Wait();
            var deletePosition = _positionRepository.ReadAllAsync().Result;
            return deletePosition;
        }
        public IEnumerable<Position> GetById(int id)
        {
            var positions = _positionRepository.GetByIdAsync(id).Result;
            return positions;
        }
    }
}
