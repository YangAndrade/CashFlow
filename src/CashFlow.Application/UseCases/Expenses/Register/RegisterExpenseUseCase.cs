using CashFlow.communication.Enums;
using CashFlow.communication.Requests;
using CashFlow.communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpensesJson request)
    {
        Validate(request);
        var entity = new Expense
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            Title = request.Title,
            PaymentType = (Domain.Enums.PaymentType) request.PaymentType,
        };
     
        return new ResponseRegisterExpenseJson();
     }

    private void Validate(RequestRegisterExpensesJson request)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);
        if(!result.IsValid)
        {
            var erroMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrorOnValidationException(erroMessages);
        }
    }
}
