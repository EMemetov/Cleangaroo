using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface IUserLoginRepository
    {
        IQueryable<UserLogin> UserLogins { get; }
        void SaveUserLogin(UserLogin userLogin);

        //void DeleteUserLogin(string userName);
    }
}
