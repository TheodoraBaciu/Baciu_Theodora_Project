namespace ComputerLotModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ComputerLotEntitiesModel : DbContext
    {
        public ComputerLotEntitiesModel()
            : base("name=ComputerLotEntitiesModel")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Customer)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Inventory)
                .WillCascadeOnDelete();
        }
    }
}
