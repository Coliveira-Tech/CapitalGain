using CapitalGain.App.Enums;
using System.Text.Json.Serialization;

namespace CapitalGain.App.Models
{
    public class Transaction
    {
        [JsonPropertyName("unit-cost")]
        public decimal UnitCost { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("operation")]
        public OperationType Operation { get; set; }
    }
}
