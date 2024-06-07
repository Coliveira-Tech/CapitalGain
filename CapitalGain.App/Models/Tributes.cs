using System.Text.Json.Serialization;

namespace CapitalGain.App.Models
{
    public class Tributes(decimal tax)
    {
        [JsonPropertyName("tax")]
        public decimal Tax
        {
            get { return Math.Round(tax, 2); }
            set { tax = value; }
        }
    }
}
