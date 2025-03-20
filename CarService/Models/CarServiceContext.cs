using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models
{
    internal class CarServiceContext: DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<PartRequest> PartsRequests { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<UsedPart> UsedParts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public CarServiceContext() { 
        
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
            //optionsBuilder.UseSqlServer("Data Source=192.168.1.2,5434;Initial Catalog=CarService;User ID=470;Password=GzsAsiOBjK;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
                .HasMany(request => request.Parts)
                .WithMany(part => part.Requests)
                .UsingEntity<UsedPart>(
                    j => j
                        .HasOne(p => p.Part)
                        .WithMany(p => p.UsedParts)
                        .HasForeignKey(p => p.PartId)
                        .OnDelete(DeleteBehavior.NoAction),

                    j => j
                        .HasOne(p => p.Request)
                        .WithMany(p => p.UsedParts)
                        .HasForeignKey(p => p.RequestId)
                        .OnDelete(DeleteBehavior.NoAction),
                    j =>
                    {
                        j.HasKey(k => new { k.RequestId, k.PartId });
                    }
                );

            modelBuilder.Entity<Request>()
                .HasOne(r => r.Client)
                .WithMany()
                .HasForeignKey(r => r.ClientId);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.Master)
                .WithMany()
                .HasForeignKey(r => r.MasterId);
               
            modelBuilder.Entity<User>().HasData(new User { 
                Id = 1, 
                Type = UserType.Manager,
                Family = "Иванов",
                Name = "Иван",
                Patronymic = "иванович",
                Phone =  "111222333",
                Login = "111",
                Pass = "111"
            });
        }
    }
}
