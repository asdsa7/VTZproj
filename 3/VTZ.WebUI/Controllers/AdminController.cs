using System.Web.Mvc;
using VTZ.Domain.Abstract;
using VTZ.Domain.Entities;
using System.Linq;

namespace VTZ.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        ITaskRepository repository;

        public AdminController(ITaskRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Tasks);
        }

        public ViewResult Edit(int taskId)
        {
            Task task = repository.Tasks
                .FirstOrDefault(g => g.DocumentId == taskId);
            return View(task);
        }

        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Task task)
        {
            if (ModelState.IsValid)
            {
                repository.SaveTask(task);
                TempData["message"] = string.Format("Изменения в задаче \"{0}\" были сохранены", task.DocumentName);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(task);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Task());
        }


        [HttpPost]
        public ActionResult Delete(int taskId)
        {
            Task deletedTask = repository.DeleteTask(taskId);
            if (deletedTask != null)
            {
                TempData["message"] = string.Format("Задача \"{0}\" была удалена",
                    deletedTask.DocumentName);
            }
            return RedirectToAction("Index");
        }
    }
}
