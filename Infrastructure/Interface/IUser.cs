using SurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyPortal.Infrastructure.Interface
{
    interface IUser : IRepository<User>
    {
        User Login(string userid, string password);
        bool Register(User objUser);
        bool UpdateProfile(User objUser);
        bool ChangePassword(string UserId, string Password);
    }
}
