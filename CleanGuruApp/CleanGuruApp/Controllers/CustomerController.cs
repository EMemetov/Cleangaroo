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
        //public class ErrorController : Controller
        //{
        //    public ViewResult Error() => View();
        //}
        //public IActionResult Index()
        //{
        //    return View(customerRepository.Customers);
        //}

        //[HttpGet("details/{idcustomer}")]
        //public IActionResult Details(int idcustomer)
        //{
        //    var customer = customerRepository.GetCustomer(idcustomer);
        //    return View(customer);
        //}


        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        customerRepository.Add(customer);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);
        //}

        //public IActionResult Edit(int idcustomer)
        //{
        //    var customer = customerRepository.GetCustomer(idcustomer);

        //    return View(customer);
        //}

        //[HttpPost]
        //public IActionResult Edit(int idcustomer, Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        customerRepository.Update(customer);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);
        //}

        //public IActionResult Delete(int idcustomer)
        //{
        //    var customer = customerRepository.GetCustomer(idcustomer);

        //    return View(customer);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int idcustomer)
        //{
        //    customerRepository.Remove(idcustomer);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
