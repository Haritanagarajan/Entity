﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Task2Referencial.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MvcDatabaseEntities5 : DbContext
    {
        public MvcDatabaseEntities5()
            : base("name=MvcDatabaseEntities5")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        internal RoleUserConnect ValidateUser(string username, int? roleid)
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<RoleTable> RoleTables { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }
    }
}
