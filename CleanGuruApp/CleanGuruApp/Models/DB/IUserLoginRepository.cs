//*********************************************************************************************************************
// Author: Mariia Staforkina - Last Modified Date: August, 7th 2019.  
// Declaring the methods to be used for the EFUserLoginRepository
//*********************************************************************************************************************
using System.Linq;


namespace CleanGuruApp.Models.DB
{
    public interface IUserLoginRepository
    {
        IQueryable<UserLogin> UserLogins { get; }
        void SaveUserLogin(UserLogin userLogin);
    }
}
