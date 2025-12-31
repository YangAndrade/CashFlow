namespace CashFlow.Domain.Repositories.Expenses;
public interface IUnityOfWork
{
    Task Commit();
}
