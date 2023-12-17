using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_System.DAL.Entity;

namespace Tasks_System.BL.Interface
{
    public interface IUserTaskRepository
    {
        Task<UserTask> CreateAsync(UserTask task);
        Task<UserTaskAssignment> AssignUserToTaskAsync(UserTaskAssignment assignment);
        Task UpdateTaskAsync(UserTask task);
        Task<UserTask> GetByIdAsync(int taskId);
        Task DeleteTaskAsync(UserTask task);
        Task<IEnumerable<UserTask>> GetTasksForUserOrderedByDueDateAsync(string userId);
        Task<IEnumerable<UserTask>> SearchTasksForUserByDueDateAsync(string userId, DateTime dueDate);









    }
}
