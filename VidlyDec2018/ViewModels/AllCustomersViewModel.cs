using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyDec2018.Models;

namespace VidlyDec2018.ViewModels
{
    public class AllCustomersViewModel
    {
        //view models hold data for the view when there are more than one model involved
        //populate this list in the CustomersController
        public List<Customer> AllCustomers { get; set; }
  
    }
}