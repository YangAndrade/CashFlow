using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class ExpensesRepository(CashFlowDbContext context) : IExpensesRepository
{
    private readonly CashFlowDbContext _context = context;
    public async Task Add(Expense expense)
    {
        await _context.Expenses.AddAsync(expense);
      
    }

    public async Task<List<Expense>> GetAllAsync()
    {
      return await _context.Expenses.AsNoTracking().ToListAsync();
    }
}
