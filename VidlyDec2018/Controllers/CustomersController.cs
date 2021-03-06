﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using VidlyDec2018.Models;
using VidlyDec2018.ViewModels;
using VidlyDec2018.ViewModels.Customers;


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
            //without .ToList, the database is not queried until the for each iterator in the view
            //var customers = _context.Customers;

            //adding .ToList ensures querying of DB is done when this line is executed
            //taken out as no eager loading
            //var customers = _context.Customers.ToList();

            //Include(c +>).. etc method is eager loading
            //above needs Using Data.System.Entity
            //eager loading - load all data you want, including related data in other tables



            // below is the proper code, but has been taken out as we are making a call to the API and getting the customers this way now

            /*
            var customers = _context.Customers.Include(c => c.MebershipType ).ToList();
            return View(customers);
            */

            //using System.Runtime.Caching... to find this, right click References in SOl Exlpo, add reference, search for it
            //again only use this after performance testing the app
            if (MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = _context.Genres.ToList();
            }
            else
            {
                var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;
            }

            return View();


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

        //this method is called New, but the page it links to is called CustomerForm.cshtml...
        //...therefore the name of the form has to be passed explicitly
        public ActionResult New()
        {

            var membershiptypes = _context.MembershipTypes.ToList();
            var viewModel = new ViewModels.Customers.CustomerFormViewModel
            {
                //initializing the customer here will initialize properties with their default values, so no null object errors found later
                Customer = new Customer(),
                MembershipTypes = membershiptypes
            };
            return View("CustomerForm", viewModel);
        }
        //viewmodel passed in is model binding
        //this only allows this method to be called with a Post HTTP request, not a get
        //public ActionResult Save(ViewModels.Customers.CustomerFormViewModel viewModel)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //Model>State.IsValid - detects whether the Model passed in meets the validation rules set in the class

            //validation failing because MembershipType object is empty / null
            //all this took to solve it was creating the Customer object before in the New() method... I had already sent acorss the MembershipTypes in the viewmodel put in
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                //if the view is not valid / the object doesn't meet the validation rules,
                //return the same view with teh updated model, to keep them on it with teh valdiaton error essages
                return View("CustomerForm", viewModel);
            }
            //customer id passed in - if 0 means new customer
            //as hidden field on form giving 0on New customer, or id of customer from model
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDB, "", new String[] { "Name", "Email" });
                customerInDB.Name = customer.Name;
                customerInDB.Birthdate = customer.Birthdate;
                customerInDB.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            
            //.SaveChanges persists things to storage, not just this one, but any database change that's gone on.. if any fail, none of the changes go ahead
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        
        public ActionResult Edit (int id)
        {
            //if the given customer sent from ??/ exists, it will eb returned, otherwise null will be sent back 
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            //this returns the New view, otherwise teh view it woudl have looked to transfer to would have been edit
            //it also uses te viewModel created before, passing it in
            return View("CustomerForm", viewModel);
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