//*********************************************************************************************************************
// Author: Mariia Staforkina - Last Modified Date: August, 7th 2019.  
// Declaring the methods to be used for the EFScheduleCleanerRepository
//*********************************************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanGuruApp.Models.DB
{
    public interface IScheduleCleanerRepository
    {
        IQueryable<ScheduleCleaner> ScheduleCleaners { get; }
        void SaveScheduleCleaner(ScheduleCleaner scheduleCleaner);
        void DeleteScheduleCleaner(int idScheduleCleaner);
        List<ScheduleCleaner> ListCleaners(String dayWeek, String initTime, String finTime);
    }
}
