using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject_WebPage.Models
{
    public class Cohorts
    {
        [Key]
        public int CohortID { get; set; }
        public string CohortName { get; set; }
        public int SpecID { get; set; }
    }
}
