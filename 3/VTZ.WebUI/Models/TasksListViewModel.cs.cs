using System.Collections.Generic;
using VTZ.WebUI.Models;
using VTZ.Domain.Entities;

namespace VTZ.WebUI.Models
{
    public class TasksListViewModel
    {
        public IEnumerable<Task> Tasks { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentDocNo { get; set; }
    }
}

