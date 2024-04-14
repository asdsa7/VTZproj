using System.Collections.Generic;
using VTZ.Domain.Entities;
using VTZ.Domain.Abstract;

namespace VTZ.Domain.Concrete
{
    public class EFTaskRepository : ITaskRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Task> Tasks
        {
            get { return context.Tasks; }
        }

        public void SaveTask(Task task)
        {
            if (task.DocumentId == 0)
                context.Tasks.Add(task);
            else
            {
                Task dbEntry = context.Tasks.Find(task.DocumentId);
                if (dbEntry != null)
                {
                    dbEntry.DocumentName = task.DocumentName;
                    dbEntry.DocNo = task.DocNo;
                }
            }
            context.SaveChanges();
        }


        public Task DeleteTask(int taskId)
        {
            Task dbEntry = context.Tasks.Find(taskId);
            if (dbEntry != null)
            {
                context.Tasks.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


    }
}