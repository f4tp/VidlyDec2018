using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyDec2018.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
    }
}