using CapitalGain.App.Abstractions;
using CapitalGain.App.Models;
using CapitalGain.App.Services;
using CapitalGain.Test.Helpers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CapitalGain.Test.Services
{
    public class TransactionServiceTest
    {
        private readonly ITransactionService _transactionService;
        private readonly JsonSerializerOptions _jsonOptions;

        public TransactionServiceTest()
        {
            _jsonOptions = new()
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            _transactionService = new TransactionService();
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 100}},{{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50}},{{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50}}]")]
        public void Should_HaveSameTax_When_CalculateTributesWithCase1(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase1();

            IEnumerable<Transaction>? transactions = JsonSerializer
                                                        .Deserialize<IEnumerable<Transaction>>(input,
                                                                                               _jsonOptions);
            Assert.NotNull(transactions);

            IEnumerable<Tributes> tributes = _transactionService.CalculateTributes(transactions);

            Assert.NotNull(tributes);
            Assert.Equal(responseTributes.Count(), tributes.Count());

           for (int i = 0; i < responseTributes.Count(); i++) 
           {
                Assert.Equal(responseTributes.ElementAt(i).Tax, tributes.ElementAt(i).Tax);
           }
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}},{{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":5.00, \"quantity\": 5000}}]")]
        public void Should_HaveSameTax_When_CalculateTributesWithCase2(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase2();

            IEnumerable<Transaction>? transactions = JsonSerializer
                                                        .Deserialize<IEnumerable<Transaction>>(input,
                                                                                               _jsonOptions);
            Assert.NotNull(transactions);

            IEnumerable<Tributes> tributes = _transactionService.CalculateTributes(transactions);

            Assert.NotNull(tributes);
            Assert.Equal(responseTributes.Count(), tributes.Count());

            for (int i = 0; i < responseTributes.Count(); i++)
            {
                Assert.Equal(responseTributes.ElementAt(i).Tax, tributes.ElementAt(i).Tax);
            }
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}},{{\"operation\":\"sell\", \"unit-cost\":5.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 3000}}]")]
        public void Should_HaveSameTax_When_CalculateTributesWithCase3(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase3();

            IEnumerable<Transaction>? transactions = JsonSerializer
                                                        .Deserialize<IEnumerable<Transaction>>(input,
                                                                                               _jsonOptions);
            Assert.NotNull(transactions);

            IEnumerable<Tributes> tributes = _transactionService.CalculateTributes(transactions);

            Assert.NotNull(tributes);
            Assert.Equal(responseTributes.Count(), tributes.Count());

            for (int i = 0; i < responseTributes.Count(); i++)
            {
                Assert.Equal(responseTributes.ElementAt(i).Tax, tributes.ElementAt(i).Tax);
            }
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}},{{\"operation\":\"buy\", \"unit-cost\":25.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 10000}}]")]
        public void Should_HaveSameTax_When_CalculateTributesWithCase4(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase4();

            IEnumerable<Transaction>? transactions = JsonSerializer
                                                        .Deserialize<IEnumerable<Transaction>>(input,
                                                                                               _jsonOptions);
            Assert.NotNull(transactions);

            IEnumerable<Tributes> tributes = _transactionService.CalculateTributes(transactions);

            Assert.NotNull(tributes);
            Assert.Equal(responseTributes.Count(), tributes.Count());

            for (int i = 0; i < responseTributes.Count(); i++)
            {
                Assert.Equal(responseTributes.ElementAt(i).Tax, tributes.ElementAt(i).Tax);
            }
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}},{{\"operation\":\"buy\", \"unit-cost\":25.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 10000}},{{\"operation\":\"sell\", \"unit-cost\":25.00, \"quantity\": 5000}}]")]
        public void Should_HaveSameTax_When_CalculateTributesWithCase5(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase5();

            IEnumerable<Transaction>? transactions = JsonSerializer
                                                        .Deserialize<IEnumerable<Transaction>>(input,
                                                                                               _jsonOptions);
            Assert.NotNull(transactions);

            IEnumerable<Tributes> tributes = _transactionService.CalculateTributes(transactions);

            Assert.NotNull(tributes);
            Assert.Equal(responseTributes.Count(), tributes.Count());

            for (int i = 0; i < responseTributes.Count(); i++)
            {
                Assert.Equal(responseTributes.ElementAt(i).Tax, tributes.ElementAt(i).Tax);
            }
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}},{{\"operation\":\"sell\", \"unit-cost\":2.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000}},{{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000}},{{\"operation\":\"sell\", \"unit-cost\":25.00, \"quantity\": 1000}}]")]
        public void Should_HaveSameTax_When_CalculateTributesWithCase6(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase6();

            IEnumerable<Transaction>? transactions = JsonSerializer
                                                        .Deserialize<IEnumerable<Transaction>>(input,
                                                                                               _jsonOptions);
            Assert.NotNull(transactions);

            IEnumerable<Tributes> tributes = _transactionService.CalculateTributes(transactions);

            Assert.NotNull(tributes);
            Assert.Equal(responseTributes.Count(), tributes.Count());

            for (int i = 0; i < responseTributes.Count(); i++)
            {
                Assert.Equal(responseTributes.ElementAt(i).Tax, tributes.ElementAt(i).Tax);
            }
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}},{{\"operation\":\"sell\", \"unit-cost\":2.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000}},{{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000}},{{\"operation\":\"sell\", \"unit-cost\":25.00, \"quantity\": 1000}},{{\"operation\":\"buy\", \"unit-cost\":20.00, \"quantity\": 10000}},{{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":30.00, \"quantity\": 4350}},{{\"operation\":\"sell\", \"unit-cost\":30.00, \"quantity\": 650}}]")]
        public void Should_HaveSameTax_When_CalculateTributesWithCase7(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase7();

            IEnumerable<Transaction>? transactions = JsonSerializer
                                                        .Deserialize<IEnumerable<Transaction>>(input,
                                                                                               _jsonOptions);
            Assert.NotNull(transactions);

            IEnumerable<Tributes> tributes = _transactionService.CalculateTributes(transactions);

            Assert.NotNull(tributes);
            Assert.Equal(responseTributes.Count(), tributes.Count());

            for (int i = 0; i < responseTributes.Count(); i++)
            {
                Assert.Equal(responseTributes.ElementAt(i).Tax, tributes.ElementAt(i).Tax);
            }
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}}, {{\"operation\":\"sell\", \"unit-cost\":50.00, \"quantity\": 10000}}, {{\"operation\":\"buy\", \"unit-cost\":20.00, \"quantity\": 10000}}, {{\"operation\":\"sell\", \"unit-cost\":50.00, \"quantity\": 10000}}]")]
        public void Should_HaveSameTax_When_CalculateTributesWithCase8(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase8();

            IEnumerable<Transaction>? transactions = JsonSerializer
                                                        .Deserialize<IEnumerable<Transaction>>(input,
                                                                                               _jsonOptions);
            Assert.NotNull(transactions);

            IEnumerable<Tributes> tributes = _transactionService.CalculateTributes(transactions);

            Assert.NotNull(tributes);
            Assert.Equal(responseTributes.Count(), tributes.Count());

            for (int i = 0; i < responseTributes.Count(); i++)
            {
                Assert.Equal(responseTributes.ElementAt(i).Tax, tributes.ElementAt(i).Tax);
            }
        }
    }
    
}
