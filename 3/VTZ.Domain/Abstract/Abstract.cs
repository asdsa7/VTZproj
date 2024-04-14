using System.Collections.Generic;
using VTZ.Domain.Entities;

namespace VTZ.Domain.Abstract
{
    public interface ITaskRepository
    {
        IEnumerable<Task> Tasks { get; }
        void SaveTask(Task task);
        Task DeleteTask(int taskId);
    }
}