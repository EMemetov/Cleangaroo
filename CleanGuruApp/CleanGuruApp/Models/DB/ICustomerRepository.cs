using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface ICustomerRepository
    {
        IQueryable<Customers> Customers { get; }
        void SaveClub(Club club);

        Club DeleteClub(int clubId);
    }
}
