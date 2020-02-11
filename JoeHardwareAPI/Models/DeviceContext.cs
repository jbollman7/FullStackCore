using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace JoeHardwareAPI.Models
{
    public class DeviceContext : DbContext
    {
        public DeviceContext(DbContextOptions<DeviceContext> options)
            : base(options)
        {
        }

        
        public DbSet<ComputerDevice> ComputerDevices { get; set; }
        public DbSet<NetworkDevice> NetworkDevices { get; set; }
        public DbSet<StorageDevice> StorageDevices { get; set; }
    }
}