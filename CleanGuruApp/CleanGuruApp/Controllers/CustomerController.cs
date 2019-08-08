using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanGuruApp.Models;
using CleanGuruApp.Models.DB;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanGuruApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository repository)
        {
            customerRepository = repository;
        }
      
        [HttpGet]
        public IActionResult Register(int idCustomer) => View(customerRepository.Customers.FirstOrDefault(c => c.IdCustomer == idCustomer));

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerRepository.SaveCustomer(customer); 
                TempData["message"] = $"Customer {customer.UserName} has been successfully registered in the system";

                return View("../Home/Index");
            }
            else
            {
                return View(customer);
            }
        }
        public IActionResult ListOfCustomers()
        {
            var customerList = customerRepository.Customers;
            return View(customerList);
        }
    }
}
