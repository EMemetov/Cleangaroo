//*********************************************************************************************************************
// Author: Satbyul Park - Last Modified Date: August, 7th 2019.  
// Declaring the methods to be used for the EFServicePriceRepository
//*********************************************************************************************************************
using System.Collections.Generic;


namespace CleanGuruApp.Models.DB
{
    public interface IServicePriceRepository
    {
        IEnumerable<ServicePrice> ServicePrices { get; }
        void SaveServicePrice(ServicePrice servicePrice);
        ServicePrice GetServicePrice(int? idServicePrice);
    }
}
