﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PARKING_NETEntities : DbContext
    {
        public PARKING_NETEntities()
            : base("name=PARKING_NETEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BANK_ACCOUNT> BANK_ACCOUNT { get; set; }
        public virtual DbSet<CITY> CITY { get; set; }
        public virtual DbSet<PARKING> PARKING { get; set; }
        public virtual DbSet<RENT> RENT { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }
    }
}
