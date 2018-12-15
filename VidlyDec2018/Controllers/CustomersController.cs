using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyDec2018.Models;
using VidlyDec2018.ViewModels;

namespace VidlyDec2018.Controllers
{
    public class CustomersController : Controller
    {
        //GET one customer with ID
        [Route("Customers/Details/{Id}")]
        public ActionResult Customer(int Id)
        {
            var custsList = new List<Customer>
            {
                new Customer {Id = 1, Name = "Bob"},
                new Customer {Id = 2, Name = "Ciril"}

            };

            var cust = new Customer();
            foreach (Customer custs in custsList)
            { 
                if (custs.Id == Id)
                {
                    cust = custs;
                }

            }

            return View(cust);
        }


        // GET: Customers
        [Route("Customers/AllCustomers")]
        public ActionResult AllCustomers()
        {
            var custsList = new List<Customer>
            {
                new Customer {Id = 1, Name = "Bob"},
                new Customer {Id = 2, Name = "Ciril"}

            };

            var viewModel = new AllCustomersViewModel
            {
                AllCustomers = custsList
            };
            return View(viewModel);
        }


      
    }
}