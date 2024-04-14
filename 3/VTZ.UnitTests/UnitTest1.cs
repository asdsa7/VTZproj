using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VTZ.Domain.Abstract;
using VTZ.Domain.Entities;
using VTZ.WebUI.Controllers;

namespace VTZ.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Организация (arrange)
            Mock<ITaskRepository> mock = new Mock<ITaskRepository>();
            mock.Setup(m => m.Tasks).Returns(new List<Task>
            {
                new Task { DocumentId = 1, DocumentName = "Task1"},
                new Task { DocumentId = 2, DocumentName = "Task2"},
                new Task { DocumentId = 3, DocumentName = "Task3"},
                new Task { DocumentId = 4, DocumentName = "Task4"},
                new Task { DocumentId = 5, DocumentName = "Task5"}
            });
            TaskController controller = new TaskController(mock.Object);
            controller.pageSize = 3;

            // Действие (act)
            IEnumerable<Task> result = (IEnumerable<Task>)controller.List(2).Model;

            // Утверждение (assert)
            List<Task> tasks = result.ToList();
            Assert.IsTrue(tasks.Count == 2);
            Assert.AreEqual(tasks[0].DocumentName, "Task6");
            Assert.AreEqual(tasks[1].DocumentName, "Task7");
        }
    }
}
