using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private ApplicationDBContext context;

        public EFCustomerRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        //public IQueryable<Cleaners> Cleaners => context.Cleaners.Include(c => c.Players);     //DELETE after adjust below

        public IQueryable<Customers> Customers => throw new NotImplementedException();            //DELETE after adjust abouve

        public void SaveCustomers(Customers customer)
        {
            //INSERT CODE

            context.SaveChanges();
        }

        public Customers DeleteCustomers(int idCustomer)
        {
            Customers customer = Customers.FirstOrDefault(c => c.IdCustomer == idCustomer);

            //INSERT CODE

            return customer;
        }
    }
}
