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
	using System.ComponentModel.DataAnnotations;

    public partial class Calorie
    {
        public int Id { get; set; }
        public string SportName { get; set; }
        [Required]
        public string SportDegree { get; set; }
        public string Degree { get; set; }
        public decimal Coef { get; set; }
        public decimal Intercept { get; set; }
    }
}
