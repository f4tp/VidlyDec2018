﻿using System;
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
        private ApplicationDbContext _context;

        //ctor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //needed to dispose of DB connection
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        //[Route("Customers/AllCustomers")]
        public ActionResult Index()
        {
            //witrhout .TGoList, the database is not queried until the for each iterator in the view
            //var customers = _context.Customers;

            //adding .ToList ensures querying of DB is done when this line is executed
            var customers = _context.Customers.ToList();
            return View(customers);

            #region internal data, not db
            /*
            
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
            */
            #endregion

        }


        
        //GET one customer with ID
        //[Route("Details/{Id}")]
        public ActionResult Details(int id)
        {
            //singleOrDefautl also queries database immediately, not in iterator in view
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);

            #region internal data, not db
            /*
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
            */
        }


        

        #endregion


    }
}