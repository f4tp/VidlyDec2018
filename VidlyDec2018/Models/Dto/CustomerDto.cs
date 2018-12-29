using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyDec2018.Models.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
       
        //The below should be deleted... DTOs should use primitive types, or custom DTOs, otherwise same security issues exist as if using domain model objects
        //public MembershipType MebershipType { get; set; }
        //Also, display attributes are not needed

            //instead we need a Dto variant of MembershipType

        public MembershipTypeDto MembershipType { get; set; }

        public byte MemberShipTypeId { get; set; }
        //[MinYearsIfAMember]
        public DateTime? Birthdate { get; set; }



    }
}