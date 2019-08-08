//*********************************************************************************************************************
// Author: Theo Mitchel - Last Modified Date: August, 7th 2019.
// The CustomerController receives the customers data, validates the information and passes it to the data model.
// 
//*********************************************************************************************************************
using System.Linq;
using CleanGuruApp.Models;
using CleanGuruApp.Models.DB;
using Microsoft.AspNetCore.Mvc;


namespace CleanGuruApp.Controllers
{
    public class CustomerController : Controller
    {
        //declaring the repository variable to be used in the controller
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository repository)
        {
            customerRepository = repository;
        }

        //method to get and post the information about the customer
        //parameter "idCustomer" used to get the information about the customer
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

        //method to get the customers list
        public IActionResult ListOfCustomers()
        {
            var customerList = customerRepository.Customers;
            return View(customerList);
        }
    }
}
