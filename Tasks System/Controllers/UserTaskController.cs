using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tasks_System.BL.Helper;
using Tasks_System.BL.Interface;
using Tasks_System.BL.Models;
using Tasks_System.DAL.Entity;

namespace Tasks_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTaskRepository _userTaskRepository;
        private readonly IMapper _mapper;

        public UserTaskController(IUserTaskRepository  userTaskRepository, IMapper mapper)
        {
           _userTaskRepository = userTaskRepository;
           _mapper = mapper;
        }


        [HttpPost("create-task")]
        public async Task<IActionResult> CreateTask(UserTaskVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                   var data = _mapper.Map<UserTask>(model);

                    // Get the current user's ID from the JWT token
                    var userId = User.FindFirst("uid")?.Value;

                    // Set the CreatorId of the task to the current user's ID
                    data.CreatorId = userId;

                    var result = await _userTaskRepository.CreateAsync(data);

                    return Ok(new ApiResponse<UserTask>()
                    {
                        Code = "201",
                        Status = "Created",
                        Message = "Data Saved",
                        Data = result
                    });
                }

                return Ok(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Not Valied",
                    Message = "Data Invalid"
                });

            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Faild",
                    Message = "Not Created",
                    Error = ex.Message
                });
            }
        }
        [HttpPost("assign-users")]
        public async Task<IActionResult> AssignUsersToTask(UserTaskAssignmentVM assignmentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var assignment = _mapper.Map<UserTaskAssignment>(assignmentModel);


                    var result = await _userTaskRepository.AssignUserToTaskAsync(assignment);

                    return Ok(new ApiResponse<UserTaskAssignment>()
                    {
                        Code = "201",
                        Status = "Created",
                        Message = "Users Assigned to Task",
                        Data = result
                    });
                }

                return Ok(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Not Valid",
                    Message = "Data Invalid"
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code = "404",
                    Status = "Failed",
                    Message = "Assignment Failed",
                    Error = ex.Message
                });
            }
        }

        [HttpPut("update-task-status/{taskId}")]
        public async Task<IActionResult> UpdateTaskStatus(int taskId, bool isFinished)
        {
            try
            {
                var task = await _userTaskRepository.GetByIdAsync(taskId);

                if (task == null)
                {
                    return NotFound(new ApiResponse<string>()
                    {
                        Code = "404",
                        Status = "Not Found",
                        Message = "Task not found."
                    });
                }
                task.IsFinished = isFinished;

                await _userTaskRepository.UpdateTaskAsync(task);

                return Ok(new ApiResponse<UserTask>()
                {
                    Code = "200",
                    Status = "OK",
                    Message = "Task status updated successfully.",
                    Data = task
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Bad Request",
                    Message = "Failed to update task status.",
                    Error = ex.Message
                });
            }
        }

        [HttpDelete("delete-task/{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            try
            {
                // Find the task by taskId
                var task = await _userTaskRepository.GetByIdAsync(taskId);

                if (task == null)
                {
                    return NotFound(new ApiResponse<string>()
                    {
                        Code = "404",
                        Status = "Not Found",
                        Message = "Task not found."
                    });
                }

                // Get the current user's ID from the JWT token
                var userId = User.FindFirst("uid")?.Value;

                // Check if the current user is the owner of the task
                if (task.CreatorId != userId)
                {
                    return NotFound(new ApiResponse<string>()
                    {
                        Code = "403",
                        Status = "Forbidden",
                        Message = "You do not have permission to delete this task."
                    });
                }

                await _userTaskRepository.DeleteTaskAsync(task);


                return Ok(new ApiResponse<string>()
                {
                    Code = "200",
                    Status = "OK",
                    Message = "Task deleted successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Bad Request",
                    Message = "Failed to delete task.",
                    Error = ex.Message
                });
            }
        }
        [HttpGet("tasks")]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                // Get the current user's ID from the JWT token
                var userId = User.FindFirst("uid")?.Value;

                // Retrieve tasks where the current user is the creator or assigned user, ordered by due date
                var tasks = await _userTaskRepository.GetTasksForUserOrderedByDueDateAsync(userId);

                return Ok(new ApiResponse<IEnumerable<UserTaskVM>>()
                {
                    Code = "200",
                    Status = "OK",
                    Message = "Tasks retrieved successfully.",
                    Data = _mapper.Map<IEnumerable<UserTaskVM>>(tasks)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Bad Request",
                    Message = "Failed to retrieve tasks.",
                    Error = ex.Message
                });
            }
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchTasksByDueDate([FromQuery] DateTime dueDate)
        {
            try
            {
                var userId = User.FindFirst("uid")?.Value;

                // Retrieve tasks where the current user is the creator or assigned user and due date matches, ordered by due date
                var tasks = await _userTaskRepository.SearchTasksForUserByDueDateAsync(userId, dueDate);

                return Ok(new ApiResponse<IEnumerable<UserTaskVM>>()
                {
                    Code = "200",
                    Status = "OK",
                    Message = "Tasks retrieved successfully.",
                    Data = _mapper.Map<IEnumerable<UserTaskVM>>(tasks)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Bad Request",
                    Message = "Failed to retrieve tasks.",
                    Error = ex.Message
                });
            }
        }









    }
}
