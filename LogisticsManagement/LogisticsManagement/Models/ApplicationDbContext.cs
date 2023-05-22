using LogisticsManagement.Models.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace LogisticsManagement.Models
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShipmentProduct> ShipmentProducts { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            //one customer one appuser
            modelBuilder.Entity<AppUser>()
            .HasOne(e => e.Customer)
            .WithOne(e => e.AppUser)
            .HasForeignKey<AppUser>(e => e.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);
            //one personnel one appuser
            modelBuilder.Entity<AppUser>()
            .HasOne(e => e.Personnel)
            .WithOne(e => e.AppUser)
            .HasForeignKey<AppUser>(e => e.PersonnelId)
            .OnDelete(DeleteBehavior.NoAction);
            */
            //one customer many shipments --dokunma
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.Sender)
                .WithMany(c => c.Sentshipments)
                .HasForeignKey(s => s.SenderId)
                .OnDelete(DeleteBehavior.Cascade);
            //one customer many shipments --dokunma
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.Receiver)
                .WithMany(c => c.ReceivedShipments)
                .HasForeignKey(s => s.ReceiverId)
                .OnDelete(DeleteBehavior.Cascade);
            //many warehouse many product
            modelBuilder.Entity<WarehouseProduct>()
            .HasKey(wp => new { wp.Id });

            modelBuilder.Entity<WarehouseProduct>()
                .HasOne(wp => wp.warehouse)
                .WithMany(w => w.warehouseProducts)
                .HasForeignKey(wp => wp.WarehouseId);

            modelBuilder.Entity<WarehouseProduct>()
                .HasOne(wp => wp.product)
                .WithMany(p => p.warehouseProducts)
                .HasForeignKey(wp => wp.ProductId);

            //one personnel many shipments --dokunma
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.personnel)
                .WithMany(s => s.Shipments)
                .HasForeignKey(s => s.PersonnelId)
                .OnDelete(DeleteBehavior.NoAction);
            //one invoice with many shipment --dokunma
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.invoice)
                .WithMany(s => s.Shipments)
                .HasForeignKey(s => s.InvoiceId)
                .OnDelete(DeleteBehavior.NoAction);
            //many shipment many product
            modelBuilder.Entity<ShipmentProduct>()
            .HasKey(ps => new { ps.ProductId, ps.ShipmentId });

            modelBuilder.Entity<ShipmentProduct>()
                .HasOne(ps => ps.product)
                .WithMany(p => p.shipmentProducts)
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<ShipmentProduct>()
                .HasOne(ps => ps.shipment)
                .WithMany(s => s.shipmentProducts)
                .HasForeignKey(ps => ps.ShipmentId);
            //one source warehouse many shipments
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.sourceWarehouse)
                .WithMany(s => s.SourceShipments)
                .HasForeignKey(s => s.SourceWarehouseId)
                .OnDelete(DeleteBehavior.NoAction);
            //one destination warehouse many shipments
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.destinationWarehouse)
                .WithMany(s => s.DestinationShipments)
                .HasForeignKey(s => s.DestinationWarehouseId)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}
