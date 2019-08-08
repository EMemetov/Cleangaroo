//*********************************************************************************************************************
// Author: Theo Mitchel - Last Modified Date: August, 7th 2019.  
// Declaring the methods to be used for the EFCleanerRepository
//*********************************************************************************************************************
using System.Collections.Generic;


namespace CleanGuruApp.Models.DB
{
    public interface ICleanerRepository
    {

        IEnumerable<Cleaner> Cleaners { get; }
        void SaveCleaner(Cleaner cleaner);
        Cleaner GetCleaner(int? idCleaner);
    }
}
