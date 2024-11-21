using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoSmart.Models
{
    public class EnergyTip
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "NUMBER(5,2)")]
        public decimal PotentialSavingPercentage { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "NUMBER(1)")]
        public int IsActive { get; set; } = 1;  // 使用 NUMBER(1) 代替 BOOLEAN
    }
}