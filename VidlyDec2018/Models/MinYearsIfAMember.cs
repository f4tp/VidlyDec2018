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
            //1 below is a magic number... meaning it has little meaning in the context it is being used, as it is an index in the DB of the MembershipType, but that is not clear in this context
            var customer = (Customer)validationContext.ObjectInstance;

            //return success if validation is OK, else create a new instance of ValidationResult, passing the error message as the arg
            if (customer.MemberShipTypeId == MembershipType.Unknown || customer.MemberShipTypeId == MembershipType.PayAsYouGo)
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