using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyDec2018.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths{ get; set; }
        public byte DiscountRate{ get; set; }
        public string Name { get; set; }
        //two static members are to enhance code maintainability, so that Memberships do not have to be gotten by id number which has little or no meaning in the contexts that they are used
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;


    }
}