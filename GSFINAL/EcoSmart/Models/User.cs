using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcoSmart.Models
{
    public class User
    {
        public User()
        {
            Devices = new HashSet<Device>();
            ConsumptionHistory = new HashSet<EnergyConsumption>();
            Username = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }

        // Navigation Properties
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<EnergyConsumption> ConsumptionHistory { get; set; }
    }
}