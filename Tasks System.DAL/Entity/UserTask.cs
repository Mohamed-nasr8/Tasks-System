using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_System.DAL.Extend;

namespace Tasks_System.DAL.Entity
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsFinished { get; set; } = false;   
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

    }
}
