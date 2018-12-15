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
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MebershipType { get; set; }
        //below - as naming convention is used, this will be a foreign key in this DB
        public byte MemberShipTypeId{ get; set; }


    }
}