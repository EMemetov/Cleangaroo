//*********************************************************************************************************************
// Author: Mariia Staforkina - Last Modified Date: August, 7th 2019.  
// Entity Framework - EFUserLoginRepository
//*********************************************************************************************************************
using System.Linq;

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

       // method use to save the information about the user
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
    }
}
