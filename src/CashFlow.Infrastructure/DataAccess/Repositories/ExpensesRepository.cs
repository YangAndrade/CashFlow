using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class ExpensesRepository(CashFlowDbContext context) : IExpensesRepository
{
    private readonly CashFlowDbContext _context = context;
    public void Add(Expense expense)
    {
        _context.Expenses.Add(expense);
      
    }
}
