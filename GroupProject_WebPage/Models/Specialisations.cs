using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject_WebPage.Models
{
    public class Specialisations
    {
        [Key]
        public int SpecID { get; set; }
        public string SpecName { get; set; }
    }
}
