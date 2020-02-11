using System.ComponentModel.DataAnnotations;

namespace JoeHardwareAPI.Models
{
    public class NetworkDevice
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}