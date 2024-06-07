using CapitalGain.App.Abstractions;
using CapitalGain.App.Models;

namespace CapitalGain.App.Services
{
    public class TransactionService : ITransactionService
    {
        private const decimal DecimalZero = 0.00M;
        private const decimal ProfitTax = 0.2M;
        private const decimal ExemptionThreshold = 20000;

        public IEnumerable<Tributes> CalculateTributes(IEnumerable<Transaction> transactions)
        {
            int stockQuantity = 0;
            decimal buyPrice = DecimalZero;
            decimal weightedAveragePrice = DecimalZero;
            decimal deductibleLoss = DecimalZero;
            List<Tributes> tributes = [];

            foreach (var transaction in transactions)
            {
                if (transaction.Operation == Enums.OperationType.Buy)
                {
                    weightedAveragePrice = ((stockQuantity * buyPrice) + (transaction.Quantity * transaction.UnitCost))
                                            / (stockQuantity + transaction.Quantity);

                    stockQuantity += transaction.Quantity;
                    buyPrice = transaction.UnitCost;

                    tributes.Add(new Tributes(DecimalZero));
                    continue;
                }
                else
                {
                    decimal profit = DecimalZero;

                    stockQuantity -= transaction.Quantity;

                    deductibleLoss += GetDeductibleLoss(transaction, weightedAveragePrice);
                    profit = GetProfit(transaction, weightedAveragePrice, ref deductibleLoss);

                    tributes.Add(new Tributes(GetDueTax(transaction, profit)));
                }
            }

            return tributes;
        }

        private static decimal GetDueTax(Transaction transaction, decimal profit)
        {
            decimal operationValue = transaction.UnitCost * transaction.Quantity;

            if (operationValue <= ExemptionThreshold)
                return DecimalZero;

            return profit * ProfitTax;
        }

        private static decimal GetProfit(Transaction transaction, decimal weightedAveragePrice, ref decimal deductibleLoss)
        {
            if (transaction.Operation == Enums.OperationType.Sell && transaction.UnitCost > weightedAveragePrice)
            {
                decimal profitWithoutDeduction = Math.Abs(transaction.UnitCost * transaction.Quantity - weightedAveragePrice * transaction.Quantity);
                decimal realProfit = Math.Clamp(profitWithoutDeduction - deductibleLoss, DecimalZero, decimal.MaxValue);

                if (realProfit == DecimalZero)
                    deductibleLoss -= profitWithoutDeduction;

                return realProfit;
            }

            return DecimalZero;
        }

        private static decimal GetDeductibleLoss(Transaction transaction, decimal weightedAveragePrice)
        {
            if (transaction.Operation == Enums.OperationType.Sell && transaction.UnitCost < weightedAveragePrice)
                return Math.Abs(transaction.UnitCost * transaction.Quantity - weightedAveragePrice * transaction.Quantity);

            return DecimalZero;
        }
    }
}
