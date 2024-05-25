using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhysioRental.Models;

namespace RentalPhysioDevices.Data
{
    public class ApplicationDbContext : IdentityDbContext
    { 
        public DbSet<DeviceModel> Devices{get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
