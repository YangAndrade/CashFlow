# CashFlow

CashFlow é uma API desenvolvida em .NET 8 para gerenciamento de despesas, focada em registrar e validar informações financeiras de forma eficiente e segura.

## Tecnologias Utilizadas

- **.NET 8**
- **C# 12**
- **ASP.NET Core**
- **FluentValidation** (validação de dados)
- **Swashbuckle.AspNetCore** (Swagger/OpenAPI para documentação)
- **xUnit** (testes unitários)

## Estrutura do Projeto

- `CashFlow.Api`: Projeto principal da API.
- `CashFlow.Application`: Lógica de negócio e casos de uso.
- `CashFlow.Communication`: Contratos de requisição e resposta.
- `CashFlow.Exception`: Exceções customizadas.
- `CashFlow.Infrastructure`: Infraestrutura e persistência de dados.

## Funcionalidades

- **Registrar Despesas**:  
  Endpoint para registrar uma nova despesa, validando título, valor, data e tipo de pagamento.

- **Validação**:  
  Utiliza FluentValidation para garantir que os dados estejam corretos antes do processamento.

## Como Executar

1. **Pré-requisitos**  
   - .NET 8 SDK instalado

2. **Restaurar Dependências**
