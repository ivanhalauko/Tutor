using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Models
{
    public class SubmissionFromWorkersDetailsViewModel
    {
        public int Id { get; set; }
        public string Purpose { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public int ToolId { get; set; }
        public int SubmissionId { get; set; }
        public string ToolName { get; set; }
        public string PosterImage { get; set; }
        public string NameOfLocation { get; set; }
        public string UserName { get; set; }
    }
}
