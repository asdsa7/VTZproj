using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VTZ.Domain.Abstract;

namespace VTZ.WebUI.Controllers
{
    public class NavController : Controller
    {
        private ITaskRepository repository;

        public NavController(ITaskRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Tasks
                .Select(task => task.DocNo)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}