using CapitalGain.App.Abstractions;
using CapitalGain.App.Models;
using System.Text.Json;

namespace CapitalGain.App
{
    public class App(ITransactionService transactionService
                   , JsonSerializerOptions serializerOptions)
    {
        public void Execute()
        {
            string? input;
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                IEnumerable<Transaction>? _transactions = JsonSerializer
                                                        .Deserialize<IEnumerable<Transaction>>(input,
                                                                                               serializerOptions);

                if (_transactions is not null)
                {
                    IEnumerable<Tributes> tributes = transactionService
                                                        .CalculateTributes(_transactions);

                    string output = JsonSerializer.Serialize(tributes);
                    Console.WriteLine(output);
                }
            };
        }
    }
}
