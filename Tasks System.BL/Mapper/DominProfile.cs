using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Tasks_System.BL.Models;
using Tasks_System.DAL.Entity;

namespace Tasks_System.BL.Mapper
{
    public class DominProfile:Profile
    {
        public DominProfile() {

            CreateMap<UserTask, UserTaskVM>();
            CreateMap<UserTaskVM, UserTask>();

            CreateMap<UserTaskAssignment, UserTaskAssignmentVM>();
            CreateMap<UserTaskAssignmentVM, UserTaskAssignment>();
        }
    }
}
