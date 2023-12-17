using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_System.BL.Interface;
using Tasks_System.DAL.DbContext;
using Tasks_System.DAL.Entity;

namespace Tasks_System.BL.Repository
{
    public class AdminUserTaskRepository : IAdminUserTaskRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminUserTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserTask>> GetAllTasksAsync()
        {
            return  _context.UserTasks.ToList();
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            var taskToDelete = await _context.UserTasks.FindAsync(taskId);
            if (taskToDelete != null)
            {
                _context.UserTasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ChangeTaskStatusAsync(int taskId, bool isFinished)
        {
            var taskToUpdate = await _context.UserTasks.FindAsync(taskId);
            if (taskToUpdate != null)
            {
                taskToUpdate.IsFinished = isFinished;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }

}
