﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Epic3Entities3 : DbContext
    {
        public Epic3Entities3()
            : base("name=Epic3Entities3")
        {
        }
    
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}
    
        public virtual DbSet<TobaccoHetero> TobaccoHeteroes { get; set; }
        public virtual DbSet<TobaccoHomo> TobaccoHomoes { get; set; }
        public virtual DbSet<tblFile> tblFiles { get; set; }
    }
}
