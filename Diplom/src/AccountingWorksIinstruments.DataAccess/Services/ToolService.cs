using AccountingWorkInstruments.DataAccess.IntefacesServices;
using AccountingWorkInstruments.DataAccess.Interfaces;
using AccountingWorkInstruments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountingWorkInstruments.DataAccess.Services
{
    public class ToolService : IToolService
    {
        private readonly IEfGenRepository<Tool> _toolRepository;

        public ToolService(IEfGenRepository<Tool> toolRepository)
        {
            _toolRepository = toolRepository;
        }

        public int Add(Tool tool)
        {
            var idNewTool = _toolRepository.AddAsync(tool).Result;
            return idNewTool;
        }

        public IEnumerable<Tool> ReadAll()
        {
            var tool = _toolRepository.ReadAllAsync().Result;
            return tool;
        }

        public Tool Update(Tool tool)
        {
            var updateTool = _toolRepository.UpdateAsync(tool).Result;

            return updateTool;
        }

        public IQueryable<Tool> DeleteAll(Tool tool)
        {
            _toolRepository.DeleteAsync(tool).Wait();
            var deleteTool = _toolRepository.ReadAllAsync().Result;
            return deleteTool;
        }
        public IEnumerable<Tool> GetById(int id)
        {
            var tool = _toolRepository.GetByIdAsync(id).Result;
            return tool;
        }
    }
}
