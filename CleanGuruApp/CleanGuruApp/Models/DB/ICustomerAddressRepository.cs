//*********************************************************************************************************************
// Author: Andrea Cavalheiro - Last Modified Date: August, 7th 2019.  
// Declaring the methods to be used for the EFCustomerAddressRepository
//*********************************************************************************************************************
using System.Collections.Generic;


namespace CleanGuruApp.Models.DB
{
    public interface ICustomerAddressRepository
    {   
        IEnumerable<CustomerAddress> CustomerAddresss { get; }
        void SaveCustomerAddress(CustomerAddress customerAddresss);
    }
}
