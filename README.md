# Ganho de Capital

## Especificação

Este projeto tem como objetivo apresentar um programa de linha de comando (CLI) que calcula o imposto a ser pago sobre lucros ou prejuízos de operações do mercado financeiro de ações. 

A especificação tecnica pode ser encontrada no arquivo **spec-ptbr.pdf** que se encontra na pasta raiz.

## Estrutura de pastas

Pelo escopo do projeto, optei por seguir com uma estrutura de projeto simples, de fácil entendimento e manutenção, conforme abaixo:

```shell
.CaptalGain.App
├── Abstractions
│   └── ITransactionService.cs 
├── Enums
│   └── OperationType.cs
├── Models
│   ├── Transaction.cs
│   └── Tributes.cs
├── Services
│   └── TransactionService.cs
├── App.cs
├── Dockerfile
└── Program.cs

──────────────────────────────────

.CaptalGain.Test
├── Helpers
│   └── TributeSetup.cs
├── Services
│   └── TransactionServiceTest.cs
└── AppTest.cs
```

## Executando a aplicação

É possível executar esta aplicação de 2 maneiras, via Dotnet Cli e via Docker.

### Dotnet CLI 

Primeiramente é necessário baixar e instalar o Dotnet SDK 8.0, você pode fazer isso [neste site](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.301-windows-x64-installer)

Após baixar e instalar o DotNet SDK, reinicie a máquina, abra o terminal de sua preferencia e navegue até o diretório raiz do projeto (mesmo diretório que esta localizado o arquivo **CapitalGain.sln**) e digite o seguinte comando:

```
dotnet run --project .\CapitalGain.App\CapitalGain.App.csproj
```
Para executar os testes unitários da aplicação, basta digitar o comando abaixo:

```
dotnet test
```

### Docker

O primeiro passo é baixar e instalar o docker, você consegue fazer isso [neste site](https://www.docker.com/products/docker-desktop/) 

Após baixar e instalar o Docker, reinicie a máquina, abra o terminal de sua preferencia e navegue até o diretório raiz do projeto (mesmo diretório que esta localizado o arquivo **CapitalGain.sln**) e digite o seguinte comando para buildar sua imagem:

```
docker build -t capitalgain -f CapitalGain.App\Dockerfile .
```
Assim que o processo terminar, digite o comando abaixo para executar a aplicação:

```
docker run -it capitalgain
```

## Entradas e Saídas de dados

Conforme a especificação técnica, abaixo estão as entradas que devem ser submetidas para a aplicação e as saídas esperadas, após executar a aplicação, basta entrar com a informação de input que o sistema deve retornar os valores de output:


Case #1
```
Input:
[{"operation":"buy", "unit-cost":10.00, "quantity": 100},{"operation":"sell", "unit-cost":15.00, "quantity": 50},{"operation":"sell", "unit-cost":15.00, "quantity": 50}]

Output:
[{"tax": 0.00},{"tax": 0.00},{"tax": 0.00}]

```

Case #2
```
Input:
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},{"operation":"sell", "unit-cost":20.00, "quantity": 5000},{"operation":"sell", "unit-cost":5.00, "quantity": 5000}]

Output:
[{"tax": 0.00},{"tax": 10000.00},{"tax": 0.00}]
```

Case #1 + Case #2
```
Input:
[{"operation":"buy", "unit-cost":10.00, "quantity": 100},{"operation":"sell", "unit-cost":15.00, "quantity": 50},{"operation":"sell", "unit-cost":15.00, "quantity": 50}]
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},{"operation":"sell", "unit-cost":20.00, "quantity": 5000},{"operation":"sell", "unit-cost":5.00, "quantity": 5000}]

Output:
[{"tax": 0.00},{"tax": 0.00},{"tax": 0.00}]
[{"tax": 0.00},{"tax": 10000.00},{"tax": 0.00}]
```

Case #3
```
Input:
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},{"operation":"sell", "unit-cost":5.00, "quantity": 5000},{"operation":"sell", "unit-cost":20.00, "quantity": 3000}]

Output:
[{"tax": 0.00},{"tax": 0.00},{"tax": 1000.00}]
```

Case #4
```
Input:
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},{"operation":"buy", "unit-cost":25.00, "quantity": 5000},{"operation":"sell", "unit-cost":15.00, "quantity": 10000}]

Output:
[{"tax": 0.00},{"tax": 0.00},{"tax": 0.00}]
```
Case #5
```
Input:
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},{"operation":"buy", "unit-cost":25.00, "quantity": 5000},{"operation":"sell", "unit-cost":15.00, "quantity": 10000},{"operation":"sell", "unit-cost":25.00, "quantity": 5000}]

Output:
[{"tax": 0.00},{"tax": 0.00},{"tax": 0.00},{"tax": 10000.00}]
```
Case #6
```
Input:
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},{"operation":"sell", "unit-cost":2.00, "quantity": 5000},{"operation":"sell", "unit-cost":20.00, "quantity": 2000},{"operation":"sell", "unit-cost":20.00, "quantity": 2000},{"operation":"sell", "unit-cost":25.00, "quantity": 1000}]

Output:
[{"tax": 0.00},{"tax": 0.00},{"tax": 0.00},{"tax": 0.00},{"tax": 3000.00}]
```
Case #7
```
Input:
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000},{"operation":"sell", "unit-cost":2.00, "quantity": 5000},{"operation":"sell", "unit-cost":20.00, "quantity": 2000},{"operation":"sell", "unit-cost":20.00, "quantity": 2000},{"operation":"sell", "unit-cost":25.00, "quantity": 1000},{"operation":"buy", "unit-cost":20.00, "quantity": 10000},{"operation":"sell", "unit-cost":15.00, "quantity": 5000},{"operation":"sell", "unit-cost":30.00, "quantity": 4350},{"operation":"sell", "unit-cost":30.00, "quantity": 650}]

Output:
[{"tax":0.00}, {"tax":0.00}, {"tax":0.00}, {"tax":0.00}, {"tax":3000.00},{"tax":0.00}, {"tax":0.00}, {"tax":3700.00}, {"tax":0.00}]
```
Case #8
```
Input:
[{"operation":"buy", "unit-cost":10.00, "quantity": 10000}, {"operation":"sell", "unit-cost":50.00, "quantity": 10000}, {"operation":"buy", "unit-cost":20.00, "quantity": 10000}, {"operation":"sell", "unit-cost":50.00, "quantity": 10000}]

Output:
[{"tax":0.00},{"tax":80000.00},{"tax":0.00},{"tax":60000.00}]
```
