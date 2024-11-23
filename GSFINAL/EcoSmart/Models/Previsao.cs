using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoSmart.Models
{
    public class Previsao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataPrevisao { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "NUMBER(18,2)")]
        public decimal ConsumoPrevisao { get; set; }

        [Required]
        [Column(TypeName = "NUMBER(18,2)")]
        public decimal CustoPrevisao { get; set; }

        [Required]
        public int DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual Device? Device { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

        [StringLength(500)]
        public string? Observacoes { get; set; }

        [Column(TypeName = "NUMBER(5,2)")]
        public decimal PrecisaoModelo { get; set; }  // 模型准确率

        [Required]
        [StringLength(50)]
        public string TipoPrevisao { get; set; } = "Diario";  // Diario, Semanal, Mensal
    }
}