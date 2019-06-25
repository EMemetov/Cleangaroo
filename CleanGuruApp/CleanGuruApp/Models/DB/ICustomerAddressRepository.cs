﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanGuruApp.Models.DB
{
    public interface ICustomerAddressRepository
    {
        IQueryable<CustomerAddress> CustomerAddresss { get; }
        void SaveCustomerAddress(CustomerAddress customerAddresss);

        CustomerAddress DeleteCustomerAddress(int idCustAddress);
    }
}