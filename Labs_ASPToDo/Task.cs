//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Labs_ASPToDo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public int TaskId { get; set; }
        public string TaskDescription { get; set; }
        public Nullable<bool> Done { get; set; }
        public System.DateTime DateStarted { get; set; }
        public Nullable<System.DateTime> DateFinished { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
