using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ParcelManagementSystem.Controllers;
using ParcelManagementSystem.Models;

namespace ParcelManagementSystem.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<User> Users { get; set; }
    }


}
