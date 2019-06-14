namespace Labs_94_EntityXML
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class table1
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }
    }
}
