//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inclusion_sports.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public int Id { get; set; }
        public string Organiser { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> Start_time { get; set; }
        public Nullable<System.DateTime> End_time { get; set; }
        public string Location { get; set; }
        public string Event_type { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
    }
}
