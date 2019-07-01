using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFUserLoginRepository : IUserLoginRepository
    {
        private ApplicationDBContext context;

        public EFUserLoginRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public IQueryable<UserLogin> UserLogins => context.UserLogin;

        public void SaveUserLogin(UserLogin userLogin)
        {
            UserLogin dbEntry = context.UserLogin.FirstOrDefault(u => u.UserName == userLogin.UserName);
            if (dbEntry == null)
            {
                context.UserLogin.Add(userLogin);
            }
            else
            {
                dbEntry.Pin = userLogin.Pin;
                dbEntry.Role = userLogin.Role;
            }
            context.SaveChanges();
        }

        //public void DeleteUserLogin(string userName)
        //{
        //    //UserLogin dbEntry = context.UserLogin.FirstOrDefault(u => u.UserName == userName);
        //    //if (dbEntry != null)
        //    //{
        //    //    context.UserLogin.Remove(dbEntry);
        //    //    context.SaveChanges();
        //    //}

        //}
    }
}
