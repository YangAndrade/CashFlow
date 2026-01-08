
using AutoMapper;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Delete;

public class DeleteExpenseUseCase(IExpenseWritenOnlyRepository repository, IUnityOfWork unityOfWork) : IDeleteExpenseUseCase
{
    private readonly IExpenseWritenOnlyRepository _repository = repository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);

        await _unityOfWork.Commit();
    }
}
