﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SankoRehber
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RehberEntities : DbContext
    {
        public RehberEntities()
            : base("name=RehberEntities")
        {
          //((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 6;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblAdmin> TblAdmin { get; set; }
        public virtual DbSet<TblRehber> TblRehber { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
    }
}
