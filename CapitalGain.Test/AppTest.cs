using CapitalGain.App.Abstractions;
using CapitalGain.App.Models;
using CapitalGain.Test.Helpers;
using Moq;
using System.Text.Json;
using System.Text.Json.Serialization;
using CG = CapitalGain.App;

namespace CapitalGain.Test
{
    public class AppTest
    {
        private readonly Mock<ITransactionService> transactionServiceMock;
        private readonly CG.App _app;
        public AppTest()
        {
            transactionServiceMock = new Mock<ITransactionService>();
            JsonSerializerOptions JsonOptions = new()
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            _app = new CG.App(transactionServiceMock.Object
                           , JsonOptions);
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 100}},{{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50}},{{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50}}]")]
        public void Should_OutputCase1_When_InputCase1(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase1();

            transactionServiceMock
                .Setup(x => x.CalculateTributes(It.IsAny<IEnumerable<Transaction>>()))
                .Returns(responseTributes);

            Console.SetIn(new StringReader(input));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _app.Execute();

            string tributesReturn = JsonSerializer.Serialize(responseTributes);

            var consoleOutput = stringWriter
                                    .ToString()
                                    .Replace("\r","")
                                    .Replace("\n", "");

            Assert.Equal(tributesReturn, consoleOutput);
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}},{{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":5.00, \"quantity\": 5000}}]")]
        public void Should_OutputCase2_When_InputCase2(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase2();

            transactionServiceMock
                .Setup(x => x.CalculateTributes(It.IsAny<IEnumerable<Transaction>>()))
                .Returns(responseTributes);

            Console.SetIn(new StringReader(input));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _app.Execute();

            string tributesReturn = JsonSerializer.Serialize(responseTributes);

            var consoleOutput = stringWriter
                                    .ToString()
                                    .Replace("\r", "")
                                    .Replace("\n", "");

            Assert.Equal(tributesReturn, consoleOutput);
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}},{{\"operation\":\"sell\", \"unit-cost\":5.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 3000}}]")]
        public void Should_OutputCase3_When_InputCase3(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase3();

            transactionServiceMock
                .Setup(x => x.CalculateTributes(It.IsAny<IEnumerable<Transaction>>()))
                .Returns(responseTributes);

            Console.SetIn(new StringReader(input));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _app.Execute();

            string tributesReturn = JsonSerializer.Serialize(responseTributes);

            var consoleOutput = stringWriter
                                    .ToString()
                                    .Replace("\r", "")
                                    .Replace("\n", "");

            Assert.Equal(tributesReturn, consoleOutput);
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}},{{\"operation\":\"buy\", \"unit-cost\":25.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 10000}}]")]
        public void Should_OutputCase4_When_InputCase4(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase4();

            transactionServiceMock
                .Setup(x => x.CalculateTributes(It.IsAny<IEnumerable<Transaction>>()))
                .Returns(responseTributes);

            Console.SetIn(new StringReader(input));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _app.Execute();

            string tributesReturn = JsonSerializer.Serialize(responseTributes);

            var consoleOutput = stringWriter
                                    .ToString()
                                    .Replace("\r", "")
                                    .Replace("\n", "");

            Assert.Equal(tributesReturn, consoleOutput);
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}},{{\"operation\":\"buy\", \"unit-cost\":25.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 10000}},{{\"operation\":\"sell\", \"unit-cost\":25.00, \"quantity\": 5000}}]")]
        public void Should_OutputCase5_When_InputCase5(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase5();

            transactionServiceMock
                .Setup(x => x.CalculateTributes(It.IsAny<IEnumerable<Transaction>>()))
                .Returns(responseTributes);

            Console.SetIn(new StringReader(input));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _app.Execute();

            string tributesReturn = JsonSerializer.Serialize(responseTributes);

            var consoleOutput = stringWriter
                                    .ToString()
                                    .Replace("\r", "")
                                    .Replace("\n", "");

            Assert.Equal(tributesReturn, consoleOutput);
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}},{{\"operation\":\"sell\", \"unit-cost\":2.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000}},{{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000}},{{\"operation\":\"sell\", \"unit-cost\":25.00, \"quantity\": 1000}}]")]
        public void Should_OutputCase6_When_InputCase6(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase6();

            transactionServiceMock
                .Setup(x => x.CalculateTributes(It.IsAny<IEnumerable<Transaction>>()))
                .Returns(responseTributes);

            Console.SetIn(new StringReader(input));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _app.Execute();

            string tributesReturn = JsonSerializer.Serialize(responseTributes);

            var consoleOutput = stringWriter
                                    .ToString()
                                    .Replace("\r", "")
                                    .Replace("\n", "");

            Assert.Equal(tributesReturn, consoleOutput);
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}},{{\"operation\":\"sell\", \"unit-cost\":2.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000}},{{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000}},{{\"operation\":\"sell\", \"unit-cost\":25.00, \"quantity\": 1000}},{{\"operation\":\"buy\", \"unit-cost\":20.00, \"quantity\": 10000}},{{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 5000}},{{\"operation\":\"sell\", \"unit-cost\":30.00, \"quantity\": 4350}},{{\"operation\":\"sell\", \"unit-cost\":30.00, \"quantity\": 650}}]")]
        public void Should_OutputCase7_When_InputCase7(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase7();

            transactionServiceMock
                .Setup(x => x.CalculateTributes(It.IsAny<IEnumerable<Transaction>>()))
                .Returns(responseTributes);

            Console.SetIn(new StringReader(input));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _app.Execute();

            string tributesReturn = JsonSerializer.Serialize(responseTributes);

            var consoleOutput = stringWriter
                                    .ToString()
                                    .Replace("\r", "")
                                    .Replace("\n", "");

            Assert.Equal(tributesReturn, consoleOutput);
        }

        [Theory]
        [InlineData($"[{{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}}, {{\"operation\":\"sell\", \"unit-cost\":50.00, \"quantity\": 10000}}, {{\"operation\":\"buy\", \"unit-cost\":20.00, \"quantity\": 10000}}, {{\"operation\":\"sell\", \"unit-cost\":50.00, \"quantity\": 10000}}]")]
        public void Should_OutputCase8_When_InputCase8(string input)
        {
            IEnumerable<Tributes> responseTributes = TributeSetup.GetTributesCase8();

            transactionServiceMock
                .Setup(x => x.CalculateTributes(It.IsAny<IEnumerable<Transaction>>()))
                .Returns(responseTributes);

            Console.SetIn(new StringReader(input));

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _app.Execute();

            string tributesReturn = JsonSerializer.Serialize(responseTributes);

            var consoleOutput = stringWriter
                                    .ToString()
                                    .Replace("\r", "")
                                    .Replace("\n", "");

            Assert.Equal(tributesReturn, consoleOutput);
        }
    }
}