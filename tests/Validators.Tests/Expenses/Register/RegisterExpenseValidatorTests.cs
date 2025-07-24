using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.communication.Requests;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpensesJsonBuilder.Build();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeTrue();
    }
}
