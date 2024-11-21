using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.ML.Data;

namespace EcoSmart.DTO
{
    [Table("t_alerts")] 
    public class AlertDTO
    {
        public int Id { get; set; }


        public string Message { get; set; } = string.Empty;

        public string AlertType { get; set; } = string.Empty;

        public int IsRead { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
    }
}
