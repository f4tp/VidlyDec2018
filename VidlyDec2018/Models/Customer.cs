using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace VidlyDec2018.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        //Navigation property - allows for table to be created without makign membershipType known explcitly to the DBContext 
        public MembershipType MembershipType { get; set; }
        //below - as naming convention is used, this will be a foreign key in this DB
        [Display(Name="Membership Type")]
        public byte MemberShipTypeId{ get; set; }
        //Display attribute allows you to set form label... this way you have to recompiel the code when making changes to HTML
        //another was to achieve the above is to manually add a label... e.g.
        //<Label for="birthdate"> Date of birth </label> instead of @Html etc
        [MinYearsIfAMember]
        //the above validation attribute is custom class by me
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }


    }
}