using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_System.DAL.Entity;

namespace Tasks_System.BL.Interface
{
    public interface IAdminUserTaskRepository
    {
        Task<IEnumerable<UserTask>> GetAllTasksAsync();
        Task<bool> DeleteTaskAsync(int taskId);
        Task<bool> ChangeTaskStatusAsync(int taskId, bool isFinished);
    }
}
