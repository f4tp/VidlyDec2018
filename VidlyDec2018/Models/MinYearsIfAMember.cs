using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyDec2018.Models
{
    public class MinYearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //1 below is a magic number... meanign it has little meanign ineth context it is beign used, as it is an index in teh DB of the MembershipType, but that is not clear in this context
            var customer = (Customer)validationContext.ObjectInstance;

            //return success if validation si OK, else create a new instance of ValidationResult, passing teh error mesage as teh arg
            if (customer.MemberShipTypeId == 0 || customer.MemberShipTypeId == 1)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be 18 years or over for this membership type ");

           // return base.IsValid(value, validationContext);
        }
    }
}