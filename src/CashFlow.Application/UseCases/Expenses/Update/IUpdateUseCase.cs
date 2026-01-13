using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.Expenses.Update;

public interface IUpdateUseCase
{
    public Task Execute(long id, RequestExpensesJson request);
}
