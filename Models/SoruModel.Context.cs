﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rosu.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FKM52802019Entities2 : DbContext
    {
        public FKM52802019Entities2()
            : base("name=FKM52802019Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<asset> assets { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<clubHead> clubHeads { get; set; }
        public virtual DbSet<Committee> Committees { get; set; }
        public virtual DbSet<CommitteeMember> CommitteeMembers { get; set; }
        public virtual DbSet<Executive> Executives { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<Stakeholder> Stakeholders { get; set; }
        public virtual DbSet<studentLeader> studentLeaders { get; set; }
    }
}
