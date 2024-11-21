using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoSmart.Models
{
    public class EnergyConsumption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "NUMBER(18,2)")]
        public decimal ConsumptionValue { get; set; }  // kWh

        [Column(TypeName = "NUMBER(18,2)")]
        public decimal Cost { get; set; }

        [Required]
        public int DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual Device? Device { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}