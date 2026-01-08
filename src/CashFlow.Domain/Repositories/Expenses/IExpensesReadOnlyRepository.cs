using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesReadOnlyRepository
{
    public Task<List<Expense>> GetAllAsync();
    public Task<Expense?> GetExpenseById(long id);
}
