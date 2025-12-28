using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess;
internal class UnityOfWork(CashFlowDbContext context) : IUnityOfWork
{
    private readonly CashFlowDbContext _context = context;
    public void Commit() => _context.SaveChanges();

}
