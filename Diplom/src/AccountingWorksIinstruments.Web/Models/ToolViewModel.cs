﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.Web.Models
{
    public class ToolViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int StatusId { get; set; }
        public string PosterImageUrl { get; set; }
        public string AspNetUsersId { get; set; }
        public bool MarkWriteOffTools { get; set; }
        public bool MarkForShipment { get; set; }
        public string UserName { get; set; }
        public IFormFile PosterImage { get; set; }
        public string NameOfLocation { get; set; }
        public string StatusDiscription { get; set; }
    }
}
