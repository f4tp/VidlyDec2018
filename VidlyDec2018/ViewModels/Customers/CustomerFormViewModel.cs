using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyDec2018.Models;

namespace VidlyDec2018.ViewModels.Customers
{
    //viewmodel because New customer view needs customer and membershiptypes object
    public class CustomerFormViewModel
    {
        //IEnumrable - allows iteration, but doesnt have add / contains methods etc
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

  
    }
}