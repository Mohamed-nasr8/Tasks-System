using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_System.BL.Models;

namespace Tasks_System.BL.Interface
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);


    }
}
