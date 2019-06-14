namespace Labs_94_EntityXML
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Spartan
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [StringLength(20)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Last_Name { get; set; }

        [StringLength(30)]
        public string University { get; set; }

        [StringLength(30)]
        public string Course { get; set; }

        [StringLength(5)]
        public string Degree_Classification { get; set; }
    }
}
