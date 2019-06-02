namespace Homework_105_ToDoApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task
    {
        public int TaskId { get; set; }

        [StringLength(50)]
        public string TaskDescription { get; set; }

        public bool? Done { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateStarted { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFinished { get; set; }

        public int? CategoryID { get; set; }

        public int? UserID { get; set; }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }
    }
}
