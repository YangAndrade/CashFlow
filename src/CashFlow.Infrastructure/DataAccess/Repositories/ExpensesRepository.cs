using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class ExpensesRepository(CashFlowDbContext context) : IExpensesReadOnlyRepository, IExpenseWritenOnlyRepository, IExpenseUpdateOnlyRepository
{
    private readonly CashFlowDbContext _context = context;
    public async Task Add(Expense expense)
    {
        await _context.Expenses.AddAsync(expense);
      
    }

    public async Task<bool> Delete(long id)
    {
       var result = await _context.Expenses.FirstOrDefaultAsync(x=> x.Id == id);
        if(result is null)
        {
            return false;
        }
        _context.Expenses.Remove(result);
        return true;
    }

    public async Task<List<Expense>> GetAllAsync()
    {
      return await _context.Expenses.AsNoTracking().ToListAsync();
    }

     async Task<Expense?> IExpensesReadOnlyRepository.GetExpenseById(long id)
    {
        return await _context.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

     async Task<Expense?> IExpenseUpdateOnlyRepository.GetExpenseById(long id)
    {
        return await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
    }

    public void Update(Expense expense)
    {
        _context.Expenses.Update(expense);
    }
}
