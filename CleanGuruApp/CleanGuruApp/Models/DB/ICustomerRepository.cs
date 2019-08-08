//***************************************************************************************************************
// Author: Theo Mitchel - Last Modified Date: August, 7th 2019.  
// Declaring the methods to be used for the EFCustomerRepository
//***************************************************************************************************************

using System.Collections.Generic;


namespace CleanGuruApp.Models.DB
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }
        void SaveCustomer(Customer customer);
        Customer GetCustomer(int? idCustomer);
    }
}
