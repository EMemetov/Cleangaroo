//*********************************************************************************************************************
// Team 5 - First version created in July, 1st 2019. 
//
// Developers:
//  Andrea de Fatima Cavalheiro - 301054219
//  Eskender Memetov - 300805013
//  Fernando Martins - 300964760
//  Kishore Jothinarayanan - 300977076
//  Mariia Staforkina - 301052981
//  Melanie March - 300903524
//  Satbyul Park -  300940276
//  Theo Dias Mitchell - 300984894
//
//*********************************************************************************************************************
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CleanGuruApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .Build();
    }
}