using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_System.DAL.Entity;

namespace Tasks_System.DAL.Extend
{
    public class ApplicationUser : IdentityUser
    {
        public string ProfilePicture { get; set; }
        public ICollection<UserTask> CreatedTasks { get; set; }


    }
}
