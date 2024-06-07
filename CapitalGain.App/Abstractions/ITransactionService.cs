using CapitalGain.App.Models;

namespace CapitalGain.App.Abstractions
{
    public interface ITransactionService
    {
        IEnumerable<Tributes> CalculateTributes(IEnumerable<Transaction> transactions);
    }
}
