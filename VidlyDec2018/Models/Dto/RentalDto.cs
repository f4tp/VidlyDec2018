using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyDec2018.Models.Dto
{
    public class RentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}