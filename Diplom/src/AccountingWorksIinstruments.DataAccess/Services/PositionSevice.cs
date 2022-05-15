using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
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
    }
}
