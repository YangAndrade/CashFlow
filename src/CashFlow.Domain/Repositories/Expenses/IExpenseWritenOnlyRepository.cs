using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpenseWritenOnlyRepository
{
    public Task Add(Expense expense);
    public Task<bool> Delete(long id);
}
