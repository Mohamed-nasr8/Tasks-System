using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks_System.BL.Helper;
using Tasks_System.BL.Interface;

namespace Tasks_System.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserTaskController : ControllerBase
    {
        private readonly IAdminUserTaskRepository _adminUserTaskRepository;

        public AdminUserTaskController(IAdminUserTaskRepository adminUserTaskRepository)
        {
            _adminUserTaskRepository = adminUserTaskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _adminUserTaskRepository.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var result = await _adminUserTaskRepository.DeleteTaskAsync(taskId);
            if (result)
            {
                return Ok(new ApiResponse<string>
                {
                    Code = "200",
                    Status = "OK",
                    Message = "Task deleted successfully."
                });
            }
            return NotFound(new ApiResponse<string>
            {
                Code = "404",
                Status = "Not Found",
                Message = "Task not found."
            });
        }

        [HttpPatch("{taskId}")]
        public async Task<IActionResult> ChangeTaskStatus(int taskId, [FromBody] bool isFinished)
        {
            var result = await _adminUserTaskRepository.ChangeTaskStatusAsync(taskId, isFinished);
            if (result)
            {
                return Ok(new ApiResponse<string>
                {
                    Code = "200",
                    Status = "OK",
                    Message = "Task status changed successfully."
                });
            }
            return NotFound(new ApiResponse<string>
            {
                Code = "404",
                Status = "Not Found",
                Message = "Task not found."
            });
        }
    }
}