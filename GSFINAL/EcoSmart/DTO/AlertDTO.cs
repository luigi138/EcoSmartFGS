using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.ML.Data;

namespace EcoSmart.DTO
{
    [Table("t_alerts")]
    public class AlertDTO
    {
        [LoadColumn(0)] public int Id { get; set; }
        [LoadColumn(1)] public string Message { get; set; }
        [LoadColumn(2)] public string AlertType { get; set; }
        [LoadColumn(3)] public int IsRead { get; set; }
        [LoadColumn(4)] public DateTime CreatedAt { get; set; }
        [LoadColumn(5)] public int UserId { get; set; }
    }

    public class AlertPrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedAlertType { get; set; }
    }
}
