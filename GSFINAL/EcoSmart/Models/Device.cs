using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoSmart.Models
{
    public class Device
    {
        public Device()
        {
            ConsumptionRecords = new HashSet<EnergyConsumption>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string DeviceType { get; set; } = string.Empty;

        [Column(TypeName = "NUMBER(1)")]
        public int IsActive { get; set; } = 1;

        [Column(TypeName = "NUMBER(1)")]
        public int IsConnected { get; set; } = 0;

        [StringLength(200)]
        public string Location { get; set; } = string.Empty;

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastDataReceived { get; set; }

        public virtual ICollection<EnergyConsumption> ConsumptionRecords { get; set; }
    }
}