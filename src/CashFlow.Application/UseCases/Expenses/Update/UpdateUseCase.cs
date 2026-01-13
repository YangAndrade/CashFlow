using AutoMapper;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Update;

public class UpdateUseCase(IMapper mapper, IUnityOfWork unityOfWork, IExpenseUpdateOnlyRepository repository) : IUpdateUseCase
{

    private readonly IMapper _mapper = mapper;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly IExpenseUpdateOnlyRepository _repository = repository;
    public async Task Execute(long id, RequestExpensesJson request)
    {
        Validate(request);
        var expense = await _repository.GetExpenseById(id);

        if (expense == null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }
        _mapper.Map(request, expense);
        _repository.Update(expense);
        await _unityOfWork.Commit();
    }
    private void Validate(RequestExpensesJson request)
    {
        var validator = new ExpenseValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errorMessage = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessage);
        }
    }
}
