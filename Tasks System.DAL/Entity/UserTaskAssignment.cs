using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_System.DAL.Extend;

namespace Tasks_System.DAL.Entity
{
    public class UserTaskAssignment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int TaskId { get; set; }
        public UserTask Task { get; set; }
    }
}
