using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public class EFCustomerAddressRepository : ICustomerAddressRepository
    {
        private ApplicationDBContext context;

        public EFCustomerAddressRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        //public IQueryable<Cleaners> Cleaners => context.Cleaners.Include(c => c.Players);     //DELETE after adjust below

        public IQueryable<CustomerAddress> CustomerAddresss => throw new NotImplementedException();            //DELETE after adjust abouve

        public void SaveCustomerAddress(CustomerAddress customerAddress)
        {
            //INSERT CODE

            context.SaveChanges();
        }

        public CustomerAddress DeleteCustomerAddress(int idCustAddress)
        {
            //CustomerAddress customerAddress = CustomerAddress.FirstOrDefault(c => c.IdCustAddress == idCustAddress);  //ERROR ??????

            //INSERT CODE

            //return customerAddress;       //ERROR ????
            //Just to make it work
            CustomerAddress customerAddress = new CustomerAddress();
            return customerAddress;
        }
    }
}
