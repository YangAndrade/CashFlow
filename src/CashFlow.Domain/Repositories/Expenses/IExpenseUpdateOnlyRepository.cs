using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpenseUpdateOnlyRepository
{
    Task<Expense?> GetExpenseById(long id); 
    void Update(Expense expense);
}
