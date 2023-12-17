using Microsoft.EntityFrameworkCore;
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
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly ApplicationDbContext _context;

        public UserTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserTaskAssignment> AssignUserToTaskAsync(UserTaskAssignment assignment)
        {
            _context.UserTaskAssignments.Add(assignment);
            await _context.SaveChangesAsync();

          

            return assignment;

        }

        public async Task<UserTask> CreateAsync(UserTask task)
        {
            _context.UserTasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task UpdateTaskAsync(UserTask task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<UserTask> GetByIdAsync(int taskId)
        {
            return await _context.UserTasks.FindAsync(taskId);
        }

        public async Task DeleteTaskAsync(UserTask task)
        {
            _context.UserTasks.Remove(task);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<UserTask>> GetTasksForUserOrderedByDueDateAsync(string userId)
        {
            return await _context.UserTasks
                .Where(task =>
                    task.CreatorId == userId ||
                    _context.UserTaskAssignments.Any(a => a.UserId == userId && a.TaskId == task.Id))
                .OrderBy(task => task.DueDate)
                .ToListAsync();
        }
        public async Task<IEnumerable<UserTask>> SearchTasksForUserByDueDateAsync(string userId, DateTime dueDate)
        {
            return await _context.UserTasks
                .Where(task =>
                    (task.CreatorId == userId || _context.UserTaskAssignments.Any(a => a.UserId == userId && a.TaskId == task.Id)) &&
                    task.DueDate.Date == dueDate.Date) 
                .OrderBy(task => task.DueDate)
                .ToListAsync();
        }


    }
}