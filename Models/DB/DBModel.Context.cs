﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiTorgovyAutomat.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TorgovyAutomatEntities : DbContext
    {
        public TorgovyAutomatEntities()
            : base("name=TorgovyAutomatEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Coins> Coins { get; set; }
        public virtual DbSet<Drinks> Drinks { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<VendingMachineDrinks> VendingMachineDrinks { get; set; }
        public virtual DbSet<VendingMachines> VendingMachines { get; set; }
        public virtual DbSet<VendingMachinesCoins> VendingMachinesCoins { get; set; }
    }
}