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

        ////NOT WORKING
        //public void SaveUserLogin(UserLogin userLogin)
        //{
        //    //I'm not sure if we can use null or ""
        //    if (userLogin == null)
        //    //if (userLogin.UserName.Equals(""))
        //    {
        //        context.UserLogin.Add(userLogin);
        //    }
        //    else
        //    {
        //        UserLogin dbEntry = context.UserLogin
        //          .FirstOrDefault(u => u.UserName == userLogin.UserName);
        //        if (dbEntry != null)
        //        {
        //            dbEntry.Pin = userLogin.Pin;
        //            dbEntry.Role = userLogin.Role;
        //        }
        //    }
        //    context.SaveChanges();
        //}

        
        public void SaveUserLogin(UserLogin userLogin)
        {
            UserLogin dbEntry = context.UserLogin
              .FirstOrDefault(u => u.UserName == userLogin.UserName);
            //I'm not sure if we can use null or ""
            if (dbEntry == null)
            //if (userLogin.UserName.Equals(""))
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






        //        public void DeleteUserLogin(string userName)
        //        {
        //            UserLogin dbEntry = context.UserLogin
        //           .FirstOrDefault(u => u.UserName == userName);
        //            if (dbEntry != null)
        //            {
        //                context.UserLogin.Remove(dbEntry);
        //                context.SaveChanges();
        //            }
        //        }
    }
}
