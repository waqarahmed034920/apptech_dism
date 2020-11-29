using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class UserRepository : IUser
    {
        public bool ChangePassword(string UserId, string Password)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(User objT)
        {
            throw new NotImplementedException();
        }

        public User Login(string userid, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(User objUser)
        {
            throw new NotImplementedException();
        }

        public bool Update(User objT)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProfile(User objUser)
        {
            throw new NotImplementedException();
        }
    }
}