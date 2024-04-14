using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VTZ.Domain.Abstract;
using VTZ.Domain.Entities;
using VTZ.WebUI.Models;

namespace VTZ.WebUI.Controllers
{
    public class TaskController : Controller
    {
        private ITaskRepository repository;
        public int pageSize = 4;

        public TaskController(ITaskRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string docNo, int page = 1)
        {
            TasksListViewModel model = new TasksListViewModel
            {
                Tasks = repository.Tasks
                    .Where(p => docNo == null || p.DocNo == docNo)
                    .OrderBy(task => task.DocumentId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = docNo == null ?
                repository.Tasks.Count() :
                repository.Tasks.Where(task => task.DocNo == docNo).Count()
                },
                CurrentDocNo = docNo
            };
            return View(model);
        }


    }
}   